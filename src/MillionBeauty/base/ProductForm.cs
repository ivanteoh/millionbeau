using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            nameRegexTextBox.Validating += NameRegexTextBoxValidating;

            inStockRegexTextBox.Text = Properties.Resources.Zero;
            inStockRegexTextBox.CustomPattern = Properties.Resources.NumberPattern;
            inStockRegexTextBox.Validating += InStockRegexTextBoxValidating;

            priceRegexTextBox.Text = Properties.Resources.Zero;
            priceRegexTextBox.CustomPattern = Properties.Resources.CurrencyPattern;
            priceRegexTextBox.Validating += PriceRegexTextBoxValidating;

            okButton.Click += new EventHandler(OkButtonClick);
            KeyDown += new KeyEventHandler(ProductFormKeyDown);
            Load += new EventHandler(ProductFormLoad);
            Closing += new CancelEventHandler(ProductFormClosing);
        }

        private bool gotError;

        private void NameRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nameRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    Properties.Resources.ErrorProductName,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                nameRegexTextBox.Text = nameRegexTextBox.OldValue;
            }
        }

        private void InStockRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!inStockRegexTextBox.Valid || String.IsNullOrEmpty(inStockRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    Properties.Resources.ErrorStockQuantity,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                inStockRegexTextBox.Text = inStockRegexTextBox.OldValue;
            }
        }

        private void PriceRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!priceRegexTextBox.Valid || String.IsNullOrEmpty(priceRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    Properties.Resources.ErrorPriceFormat,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                priceRegexTextBox.Text = priceRegexTextBox.OldValue;
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
            set { idTextLabel.Text = value; }
        }

        internal protected string Product
        {
            get { return nameRegexTextBox.Text; }
            set { nameRegexTextBox.Text = value; }
        }

        internal protected string Description
        {
            get { return descriptionRegexTextBox.Text; }
            set { descriptionRegexTextBox.Text = value; }
        }

        internal protected string ProductType
        {
            get { return typeRegexTextBox.Text; }
            set { typeRegexTextBox.Text = value; }
        }

        internal protected string Specification
        {
            get { return specificationRegexTextBox.Text; }
            set { specificationRegexTextBox.Text = value; }
        }

        internal protected string InStock
        {
            get { return inStockRegexTextBox.Text; }
            set { inStockRegexTextBox.Text = value; }
        }

        internal protected string Price
        {
            get { return priceRegexTextBox.Text; }
            set { priceRegexTextBox.Text = value; }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            gotError = false;

            // Make sure Title of Courtesy and Name can not be empty.
            if (string.IsNullOrEmpty(Product) ||
                string.IsNullOrEmpty(InStock) ||
                string.IsNullOrEmpty(Price))
            {
                // Error
                MessageBox.Show(
                    Properties.Resources.ErrorNameEmpty,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                gotError = true;
            }
            else
            {
                EnterProductInfo();
            }
        }

        protected virtual void EnterProductInfo()
        {
        }

        private void ProductFormKeyDown(object sender, KeyEventArgs e)
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

        private void ProductFormLoad(object sender, EventArgs e)
        {
            FormLoad();
        }

        internal protected virtual void FormLoad()
        {
        }

        private void ProductFormClosing(object sender, CancelEventArgs e)
        {
            if (gotError)
            {
                e.Cancel = true;
                gotError = false;
            }
        }
    }
}
