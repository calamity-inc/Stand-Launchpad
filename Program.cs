using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stand_Launchpad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Launchpad());
            }
            catch (Exception config_ex) when (config_ex is ConfigurationException)
            {
                Console.WriteLine($"Configuration error: {config_ex.Message}");
                
                string path;
                
                if (((ConfigurationException)config_ex).Filename != null)   // Lazy hack that should always work.
                {
                    path = ((ConfigurationException)config_ex).Filename;
                }
                else
                {
                    path = ((ConfigurationException)config_ex.InnerException).Filename;
                }

                try
                {
                    File.Delete(path); // delete configuration as corruption has happened and we need to reinitialise the Launchpad
                    
                    // Restart the Launchpad so the user sees nothing but a normal behaviour
                    Application.Restart();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong when deleting the corrupted configuration {ex.Message}");

                    // In this situation we're dead here, we inform the user something really bad has happened
                    MessageBox.Show("Something really bad happened with your configuration, you should delete it inside %appdata%\\Local\\Calamity,_Inc\\. The application will now close.", "Error");
                    Environment.Exit(1);
                }
            }
        }
    }
}
