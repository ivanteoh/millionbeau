using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
namespace MillionBeauty
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            newButton.Click += NewButtonClick;
            loadButton.Click += LoadButtonClick;
            Load += DatabaseFormLoad;
        }

        private bool forceRestart;

        private void DatabaseFormLoad(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.GotDatabase)
            {
                forceRestart = true;
            }
            databaseLabel.Text = Properties.Settings.Default.Database;
        }

        private void NewButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            saveFileDialog.Title = "New Million Beauty Data File";
            saveFileDialog.Filter = "Million Beauty Data files (*.s3db)|*.s3db|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                string connectionString = string.Format(CultureInfo.InvariantCulture, "data source=\"{0}\"", saveFileDialog.FileName);
                Core.NewDatabase(connectionString);

                if (forceRestart || MessageBox.Show(
                    "Do you want to restart the application with this new database", 
                    Properties.Resources.Title, 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading) == 
                    DialogResult.Yes)
                {
                    Properties.Settings.Default.GotDatabase = true;
                    Properties.Settings.Default.Database = saveFileDialog.FileName;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }    
            }
            saveFileDialog.Dispose();   
        }

        private void LoadButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog.Title = "Open Million Beauty Data File";
            openFileDialog.Filter = "Million Beauty Data files (*.s3db)|*.s3db|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "The application will restart and load this new database", 
                    Properties.Resources.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                Properties.Settings.Default.GotDatabase = true;
                Properties.Settings.Default.Database = openFileDialog.FileName;
                Properties.Settings.Default.Save();
                Application.Restart();                   
            }
            openFileDialog.Dispose();    
        }  
    }
}
