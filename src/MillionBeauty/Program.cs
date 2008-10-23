using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // This checks if another instance of this application is running. 
            // If true, a message box is pop up. 
            if (SingleInstance.IsAlreadyRunning())
            {
                string message = string.Format(CultureInfo.InvariantCulture, Properties.Resources.SingleInstanceMessage, Properties.Resources.Title);
                MessageBox.Show(message, 
                    Properties.Resources.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & 
                    MessageBoxOptions.RtlReading);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Properties.Settings.Default.Reload();
            }
            catch (ConfigurationErrorsException ex)
            { //(requires System.Configuration)
                string filename = ((ConfigurationErrorsException)ex.InnerException).Filename;

                if (MessageBox.Show(Properties.Resources.Title +
                    " has detected that your" +
                    " user settings file has become corrupted. " +
                    "This may be due to a crash or improper exiting" +
                    " of the program. " +
                    Properties.Resources.Title +
                    " must reset your " +
                    "user settings in order to continue.\n\nClick" +
                    " Yes to reset your user settings and continue.\n\n" +
                    "Click No if you wish to attempt manual repair" +
                    " or to rescue information before proceeding.",
                    "Corrupt user settings",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading) ==
                    DialogResult.Yes)
                {
                    File.Delete(filename);
                    Properties.Settings.Default.Reload();
                    // you could optionally restart the app instead
                }
                else
                {
                    Process.GetCurrentProcess().Kill();
                    // avoid the inevitable crash
                }
            }

#if (!DEBUG)          
            if (Properties.Settings.Default.GotDatabase)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Properties.Settings.Default.Upgrade();
                Application.Run(new DatabaseForm());
            }
#else
            // Debug code: Straight away run main form
            Properties.Settings.Default.Database = @"D:\work\Data\MillionBeautyDB.s3db";
            Application.Run(new MainForm());
#endif
        }
    }
}
