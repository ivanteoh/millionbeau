using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;

namespace MillionBeauty
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            Text = String.Format(CultureInfo.InvariantCulture, Properties.Resources.About, AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format(CultureInfo.InvariantCulture, Properties.Resources.Version, AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            textBoxDescription.Text = AssemblyDescription;

            newButton.Click += NewButtonClick;
            loadButton.Click += LoadButtonClick;
            okButton.Click += OkButtonClick;
            cancelButton.Click += CancelButtonClick;
            editButton.Click += EditButtonClick;
            saveButton.Click += SaveButtonClick;
            closeButton.Click += CloseButtonClick;
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

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        #region Assembly Attribute Accessors
        /// <summary>
        /// Gets the assembly title name.
        /// </summary>
        /// <value>The assembly title name.</value>
        public static string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!String.IsNullOrEmpty(titleAttribute.Title))
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>The assembly version.</value>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        /// <value>The assembly description.</value>
        public static string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        /// <value>The assembly product.</value>
        public static string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        /// <value>The assembly copyright.</value>
        public static string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion
    }
}
