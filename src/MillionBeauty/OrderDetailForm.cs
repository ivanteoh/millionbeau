using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    public partial class OrderDetailForm : Form
    {
        public event EventHandler Added;

        public OrderDetailForm()
        {
            InitializeComponent();
            productFindButton.Click += PoductFindButtonClick;

            quantityRegexTextBox.Text = "0";
            quantityRegexTextBox.CustomPattern = @"^\d+$";
            quantityRegexTextBox.Validating += QuantityRegexTextBoxValidating;

            discountRegexTextBox.Text = "0";
            discountRegexTextBox.CustomPattern = @"^\d+([-+.]\d+)?$";
            discountRegexTextBox.Validating += DiscountRegexTextBoxValidating;

            totalCostTextBox.Text = "0";
            addButton.Click += AddButtonClick;
            KeyDown += OrderDetailFormKeyDown;
        }

        private string productId;
        private string originalInStock;

        internal string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        internal string Product
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        internal string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }

        internal string ProductType
        {
            get { return typeTextBox.Text; }
            set { typeTextBox.Text = value; }
        }

        internal string InStock
        {
            get { return inStockTextBox.Text; }
            set { inStockTextBox.Text = value; }
        }

        internal string Price
        {
            get { return priceTextBox.Text; }
            set { priceTextBox.Text = value; }
        }

        internal string Quantity
        {
            get { return quantityRegexTextBox.Text; }
            set { quantityRegexTextBox.Text = value; }
        }

        internal string DiscountPercent
        {
            get { return discountRegexTextBox.Text; }
            set { discountRegexTextBox.Text = value; }
        }

        internal string TotalCost
        {
            get { return totalCostTextBox.Text; }
            set { totalCostTextBox.Text = value; }
        }        

        private void PoductFindButtonClick(object sender, EventArgs e)
        {
            FindProductForm findProductForm = new FindProductForm();
            findProductForm.ProductSelected += FindProductFormProductSelected;
            findProductForm.ShowDialog(this);
            findProductForm.ProductSelected -= FindProductFormProductSelected;
        }

        private void FindProductFormProductSelected(object sender, EventArgs e)
        {
            FindProductForm findProductForm = sender as FindProductForm;
            productId = findProductForm.Id;
            nameTextBox.Text = findProductForm.Product;
            descriptionTextBox.Text = findProductForm.Description;
            typeTextBox.Text = findProductForm.ProductType;
            inStockTextBox.Text = findProductForm.InStock;
            originalInStock = findProductForm.InStock;
            priceTextBox.Text = findProductForm.Price;
        }

        private void QuantityRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!quantityRegexTextBox.Valid || String.IsNullOrEmpty(quantityRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Price has to be price format and can not be empty.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                quantityRegexTextBox.Text = quantityRegexTextBox.OldValue;
            }
            else 
            {
                Int64 quantity = Convert.ToInt64(quantityRegexTextBox.Text, CultureInfo.InvariantCulture);
                Int64 inStock = Convert.ToInt64(originalInStock, CultureInfo.InvariantCulture);
                if (quantity > inStock)
                {
                    // Error
                    e.Cancel = true;
                    MessageBox.Show(
                        "Quantity can not be more then in stock quantity.",
                        Properties.Resources.Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    quantityRegexTextBox.Text = quantityRegexTextBox.OldValue;
                }
                else
                {
                    Int64 left = inStock - quantity;
                    inStockTextBox.Text = left.ToString(CultureInfo.InvariantCulture);
                    Decimal price = Convert.ToDecimal(priceTextBox.Text, CultureInfo.InvariantCulture);
                    Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                    Decimal result = quantity * price * (100 - discount) / 100;
                    totalCostTextBox.Text = Decimal.Round(result, 2).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private void DiscountRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!discountRegexTextBox.Valid || String.IsNullOrEmpty(discountRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Discount has to be percentage format and can not be empty.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                discountRegexTextBox.Text = discountRegexTextBox.OldValue;
            }
            else
            {
                Int64 quantity = Convert.ToInt64(quantityRegexTextBox.Text, CultureInfo.InvariantCulture);
                Decimal price = Convert.ToDecimal(priceTextBox.Text, CultureInfo.InvariantCulture);
                Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                Decimal result = quantity * price * (100 - discount) / 100;
                totalCostTextBox.Text = Decimal.Round(result, 2).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = Added;
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }

            Close();
        }

        private void OrderDetailFormKeyDown(object sender, KeyEventArgs e)
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
    }
}
