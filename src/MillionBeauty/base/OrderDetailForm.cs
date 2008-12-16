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
        public OrderDetailForm()
        {
            InitializeComponent();

            productFindButton.Click += PoductFindButtonClick;

            quantityRegexTextBox.CustomPattern = @"^\d+$";
            quantityRegexTextBox.Validating += QuantityRegexTextBoxValidating;

            discountRegexTextBox.CustomPattern = @"^\d+([-+.]\d+)?$";
            discountRegexTextBox.Validating += DiscountRegexTextBoxValidating;
            
            addButton.Click += AddButtonClick;
            KeyDown += OrderDetailFormKeyDown;
        }

        private Int64 originalInStock;

        internal protected string AddButtonText
        {
            get { return addButton.Text; }
            set { addButton.Text = value; }
        }

        internal protected Int64 DefaultInStock
        {
            get { return originalInStock; }
            set { originalInStock = value; }
        }

        internal protected string ProductId
        {
            get { return idTextBox.Text; }
            set { idTextBox.Text = value; }
        }

        internal protected string Product
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        internal protected string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }

        internal protected string ProductType
        {
            get { return typeTextBox.Text; }
            set { typeTextBox.Text = value; }
        }

        internal protected string InStock
        {
            get { return inStockTextBox.Text; }
            set { inStockTextBox.Text = value; }
        }

        internal protected string Price
        {
            get { return priceTextBox.Text; }
            set { priceTextBox.Text = value; }
        }

        internal protected string Quantity
        {
            get { return quantityRegexTextBox.Text; }
            set { quantityRegexTextBox.Text = value; }
        }

        internal protected string Cost
        {
            get { return costTextBox.Text; }
            set { costTextBox.Text = value; }
        }  

        internal protected string DiscountPercent
        {
            get { return discountRegexTextBox.Text; }
            set { discountRegexTextBox.Text = value; }
        }

        internal protected string TotalCost
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
            idTextBox.Text = findProductForm.Id;
            nameTextBox.Text = findProductForm.Product;
            descriptionTextBox.Text = findProductForm.Description;
            typeTextBox.Text = findProductForm.ProductType;

            originalInStock = Convert.ToInt64(findProductForm.InStock, CultureInfo.InvariantCulture);
            Int64 left = originalInStock - Convert.ToInt64(quantityRegexTextBox.Text, CultureInfo.InvariantCulture);
            inStockTextBox.Text = left.ToString(CultureInfo.InvariantCulture);

            priceTextBox.Text = findProductForm.Price;
        }

        private void QuantityRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!quantityRegexTextBox.Valid || String.IsNullOrEmpty(quantityRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    Properties.Resources.ErrorPriceFormat,
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
                if (quantity > originalInStock)
                {
                    // Error
                    e.Cancel = true;
                    MessageBox.Show(
                        Properties.Resources.ErrorQuantity,
                        Properties.Resources.Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                    quantityRegexTextBox.Text = quantityRegexTextBox.OldValue;
                }
                else
                {
                    Int64 left = originalInStock - quantity;
                    inStockTextBox.Text = left.ToString(CultureInfo.InvariantCulture);
                    Decimal price = Convert.ToDecimal(priceTextBox.Text, CultureInfo.InvariantCulture);
                    Decimal cost = quantity * price;
                    costTextBox.Text = Decimal.Round(cost, 2).ToString(CultureInfo.InvariantCulture);
                    Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                    Decimal result = cost * (100 - discount) / 100;
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
                    Properties.Resources.ErrorDiscountFormat,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                discountRegexTextBox.Text = discountRegexTextBox.OldValue;
            }
            else
            {
                Decimal cost = Convert.ToDecimal(costTextBox.Text, CultureInfo.InvariantCulture);
                Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                Decimal result = cost * (100 - discount) / 100;
                totalCostTextBox.Text = Decimal.Round(result, 2).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddButtonClicked();            
        }

        protected virtual void AddButtonClicked()
        {
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
