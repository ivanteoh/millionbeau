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
            okButton.Click += OkButtonClick;
            cancelButton.Click += CancelButtonClick;
            editButton.Click += EditButtonClick;
            saveButton.Click += SaveButtonClick;
            Load += OptionsFormLoad;
        }
        
        private bool forceRestart;

        private void OptionsFormLoad(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.GotDatabase)
            {
                forceRestart = true;
            }
            databaseLabel.Text = Properties.Settings.Default.Database;

            nameTextBox.Text = Properties.Settings.Default.CompanyName;
            numberTextBox.Text = Properties.Settings.Default.CompanyNumber;
            contactTextBox.Text = Properties.Settings.Default.CompanyContact;
            EnableTextBox(false);
        }

        private void NewButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            saveFileDialog.Title = Properties.Resources.SaveFileTitle;
            saveFileDialog.Filter = Properties.Resources.FileFilter;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveFileDialog.FileName))
                {
                    File.Delete(saveFileDialog.FileName);
                }

                string connectionString = string.Format(CultureInfo.InvariantCulture, Properties.Resources.DataSource, saveFileDialog.FileName);
                Core.NewDatabase(connectionString);

                if (forceRestart || MessageBox.Show(
                    Properties.Resources.RestartApplication, 
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
            openFileDialog.Title = Properties.Resources.OpenFileTitle;
            openFileDialog.Filter = Properties.Resources.FileFilter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    Properties.Resources.RestartLoadDatabase, 
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

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            if (keyTextBox.Text == Properties.Settings.Default.Key)
            {
                if (enterTextBox.Text == reEnterTextBox.Text)
                {
                    Properties.Settings.Default.Key = enterTextBox.Text;
                    Properties.Settings.Default.Save();

                    MessageBox.Show(
                    Properties.Resources.PasswordChanged,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    keyTextBox.Text = string.Empty;
                    enterTextBox.Text = string.Empty;
                    reEnterTextBox.Text = string.Empty;
                }
                else 
                {
                    MessageBox.Show(
                    Properties.Resources.ErrorReenterPassword,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    enterTextBox.Text = string.Empty;
                    reEnterTextBox.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show(this,
                    Properties.Resources.ErrorWrongPassword,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                keyTextBox.Text = string.Empty;
            }
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            EnterKeyForm enterKeyForm = new EnterKeyForm();
            if (enterKeyForm.ShowDialog(this) == DialogResult.OK)
            {
                if (enterKeyForm.Key == Properties.Settings.Default.Key)
                {
                    EnableTextBox(true);
                }
                else
                {
                    MessageBox.Show(
                        Properties.Resources.ErrorWrongPassword,
                        Properties.Resources.Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign &
                        MessageBoxOptions.RtlReading);
                }
            }    
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanyName = nameTextBox.Text;
            Properties.Settings.Default.CompanyNumber = numberTextBox.Text;
            Properties.Settings.Default.CompanyContact = contactTextBox.Text;
            Properties.Settings.Default.Save();
            EnableTextBox(false);         
        }

        private void EnableTextBox(bool isEnable)
        {
            nameTextBox.Enabled = isEnable;
            numberTextBox.Enabled = isEnable;
            contactTextBox.Enabled = isEnable;
            saveButton.Enabled = isEnable;
            editButton.Enabled = !isEnable;
        }
    }
}
