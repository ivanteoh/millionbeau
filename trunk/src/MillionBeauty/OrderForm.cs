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

            orderDetails = new BindingList<OrderDetail>();
            orderDetailsControl.DataSetSource = orderDetails;
            customerFindButton.Click += CustomerPickButtonClick;
            orderDetailsControl.AddButtonClicked += OrderDetailsControlAddButtonClicked;
            orderDetailsControl.EnterKeyDowned += OrderDetailsControlEnterKeyDowned;
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
            }      
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
    }
}
