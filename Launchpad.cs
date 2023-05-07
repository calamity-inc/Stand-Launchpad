using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Stand_Launchpad
{
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[SuppressMessage("ReSharper", "LocalizableElement")]
	public partial class Launchpad : Form
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("dwmapi.dll", SetLastError = true)]
		private static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, int[] pvAttribute, uint cbAttribute);

		//dark title bar
		protected override void OnHandleCreated(EventArgs e)
		{
			if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
			{
				DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
			}
		}

		private static Random random = new Random();

		// Don't forget to update the file version
		private const string launchpad_update_version = "1.8.4";
		private const string launchpad_display_version = "1.8.4";

		private string stand_dir;
		private string stand_dll;

		private const int width_simple = 248;
		private readonly int width_advanced;

		private string[] versions;
		private int download_progress = 0;

		private int gta_pid = 0;
		private bool game_was_open = false;
		private bool can_auto_inject = true;
		private bool any_successful_injection = false;

		public Launchpad()
		{
			stand_dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Stand";

			InitializeComponent();
			width_advanced = Width;
			Text += " " + launchpad_display_version;
			LauncherType.DataSource = new[]
			{
				new DropDownEntry(0, "Epic Games"),
				new DropDownEntry(1, "Steam"),
				new DropDownEntry(2, "Rockstar Games"),
			};

			if (Properties.Settings.Default.MustUpgrade)
			{
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.MustUpgrade = false;
				Properties.Settings.Default.Save();
			}

			AutoInjectCheckBox.Checked = Properties.Settings.Default.AutoInject;
			AutoInjectDelaySeconds.Value = Properties.Settings.Default.AutoInjectDelaySeconds;
			LauncherType.SelectedIndex = Properties.Settings.Default.GameLauncher;

			toggleInjectOrLaunchBtn(false);
			UpdateTimer.Start();
		}

		private void UpdateTimer_Tick(object sender, EventArgs e)
		{
			UpdateTimer.Stop();
			checkForUpdate(false);
			updateGtaPid();
			processGtaPidUpdate(false);
			if (gta_pid != 0)
			{
				InjectBtn.Focus();
			}
			ProcessScanTimer.Start();
		}

		private bool checkForUpdate(bool recheck)
		{
			ensureStandBinDirExists();
			HttpClient httpClient = new HttpClient();
			Task<string> httpTask = httpClient.GetStringAsync("https://stand.gg/versions.txt");
			DirectoryInfo bin_di = new DirectoryInfo(stand_dir + "\\Bin\\");
			string versions_string = "";
			try
			{
				httpTask.Wait();
				versions_string = httpTask.Result;
			}
			catch (Exception)
			{
				foreach (FileInfo file in bin_di.GetFiles())
				{
					if (file.Name.StartsWith("Stand ") && file.Name.EndsWith(".dll"))
					{
						versions_string = launchpad_update_version + ":" + file.Name.Substring(6, file.Name.Length - 6 - 4);
					}
				}
			}
			if (versions_string.Length == 0)
			{
				showMessageBox("Failed to get version information. Ensure you're connected to the internet and have no anti-virus program or firewall interfering.");
				if (recheck)
				{
					return false;
				}
				Application.Exit();
			}
			versions = versions_string.Split(':');

			if (recheck)
			{
				saveSettings();
				DllList.Items.Clear();
			}

			if (!Properties.Settings.Default.Advanced)
			{
				updateAdvancedMode();
			}
			DllList.Items.Add("Stand " + versions[1]);
			if (Properties.Settings.Default.CustomDll != "")
			{
				foreach (string dll in Properties.Settings.Default.CustomDll.Split('|'))
				{
					DllList.Items.Add(dll);
				}
			}
			for (int i = 0; i < Properties.Settings.Default.InjectDll.Length; i++)
			{
				if (Properties.Settings.Default.InjectDll.Substring(i, 1) == "1")
				{
					DllList.Items[i].Checked = true;
				}
			}

			bool any_updates = false;
			stand_dll = stand_dir + "\\Bin\\Stand " + versions[1] + ".dll";
			if (!File.Exists(stand_dll))
			{
				try
				{
					foreach (FileInfo file in bin_di.GetFiles())
					{
						file.Delete();
					}
					foreach (DirectoryInfo dir in bin_di.GetDirectories())
					{
						dir.Delete(true);
					}
				}
				catch (Exception)
				{
				}
				downloadStandDll();
				any_updates = true;
			}
			if (versions[0] != launchpad_update_version)
			{
				if (showMessageBox("Launchpad " + versions[0] + " is available. Would you like to download it?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Process.Start("https://stand.gg/launchpad_update");
				}
				any_updates = true;
			}
			return any_updates;
		}

		private void onDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
		{
			download_progress = e.ProgressPercentage;
		}

		private void onDownloadComplete(object sender, AsyncCompletedEventArgs e)
		{
			lock (e.UserState)
			{
				Monitor.Pulse(e.UserState);
			}
		}

		private void ensureStandBinDirExists()
		{
			if (!Directory.Exists(stand_dir))
			{
				Directory.CreateDirectory(stand_dir);
			}
			if (!Directory.Exists(stand_dir + "\\Bin"))
			{
				Directory.CreateDirectory(stand_dir + "\\Bin");
			}
		}

		private bool downloadStandDll()
		{
			bool success = true;
			InfoText.Text = "Downloading Stand " + versions[1] + "...";
			download_progress = 0;
			progressBar1.Show();
			var t = Task.Run(() =>
			{
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += onDownloadProgress;
				webClient.DownloadFileCompleted += onDownloadComplete;
				var syncObject = new object();
				lock (syncObject)
				{
					webClient.DownloadFileAsync(new Uri("https://stand.gg/Stand%20" + versions[1] + ".dll"), stand_dll + ".tmp", syncObject);
					Monitor.Wait(syncObject);
				}
			});
			do
			{
				progressBar1.Value = download_progress;
			}
			while (!t.Wait(20));
			File.Move(stand_dll + ".tmp", stand_dll);
			if (new FileInfo(stand_dll).Length < 1024)
			{
				File.Delete(stand_dll);
				showMessageBox("It looks like the DLL download has failed. Ensure you have no anti-virus program interfering.");
				success = false;
			}
			progressBar1.Hide();
			return success;
		}

		private void ProcessScanTimer_Tick(object sender, EventArgs e)
		{
			if (updateGtaPid())
			{
				processGtaPidUpdate(can_auto_inject);
			}
		}

		private bool updateGtaPid()
		{
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName == "GTA5")
				{
					if (gta_pid == process.Id)
					{
						return false;
					}
					gta_pid = process.Id;
					game_was_open = true;
					return true;
				}
			}
			AutoInjectTimer.Stop();
			var pid_changed = gta_pid != 0;
			gta_pid = 0;
			return pid_changed;
		}

		private void processGtaPidUpdate(bool proc_can_auto_inject)
		{
			var gameRunning = (gta_pid != 0);
			toggleInjectOrLaunchBtn(gameRunning);
			if (gameRunning)
			{
				if (AutoInjectCheckBox.Checked && proc_can_auto_inject)
				{
					if (Properties.Settings.Default.Advanced && AutoInjectDelaySeconds.Value > 0)
					{
						InfoText.Text = "Automatically injecting in a few seconds...";
						AutoInjectTimer.Interval = (int)AutoInjectDelaySeconds.Value * 1000;
						AutoInjectTimer.Start();
					}
					else
					{
						inject();
					}
				}
				else
				{
					InfoText.Text = "Ready to inject.";
				}
			}
			else
			{
				InfoText.Text = "Ready to inject; just start the game.";
				if (game_was_open)
				{
					game_was_open = false;
					can_auto_inject = false;
					GameClosedTimer.Start();
				}
			}
		}

		private void InjectBtn_Click(object sender, EventArgs e)
		{
			inject();
		}

		private void AutoInjectTimer_Tick(object sender, EventArgs e)
		{
			inject();
		}

		private void inject()
		{
			var failedBecauseOfAntiVirus = false;
			AutoInjectTimer.Stop();
			ProcessScanTimer.Stop();
			InjectBtn.Enabled = false;
			List<string> dlls = new List<string>();
			if (Properties.Settings.Default.Advanced)
			{
				for (int i = 0; i < DllList.Items.Count; i++)
				{
					if (DllList.Items[i].Checked)
					{
						dlls.Add(i == 0 ? stand_dll : DllList.Items[i].Text);
					}
				}
			}
			else
			{
				dlls.Add(stand_dll);
			}
			if (dlls.Contains(stand_dll) && !File.Exists(stand_dll))
			{
				ensureStandBinDirExists();
				if (!downloadStandDll())
				{
					dlls.Remove(stand_dll);
				}
			}
			InfoText.Text = "Injecting...";
			int injected = 0;
			IntPtr pHandle = OpenProcess(1082u, 1, (uint)gta_pid);
			if (pHandle == IntPtr.Zero)
			{
				Console.WriteLine("Failed to get a hold of the game's process.");
			}
			else
			{
				IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryW");
				if (procAddress == IntPtr.Zero)
				{
					Console.WriteLine("Failed to find LoadLibraryW.");
				}
				else
				{
					string temp_dir = stand_dir + "\\Bin\\Temp";
					if (!Directory.Exists(temp_dir))
					{
						Directory.CreateDirectory(temp_dir);
					}
					try
					{
						foreach (string dll in dlls)
						{
							if (!File.Exists(dll))
							{
								Console.WriteLine("Couldn't inject " + dll + " because the file doesn't exist.");
								continue;
							}
							string dll_copy = temp_dir + "\\SL_" + generateRandomString(5) + ".dll";
							File.Copy(dll, dll_copy);
							byte[] dllBytes = Encoding.Unicode.GetBytes(dll_copy);
							IntPtr baseAddress = VirtualAllocEx(pHandle, (IntPtr)null, (IntPtr)dllBytes.Length, 12288u, 64u);
							if (baseAddress == IntPtr.Zero)
							{
								Console.WriteLine("Couldn't allocate the bytes to represent " + dll);
								continue;
							}
							if (WriteProcessMemory(pHandle, baseAddress, dllBytes, (uint)dllBytes.Length, 0) == 0)
							{
								Console.WriteLine("Couldn't write " + dll_copy + " to allocated memory");
								continue;
							}
							if (CreateRemoteThread(pHandle, (IntPtr)null, IntPtr.Zero, procAddress, baseAddress, 0u, (IntPtr)null) == IntPtr.Zero)
							{
								Console.WriteLine("Failed to create remote thread for " + dll);
								continue;
							}
							injected++;
						}
					}catch(IOException)
					{
						this.Activate();
						failedBecauseOfAntiVirus = true;
						showMessageBox("Your antivirus seems to be preventing injection.\nDisable your anti virus or add an exclusion and try again.", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				CloseHandle(pHandle);
			}
			InfoText.Text = "Injected " + injected.ToString() + "/" + dlls.Count.ToString() + " DLLs.";

			if (injected == 0)
			{
				if (!any_successful_injection
					&& dlls.Count != 0
					&& !failedBecauseOfAntiVirus
					)
				{
					showMessageBox("No DLL was injected. You may need to start the Launchpad as Administrator.");
				}

				EnableReInject();
			}
			else
			{
				any_successful_injection = true;
				ReInjectTimer.Start();
			}
		}

		private static string generateRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
		}

		private DialogResult showMessageBox(string message, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
		{
			return MessageBox.Show(message, "Stand Launchpad " + launchpad_display_version, buttons, icon);
		}

		private void Launchpad_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.AutoInject = AutoInjectCheckBox.Checked;
			Properties.Settings.Default.AutoInjectDelaySeconds = (int)AutoInjectDelaySeconds.Value;
			Properties.Settings.Default.GameLauncher = ((DropDownEntry)LauncherType.SelectedItem).Id;
			saveSettings();
		}

		private void saveSettings()
		{
			Properties.Settings.Default.InjectDll = "";
			Properties.Settings.Default.CustomDll = "";
			for (int i = 0; i < DllList.Items.Count; i++)
			{
				Properties.Settings.Default.InjectDll += (DllList.Items[i].Checked ? "1" : "0");
				if (i != 0)
				{
					Properties.Settings.Default.CustomDll += DllList.Items[i].Text + "|";
				}
			}
			if (Properties.Settings.Default.CustomDll != "")
			{
				Properties.Settings.Default.CustomDll = Properties.Settings.Default.CustomDll.Substring(0, Properties.Settings.Default.CustomDll.Length - 1);
			}
			Properties.Settings.Default.Save();
		}

		private void CustomDllDialog_FileOk(object sender, CancelEventArgs e)
		{
			addDll(CustomDllDialog.FileName);
		}

		private void addDll(string path)
		{
			DllList.Items[DllList.Items.Add(path).Index].Checked = true;
		}

		private void AdvancedBtn_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Advanced = !Properties.Settings.Default.Advanced;
			updateAdvancedMode();
		}

		private void updateAdvancedMode()
		{
			if (Properties.Settings.Default.Advanced)
			{
				Width = width_advanced;
				MinimizeBox = true;
				InjectBtn.Text = "Inject";
				AutoInjectDelaySeconds.Visible = true;
				AddBtn.TabStop = true;
				RemoveBtn.TabStop = true;
				DllList.Visible = true;
			}
			else
			{
				MinimizeBox = false;
				Width = width_simple;
				InjectBtn.Text = "Inject Stand " + versions[1];
				AutoInjectDelaySeconds.Visible = false;
				AddBtn.TabStop = false;
				RemoveBtn.TabStop = false;
				DllList.Visible = false;
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			CustomDllDialog.ShowDialog();
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			removeSelectedDll();
		}

		private void removeSelectedDll()
		{
			if (DllList.SelectedItems.Count == 1)
			{
				var selectedIndex = DllList.SelectedIndices[0];
				if (selectedIndex == 0)
				{
					return;
				}

				DllList.Items.RemoveAt(selectedIndex);

				if (DllList.Items.Count > selectedIndex && DllList.Items[selectedIndex] != null)
				{
					DllList.Items[selectedIndex].Selected = true;
				}
				else
				{
					DllList.Items[selectedIndex - 1].Selected = true;
				}
			}
			else
			{
				for (var i = DllList.Items.Count - 1; i > 0; i--)
				{
					if (DllList.Items[i].Selected)
					{
						DllList.Items.RemoveAt(i);
					}
				}
			}
		}

		private void AutoInjectCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!AutoInjectCheckBox.Checked && AutoInjectTimer.Enabled)
			{
				AutoInjectTimer.Stop();
				InfoText.Text = "You may inject now.";
			}
		}

		private void GameClosedTimer_Tick(object sender, EventArgs e)
		{
			GameClosedTimer.Stop();
			can_auto_inject = true;
		}

		private void ChangelogBtn_Click(object sender, EventArgs e)
		{
			(new Changelog()).Show();
		}

		private void ReInjectTimer_Tick(object sender, EventArgs e)
		{
			ReInjectTimer.Stop();
			EnableReInject();
		}

		private void EnableReInject()
		{
			InjectBtn.Enabled = true;
			ProcessScanTimer.Start();
		}

		private void StandFolderBtn_Click(object sender, EventArgs e)
		{
			Process.Start(stand_dir);
		}

		private void UpdCheckBtn_Click(object sender, EventArgs e)
		{
			if (!checkForUpdate(true))
			{
				showMessageBox("Everything up-to-date.");
			}
			processGtaPidUpdate(false);
		}

		private void DllList_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void DllList_DragDrop(object sender, DragEventArgs e)
		{
			foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop))
			{
				addDll(file);
			}
		}

		private void DllList_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				removeSelectedDll();
			}
		}

		private void LaunchBtn_Click(object sender, EventArgs e)
		{
			switch (((DropDownEntry)LauncherType.SelectedItem).Id)
			{
				case 0:
					Process.Start("com.epicgames.launcher://apps/9d2d0eb64d5c44529cece33fe2a46482?action=launch&silent=true");
					break;
				case 1:
					Process.Start("steam://run/271590");
					break;
				case 2:
					try
					{
						using (var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Rockstar Games\\Launcher"))
						{
							var path = (string) key?.GetValue("InstallFolder");
							if (path != null)
							{
								Process.Start(path + "\\Launcher.exe", "-minmodeApp=gta5");
							}
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
					break;
			}
		}

		private void LauncherType_SelectedIndexChanged(object sender, EventArgs e)
		{
			LaunchBtn.Focus();
		}

		private void toggleInjectOrLaunchBtn(bool gameRunning)
		{
			InjectBtn.Visible = gameRunning;
			LauncherType.Visible = LaunchBtn.Visible = !gameRunning;
		}
	}
}
