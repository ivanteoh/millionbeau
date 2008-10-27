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
        public OrderForm()
        {
            InitializeComponent();

            printButton.Enabled = false;

            totalTextBox.Text = "0";
            discountRegexTextBox.Text = "0";
            grandTotalTextBox.Text = "0";

            discountRegexTextBox.CustomPattern = @"^\d+([-+.]\d+)?$";
            discountRegexTextBox.Validating += DiscountRegexTextBoxValidating;

            orderDetails = new BindingList<OrderDetail>();
            orderDetailsControl.DataSetSource = orderDetails;
            customerFindButton.Click += CustomerPickButtonClick;
            orderDetailsControl.AddButtonClicked += OrderDetailsControlAddButtonClicked;
            orderDetailsControl.EnterKeyDowned += OrderDetailsControlEnterKeyDowned;
            orderDetailsControl.DeleteKeyDowned += new EventHandler(OrderDetailsControlDeleteKeyDowned);
            saveButton.Click += SaveButtonClick;
            printButton.Click += PrintButtonClick;
            KeyDown += OrderFormKeyDown;
        }

        private BindingList<OrderDetail> orderDetails;
        private string customerId;        
            
        private void CustomerPickButtonClick(object sender, EventArgs e)
        {
            FindCustomerForm findCustomerForm = new FindCustomerForm();
            findCustomerForm.CustomerSelected += FindCustomerFormCustomerSelected;
            findCustomerForm.ShowDialog(this);
            findCustomerForm.CustomerSelected -= FindCustomerFormCustomerSelected;
        }

        private void FindCustomerFormCustomerSelected(object sender, EventArgs e)
        {
            FindCustomerForm findCustomerForm = sender as FindCustomerForm;
            customerId = findCustomerForm.Id;
            customerTitleTextBox.Text = findCustomerForm.TitleOfCourtesy;
            customerNameTextBox.Text = findCustomerForm.CustomerName;
            customerAddressTextBox.Text = findCustomerForm.Address;
            customerPostcodeTextBox.Text = findCustomerForm.Postcode;
            customerStateTextBox.Text = findCustomerForm.State;
            customerPhoneTextBox.Text = findCustomerForm.Phone;
            customerCompanyTextBox.Text = findCustomerForm.Company;
        }

        #region Order Details Control Event Handlers
        private void OrderDetailsControlAddButtonClicked(object sender, EventArgs e)
        {
            InsertOrderDetailForm insertOrderDetailForm = new InsertOrderDetailForm();
            insertOrderDetailForm.Added += InsertOrderDetailFormAdded;
            insertOrderDetailForm.ShowDialog(this);
            insertOrderDetailForm.Added -= InsertOrderDetailFormAdded;
        }

        private void InsertOrderDetailFormAdded(object sender, EventArgs e)
        {
            InsertOrderDetailForm insertOrderDetailForm = sender as InsertOrderDetailForm;
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = Convert.ToInt64(insertOrderDetailForm.ProductId, CultureInfo.InvariantCulture);
            orderDetail.Product = insertOrderDetailForm.Product;
            orderDetail.Description = insertOrderDetailForm.Description;
            orderDetail.ProductType = insertOrderDetailForm.ProductType;
            orderDetail.InStock = Convert.ToInt64(insertOrderDetailForm.InStock, CultureInfo.InvariantCulture);
            orderDetail.Price = Convert.ToDecimal(insertOrderDetailForm.Price, CultureInfo.InvariantCulture);
            orderDetail.Quantity = Convert.ToInt64(insertOrderDetailForm.Quantity, CultureInfo.InvariantCulture);
            orderDetail.DiscountPercent = Convert.ToDecimal(insertOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
            orderDetail.TotalCost = Convert.ToDecimal(insertOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

            orderDetails.Add(orderDetail);

            UpdateTotalPrice();
        }

        private void OrderDetailsControlEnterKeyDowned(object sender, EventArgs e)
        {
            UpdateOrderDetailForm updateOrderDetailForm = new UpdateOrderDetailForm();
            updateOrderDetailForm.Inserted += UpdateOrderDetailFormInserted;
            updateOrderDetailForm.Updated += UpdateOrderDetailFormUpdated;
            updateOrderDetailForm.ShowDialog(this);
            updateOrderDetailForm.Inserted -= UpdateOrderDetailFormInserted;
            updateOrderDetailForm.Updated -= UpdateOrderDetailFormUpdated;
        }

        private void UpdateOrderDetailFormInserted(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = orderDetailsControl.SelectedRow;
            if (selectedRow != null)
            {
                UpdateOrderDetailForm updateOrderDetailForm = sender as UpdateOrderDetailForm;
                updateOrderDetailForm.ProductId = selectedRow.Cells[0].Value.ToString();
                updateOrderDetailForm.Product = selectedRow.Cells[1].Value.ToString();
                updateOrderDetailForm.Description = selectedRow.Cells[2].Value.ToString();
                updateOrderDetailForm.ProductType = selectedRow.Cells[3].Value.ToString();
                updateOrderDetailForm.InStock = selectedRow.Cells[4].Value.ToString();
                updateOrderDetailForm.Price = selectedRow.Cells[5].Value.ToString();
                updateOrderDetailForm.Quantity = selectedRow.Cells[6].Value.ToString();
                updateOrderDetailForm.DiscountPercent = selectedRow.Cells[7].Value.ToString();
                updateOrderDetailForm.TotalCost = selectedRow.Cells[8].Value.ToString();
                Int64 left = Convert.ToInt64(selectedRow.Cells[4].Value, CultureInfo.InvariantCulture) + Convert.ToInt64(selectedRow.Cells[6].Value, CultureInfo.InvariantCulture);
                updateOrderDetailForm.DefaultInStock = left;
            }            
        }

        private void UpdateOrderDetailFormUpdated(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = orderDetailsControl.SelectedRow;
            if (selectedRow != null)
            {
                UpdateOrderDetailForm updateOrderDetailForm = sender as UpdateOrderDetailForm;
                selectedRow.Cells[0].Value = Convert.ToInt64(updateOrderDetailForm.ProductId, CultureInfo.InvariantCulture);
                selectedRow.Cells[1].Value = updateOrderDetailForm.Product;
                selectedRow.Cells[2].Value = updateOrderDetailForm.Description;
                selectedRow.Cells[3].Value = updateOrderDetailForm.ProductType;
                selectedRow.Cells[4].Value = Convert.ToInt64(updateOrderDetailForm.InStock, CultureInfo.InvariantCulture);
                selectedRow.Cells[5].Value = Convert.ToDecimal(updateOrderDetailForm.Price, CultureInfo.InvariantCulture);
                selectedRow.Cells[6].Value = Convert.ToInt64(updateOrderDetailForm.Quantity, CultureInfo.InvariantCulture);
                selectedRow.Cells[7].Value = Convert.ToDecimal(updateOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
                selectedRow.Cells[8].Value = Convert.ToDecimal(updateOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

                UpdateTotalPrice();
            }      
        }

        private void OrderDetailsControlDeleteKeyDowned(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = orderDetailsControl.SelectedRow;
            if (selectedRow != null)
            {
                string index = selectedRow.Cells[0].Value.ToString();
                string deleteQuery = string.Format(CultureInfo.InvariantCulture, "Are you sure you want to delete product {0}", index);
                DialogResult result = MessageBox.Show(
                    deleteQuery, Properties.Resources.Title,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign &
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    orderDetailsControl.DeleteRow(selectedRow);
                    UpdateTotalPrice();
                }
            }            
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
                grandTotalTextBox.Text = Decimal.Round(result, 2).ToString(CultureInfo.InvariantCulture);
            }
        } 

        private void UpdateTotalPrice()
        {
            Decimal totalPrice = new decimal();
            totalPrice = 0;

            foreach (OrderDetail orderItem in orderDetails)
            {
                totalPrice = totalPrice + orderItem.TotalCost;
            }
            Decimal roundTotalPrice = decimal.Round(totalPrice, 2);
            totalTextBox.Text = roundTotalPrice.ToString();

            Decimal grandTotal = roundTotalPrice - Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);

            grandTotalTextBox.Text = Decimal.Round(grandTotal, 2).ToString();
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
            SQLiteDB.Instance.InsertOrder(customerId, salesPersonTextBox.Text, totalTextBox.Text, discountRegexTextBox.Text, grandTotalTextBox.Text);
            object[] orderInfo = SQLiteDB.Instance.LastOrder;
            recordTextBox.Text = orderInfo[0].ToString();
            yearTextBox.Text = orderInfo[1].ToString();
            dateTextBox.Text = orderInfo[2].ToString();
            timeTextBox.Text = orderInfo[3].ToString();
            saveButton.Enabled = false;
            printButton.Enabled = true;
        } 

        private void PrintButtonClick(object sender, EventArgs e)
        {            
        }           
    }
}
