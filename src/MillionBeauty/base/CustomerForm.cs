using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();

            titleComboBox.SelectedIndex = 0;
            nameRegexTextBox.Validating += NameRegexTextBoxValidating;
            okButton.Click += new EventHandler(OkButtonClick);
            KeyDown += new KeyEventHandler(CustomerFormKeyDown);
            Load += new EventHandler(CustomerFormLoad);
            Closing += new CancelEventHandler(CustomerFormClosing);
        }        

        private bool gotError;

        private void NameRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nameRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Customer name can not be empty.", 
                    Properties.Resources.Title,
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, 
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                nameRegexTextBox.Text = nameRegexTextBox.OldValue;
            } 
        }        

        protected void HideIdLabel()
        {
            idLabel.Hide();
            idTextLabel.Hide();
        }

        internal protected string Id
        {
            get { return idTextLabel.Text; }
            set { idTextLabel.Text = value;}
        }

        internal protected string TitleOfCourtesy 
        {
            get { return titleComboBox.Text; }
            set { titleComboBox.Text = value; }
        }

        internal protected string CustomerName
        {
            get { return nameRegexTextBox.Text; }
            set { nameRegexTextBox.Text = value; }
        }

        internal protected string Address
        {
            get { return addressRegexTextBox.Text; }
            set { addressRegexTextBox.Text = value; }
        }

        internal protected string Postcode
        {
            get { return postcodeRegexTextBox.Text; }
            set { postcodeRegexTextBox.Text = value; }
        }

        internal protected string State
        {
            get { return stateRegexTextBox.Text; }
            set { stateRegexTextBox.Text = value; }
        }

        internal protected string Phone
        {
            get { return phoneRegexTextBox.Text; }
            set { phoneRegexTextBox.Text = value; }
        }

        internal protected string Company
        {
            get { return companyRegexTextBox.Text; }
            set { companyRegexTextBox.Text = value; }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            gotError = false;

            // Make sure Title of Courtesy and Name can not be empty.
            if (string.IsNullOrEmpty(CustomerName))
            {
                // Error
                MessageBox.Show(
                    "Customer name can not be empty.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1, 
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                gotError = true;
            }
            else
            {
                EnterCustomerInfo();
            }
        }

        protected virtual void EnterCustomerInfo()
        {
        }

        private void CustomerFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void CustomerFormLoad(object sender, EventArgs e)
        {
            FormLoad();
        }

        internal protected virtual void FormLoad()
        {
        }

        private void CustomerFormClosing(object sender, CancelEventArgs e)
        {
            if (gotError)
            {
                e.Cancel = true;
                gotError = false;
            }
        }
    }
}
