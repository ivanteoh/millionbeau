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
    public partial class OrderForm : Form
    {
        public event EventHandler Saved;

        public OrderForm()
        {
            InitializeComponent();

            printButton.Enabled = false;

            totalTextBox.Text = "0";
            discountRegexTextBox.Text = "0";
            grandTotalTextBox.Text = "0";

            discountRegexTextBox.CustomPattern = @"^\d+([-+.]\d+)?$";
            discountRegexTextBox.Validating += DiscountRegexTextBoxValidating;

            customerFindButton.Click += CustomerPickButtonClick;
            orderDetailsControl.AddButtonClicked += OrderDetailsControlAddButtonClicked;
            orderDetailsControl.EnterKeyDowned += OrderDetailsControlEnterKeyDowned;
            orderDetailsControl.DeleteKeyDowned += OrderDetailsControlDeleteKeyDowned;

            saveButton.Click += SaveButtonClick;
            printButton.Click += PrintButtonClick;
            KeyDown += OrderFormKeyDown;
            Load += OrderFormLoad;
        }

        private bool viewOnly;
        private string customerId;

        #region Properties
        internal protected string OrderId 
        {
            get { return recordTextBox.Text; }
            set { recordTextBox.Text = value; }
        }

        internal protected string Year 
        {
            get { return yearTextBox.Text; }
            set { yearTextBox.Text = value; }
        }

        internal protected string OrderDate 
        {
            get { return dateTextBox.Text; }
            set { dateTextBox.Text = value; }
        }

        internal protected string OrderTime
        {
            get { return timeTextBox.Text; }
            set { timeTextBox.Text = value; }
        }

        internal protected string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        internal protected string CustomerTitle
        {
            get { return customerTitleTextBox.Text; }
            set { customerTitleTextBox.Text = value; }
        }

        internal protected string CustomerName
        {
            get { return customerNameTextBox.Text; }
            set { customerNameTextBox.Text = value; }
        }

        internal protected string Address
        {
            get { return customerAddressTextBox.Text; }
            set { customerAddressTextBox.Text = value; }
        }

        internal protected string Postcode
        {
            get { return customerPostcodeTextBox.Text; }
            set { customerPostcodeTextBox.Text = value; }
        }

        internal protected string State
        {
            get { return customerStateTextBox.Text; }
            set { customerStateTextBox.Text = value; }
        }

        internal protected string Phone
        {
            get { return customerPhoneTextBox.Text; }
            set { customerPhoneTextBox.Text = value; }
        }

        internal protected string Company
        {
            get { return customerCompanyTextBox.Text; }
            set { customerCompanyTextBox.Text = value; }
        }

        internal protected string SalePerson 
        {
            get { return salesPersonTextBox.Text; }
            set { salesPersonTextBox.Text = value;          }
        }

        internal protected string Total
        { 
            get { return totalTextBox.Text; }
            set { totalTextBox.Text = value; }
        }

        internal protected string Discount 
        {
            get { return discountRegexTextBox.Text; }
            set { discountRegexTextBox.Text = value; }
        }

        internal protected string GrandTotal
        {
            get { return grandTotalTextBox.Text; }
            set { grandTotalTextBox.Text = value; }
        }

        internal protected object OrderDetailsSource
        {
            get { return orderDetailsControl.DataSetSource; }
            set { orderDetailsControl.DataSetSource = value; }
        }

        internal protected DataGridViewRow OrderDetailSelectedRow
        {
            get { return orderDetailsControl.SelectedRow; } 
        }

        #endregion Properties

        protected void ReadOnly()
        {
            viewOnly = true;
            customerFindButton.Enabled = false;         
            salesPersonTextBox.Enabled = false;
            discountRegexTextBox.ReadOnly = true;
            saveButton.Enabled = false;
            printButton.Enabled = true;
            
            orderDetailsControl.ReadOnly();
        }

        private void OrderFormLoad(object sender, EventArgs e)
        {
            FormLoad();
        }

        internal protected virtual void FormLoad()
        {
        }
            
        private void CustomerPickButtonClick(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                CustomerPickButtonClicked();
            }
        }

        internal protected virtual void CustomerPickButtonClicked()
        {
        }        

        #region Order Details Control Event Handlers
        private void OrderDetailsControlAddButtonClicked(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsInserted();
            }
        }

        internal protected virtual void OrderDetailsInserted()
        {
        }          

        private void OrderDetailsControlEnterKeyDowned(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsUpdated();
            }
        }

        internal protected virtual void OrderDetailsUpdated()
        {
        }         

        private void OrderDetailsControlDeleteKeyDowned(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsDeleted();
            }
        }

        internal protected virtual void OrderDetailsDeleted()
        {
        }

        protected void DeleteOrderDetailRow(DataGridViewRow selectedRow)
        {
            orderDetailsControl.DeleteRow(selectedRow);
        }

        #endregion Order Details Control Event Handlers

        private void DiscountRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!discountRegexTextBox.Valid || String.IsNullOrEmpty(discountRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Discount has to be RM format and can not be empty.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                discountRegexTextBox.Text = discountRegexTextBox.OldValue;
            }
            else
            {
                Decimal totalPrice = Convert.ToDecimal(totalTextBox.Text, CultureInfo.InvariantCulture);
                Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                Decimal result = totalPrice - discount;

                discountRegexTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", discountRegexTextBox.Text);
                grandTotalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Decimal.Round(result, 2));
            }
        } 

        protected void UpdateTotalPrice(BindingList<OrderDetail> orderDetails)
        {
            Decimal totalPrice = new decimal();
            totalPrice = 0;

            foreach (OrderDetail orderItem in orderDetails)
            {
                totalPrice = totalPrice + orderItem.TotalCost;
            }
            Decimal roundTotalPrice = decimal.Round(totalPrice, 2);
            totalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", roundTotalPrice);

            string discountText = discountRegexTextBox.Text;

            Decimal grandTotal = roundTotalPrice - Convert.ToDecimal(discountText, CultureInfo.InvariantCulture);

            discountRegexTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", discountText);

            grandTotalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Decimal.Round(grandTotal, 2));
        }

        private void OrderFormKeyDown(object sender, KeyEventArgs e)
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

        private void SaveButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = Saved;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }            
        } 

        private void PrintButtonClick(object sender, EventArgs e)
        {            
        }           
    }
}
