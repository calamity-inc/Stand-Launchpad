namespace Stand_Launchpad
{
	partial class Launchpad
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launchpad));
			this.InjectBtn = new System.Windows.Forms.Button();
			this.ProcessScanTimer = new System.Windows.Forms.Timer(this.components);
			this.InfoText = new System.Windows.Forms.Label();
			this.AutoInjectCheckBox = new System.Windows.Forms.CheckBox();
			this.CustomDllDialog = new System.Windows.Forms.OpenFileDialog();
			this.AdvancedBtn = new System.Windows.Forms.Button();
			this.RemoveBtn = new System.Windows.Forms.Button();
			this.UpBtn = new System.Windows.Forms.Button();
			this.DownBtn = new System.Windows.Forms.Button();
			this.AutoInjectDelaySeconds = new System.Windows.Forms.NumericUpDown();
			this.AutoInjectDelayLabel = new System.Windows.Forms.Label();
			this.AutoInjectTimer = new System.Windows.Forms.Timer(this.components);
			this.GameClosedTimer = new System.Windows.Forms.Timer(this.components);
			this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.ChanglogBtn = new System.Windows.Forms.Button();
			this.ReInjectTimer = new System.Windows.Forms.Timer(this.components);
			this.StandFolderBtn = new System.Windows.Forms.Button();
			this.UpdCheckBtn = new System.Windows.Forms.Button();
			this.DllList = new System.Windows.Forms.ListView();
			this.Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LauncherType = new System.Windows.Forms.ComboBox();
			this.dropDownEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.LaunchBtn = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.AddBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.AutoInjectDelaySeconds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dropDownEntryBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// InjectBtn
			// 
			this.InjectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.InjectBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.InjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.InjectBtn.Location = new System.Drawing.Point(12, 12);
			this.InjectBtn.Name = "InjectBtn";
			this.InjectBtn.Size = new System.Drawing.Size(208, 23);
			this.InjectBtn.TabIndex = 0;
			this.InjectBtn.Text = "Inject";
			this.InjectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InjectBtn.UseVisualStyleBackColor = false;
			this.InjectBtn.Click += new System.EventHandler(this.InjectBtn_Click);
			// 
			// ProcessScanTimer
			// 
			this.ProcessScanTimer.Interval = 1000;
			this.ProcessScanTimer.Tick += new System.EventHandler(this.ProcessScanTimer_Tick);
			// 
			// InfoText
			// 
			this.InfoText.AutoSize = true;
			this.InfoText.Location = new System.Drawing.Point(9, 153);
			this.InfoText.Name = "InfoText";
			this.InfoText.Size = new System.Drawing.Size(117, 13);
			this.InfoText.TabIndex = 9;
			this.InfoText.Text = "Checking for updates...";
			// 
			// AutoInjectCheckBox
			// 
			this.AutoInjectCheckBox.AutoSize = true;
			this.AutoInjectCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AutoInjectCheckBox.ForeColor = System.Drawing.Color.White;
			this.AutoInjectCheckBox.Location = new System.Drawing.Point(12, 41);
			this.AutoInjectCheckBox.Name = "AutoInjectCheckBox";
			this.AutoInjectCheckBox.Size = new System.Drawing.Size(202, 17);
			this.AutoInjectCheckBox.TabIndex = 4;
			this.AutoInjectCheckBox.Text = "Automatically inject when game starts.";
			this.AutoInjectCheckBox.UseVisualStyleBackColor = true;
			this.AutoInjectCheckBox.CheckedChanged += new System.EventHandler(this.AutoInjectCheckBox_CheckedChanged);
			// 
			// CustomDllDialog
			// 
			this.CustomDllDialog.Filter = "DLL files|*.dll|All files|*.*";
			this.CustomDllDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.CustomDllDialog_FileOk);
			// 
			// AdvancedBtn
			// 
			this.AdvancedBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.AdvancedBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.AdvancedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdvancedBtn.Location = new System.Drawing.Point(12, 122);
			this.AdvancedBtn.Name = "AdvancedBtn";
			this.AdvancedBtn.Size = new System.Drawing.Size(208, 23);
			this.AdvancedBtn.TabIndex = 8;
			this.AdvancedBtn.Text = "Advanced";
			this.AdvancedBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AdvancedBtn.UseVisualStyleBackColor = false;
			this.AdvancedBtn.Click += new System.EventHandler(this.AdvancedBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.RemoveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.RemoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveBtn.Location = new System.Drawing.Point(620, 12);
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(65, 23);
			this.RemoveBtn.TabIndex = 13;
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.UseVisualStyleBackColor = false;
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// UpBtn
			// 
			this.UpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.UpBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.UpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UpBtn.Location = new System.Drawing.Point(530, 12);
			this.UpBtn.Name = "UpBtn";
			this.UpBtn.Size = new System.Drawing.Size(17, 23);
			this.UpBtn.TabIndex = 15;
			this.UpBtn.Text = "↑";
			this.UpBtn.UseVisualStyleBackColor = false;
			this.UpBtn.Click += new System.EventHandler(this.UpBtn_Click);
			// 
			// DownBtn
			// 
			this.DownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.DownBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.DownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DownBtn.Location = new System.Drawing.Point(547, 12);
			this.DownBtn.Name = "DownBtn";
			this.DownBtn.Size = new System.Drawing.Size(17, 23);
			this.DownBtn.TabIndex = 16;
			this.DownBtn.Text = "↓";
			this.DownBtn.UseVisualStyleBackColor = false;
			this.DownBtn.Click += new System.EventHandler(this.DownBtn_Click);
			// 
			// AutoInjectDelaySeconds
			// 
			this.AutoInjectDelaySeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.AutoInjectDelaySeconds.ForeColor = System.Drawing.Color.White;
			this.AutoInjectDelaySeconds.Location = new System.Drawing.Point(415, 15);
			this.AutoInjectDelaySeconds.Maximum = new decimal(new int[] {
			60,
			0,
			0,
			0});
			this.AutoInjectDelaySeconds.Name = "AutoInjectDelaySeconds";
			this.AutoInjectDelaySeconds.Size = new System.Drawing.Size(45, 20);
			this.AutoInjectDelaySeconds.TabIndex = 11;
			// 
			// AutoInjectDelayLabel
			// 
			this.AutoInjectDelayLabel.AutoSize = true;
			this.AutoInjectDelayLabel.ForeColor = System.Drawing.Color.White;
			this.AutoInjectDelayLabel.Location = new System.Drawing.Point(232, 17);
			this.AutoInjectDelayLabel.Name = "AutoInjectDelayLabel";
			this.AutoInjectDelayLabel.Size = new System.Drawing.Size(181, 13);
			this.AutoInjectDelayLabel.TabIndex = 10;
			this.AutoInjectDelayLabel.Text = "Automatic Injection Delay (Seconds):";
			// 
			// AutoInjectTimer
			// 
			this.AutoInjectTimer.Interval = 1;
			this.AutoInjectTimer.Tick += new System.EventHandler(this.AutoInjectTimer_Tick);
			// 
			// GameClosedTimer
			// 
			this.GameClosedTimer.Interval = 10000;
			this.GameClosedTimer.Tick += new System.EventHandler(this.GameClosedTimer_Tick);
			// 
			// UpdateTimer
			// 
			this.UpdateTimer.Interval = 1;
			this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
			// 
			// ChanglogBtn
			// 
			this.ChanglogBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.ChanglogBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.ChanglogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChanglogBtn.ForeColor = System.Drawing.Color.White;
			this.ChanglogBtn.Location = new System.Drawing.Point(146, 64);
			this.ChanglogBtn.Name = "ChanglogBtn";
			this.ChanglogBtn.Size = new System.Drawing.Size(74, 23);
			this.ChanglogBtn.TabIndex = 6;
			this.ChanglogBtn.Text = "Changelog";
			this.ChanglogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ChanglogBtn.UseVisualStyleBackColor = false;
			this.ChanglogBtn.Click += new System.EventHandler(this.ChangelogBtn_Click);
			// 
			// ReInjectTimer
			// 
			this.ReInjectTimer.Interval = 3000;
			this.ReInjectTimer.Tick += new System.EventHandler(this.ReInjectTimer_Tick);
			// 
			// StandFolderBtn
			// 
			this.StandFolderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.StandFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.StandFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StandFolderBtn.Location = new System.Drawing.Point(12, 93);
			this.StandFolderBtn.Name = "StandFolderBtn";
			this.StandFolderBtn.Size = new System.Drawing.Size(208, 23);
			this.StandFolderBtn.TabIndex = 7;
			this.StandFolderBtn.Text = "Open Stand Folder";
			this.StandFolderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.StandFolderBtn.UseVisualStyleBackColor = false;
			this.StandFolderBtn.Click += new System.EventHandler(this.StandFolderBtn_Click);
			// 
			// UpdCheckBtn
			// 
			this.UpdCheckBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.UpdCheckBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.UpdCheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UpdCheckBtn.ForeColor = System.Drawing.Color.White;
			this.UpdCheckBtn.Location = new System.Drawing.Point(12, 64);
			this.UpdCheckBtn.Name = "UpdCheckBtn";
			this.UpdCheckBtn.Size = new System.Drawing.Size(128, 23);
			this.UpdCheckBtn.TabIndex = 5;
			this.UpdCheckBtn.Text = "Check For Updates";
			this.UpdCheckBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.UpdCheckBtn.UseVisualStyleBackColor = false;
			this.UpdCheckBtn.Click += new System.EventHandler(this.UpdCheckBtn_Click);
			// 
			// DllList
			// 
			this.DllList.AllowDrop = true;
			this.DllList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.DllList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DllList.CheckBoxes = true;
			this.DllList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.Column});
			this.DllList.ForeColor = System.Drawing.SystemColors.Window;
			this.DllList.HideSelection = false;
			this.DllList.Location = new System.Drawing.Point(235, 41);
			this.DllList.Margin = new System.Windows.Forms.Padding(6);
			this.DllList.Name = "DllList";
			this.DllList.Size = new System.Drawing.Size(450, 122);
			this.DllList.TabIndex = 14;
			this.DllList.UseCompatibleStateImageBehavior = false;
			this.DllList.View = System.Windows.Forms.View.List;
			this.DllList.DragDrop += new System.Windows.Forms.DragEventHandler(this.DllList_DragDrop);
			this.DllList.DragOver += new System.Windows.Forms.DragEventHandler(this.DllList_DragOver);
			this.DllList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DllList_KeyUp);
			// 
			// Column
			// 
			this.Column.Text = "";
			this.Column.Width = 450;
			// 
			// LauncherType
			// 
			this.LauncherType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.LauncherType.DataSource = this.dropDownEntryBindingSource;
			this.LauncherType.DisplayMember = "Name";
			this.LauncherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LauncherType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LauncherType.ForeColor = System.Drawing.SystemColors.Window;
			this.LauncherType.FormattingEnabled = true;
			this.LauncherType.ItemHeight = 13;
			this.LauncherType.Location = new System.Drawing.Point(92, 14);
			this.LauncherType.Name = "LauncherType";
			this.LauncherType.Size = new System.Drawing.Size(128, 21);
			this.LauncherType.TabIndex = 2;
			this.LauncherType.ValueMember = "Id";
			this.LauncherType.SelectedIndexChanged += new System.EventHandler(this.LauncherType_SelectedIndexChanged);
			// 
			// dropDownEntryBindingSource
			// 
			this.dropDownEntryBindingSource.DataSource = typeof(Stand_Launchpad.DropDownEntry);
			// 
			// LaunchBtn
			// 
			this.LaunchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.LaunchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.LaunchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LaunchBtn.Location = new System.Drawing.Point(12, 12);
			this.LaunchBtn.Name = "LaunchBtn";
			this.LaunchBtn.Size = new System.Drawing.Size(74, 23);
			this.LaunchBtn.TabIndex = 1;
			this.LaunchBtn.Text = "Launch";
			this.LaunchBtn.UseVisualStyleBackColor = false;
			this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(208, 23);
			this.progressBar1.TabIndex = 0;
			this.progressBar1.Visible = false;
			// 
			// AddBtn
			// 
			this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
			this.AddBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
			this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddBtn.Location = new System.Drawing.Point(567, 12);
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(47, 23);
			this.AddBtn.TabIndex = 17;
			this.AddBtn.Text = "Add";
			this.AddBtn.UseVisualStyleBackColor = false;
			// 
			// Launchpad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
			this.ClientSize = new System.Drawing.Size(694, 175);
			this.Controls.Add(this.AddBtn);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.LaunchBtn);
			this.Controls.Add(this.LauncherType);
			this.Controls.Add(this.DllList);
			this.Controls.Add(this.UpdCheckBtn);
			this.Controls.Add(this.StandFolderBtn);
			this.Controls.Add(this.ChanglogBtn);
			this.Controls.Add(this.AutoInjectDelayLabel);
			this.Controls.Add(this.AutoInjectDelaySeconds);
			this.Controls.Add(this.UpBtn);
			this.Controls.Add(this.DownBtn);
			this.Controls.Add(this.RemoveBtn);
			this.Controls.Add(this.AdvancedBtn);
			this.Controls.Add(this.AutoInjectCheckBox);
			this.Controls.Add(this.InfoText);
			this.Controls.Add(this.InjectBtn);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Launchpad";
			this.Text = "Stand Launchpad";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launchpad_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.AutoInjectDelaySeconds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dropDownEntryBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button InjectBtn;
		private System.Windows.Forms.Label InfoText;
		private System.Windows.Forms.CheckBox AutoInjectCheckBox;
		private System.Windows.Forms.OpenFileDialog CustomDllDialog;
		private System.Windows.Forms.Button AdvancedBtn;
		private System.Windows.Forms.Timer ProcessScanTimer;
		private System.Windows.Forms.Button RemoveBtn;
		private System.Windows.Forms.Button UpBtn;
		private System.Windows.Forms.Button DownBtn;
		private System.Windows.Forms.NumericUpDown AutoInjectDelaySeconds;
		private System.Windows.Forms.Label AutoInjectDelayLabel;
		private System.Windows.Forms.Timer AutoInjectTimer;
		private System.Windows.Forms.Timer GameClosedTimer;
		private System.Windows.Forms.Timer UpdateTimer;
		private System.Windows.Forms.Button ChanglogBtn;
		private System.Windows.Forms.Timer ReInjectTimer;
		private System.Windows.Forms.Button StandFolderBtn;
		private System.Windows.Forms.Button UpdCheckBtn;
		private System.Windows.Forms.ListView DllList;
		private System.Windows.Forms.ComboBox LauncherType;
		private System.Windows.Forms.BindingSource dropDownEntryBindingSource;
		private System.Windows.Forms.Button LaunchBtn;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ColumnHeader Column;
		private System.Windows.Forms.Button AddBtn;
	}
}

