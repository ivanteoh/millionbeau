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
            KeyDown += OrderFormKeyDown;
        }

        private BindingList<OrderDetail> orderDetails;
        private string customerId;
        private BindingSource bindingSource;
            
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
            OrderDetailForm orderDetailForm = new OrderDetailForm();
            orderDetailForm.Added += OrderDetailFormAdded;
            orderDetailForm.ShowDialog(this);
            orderDetailForm.Added -= OrderDetailFormAdded;
            
        }

        private void OrderDetailFormAdded(object sender, EventArgs e)
        {
            OrderDetailForm orderDetailForm = sender as OrderDetailForm;
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = Convert.ToInt64(orderDetailForm.ProductId, CultureInfo.InvariantCulture);
            orderDetail.Product = orderDetailForm.Product;
            orderDetail.Description = orderDetailForm.Description;
            orderDetail.ProductType = orderDetailForm.ProductType;
            orderDetail.InStock = Convert.ToInt64(orderDetailForm.InStock, CultureInfo.InvariantCulture);
            orderDetail.Price = Convert.ToDecimal(orderDetailForm.Price, CultureInfo.InvariantCulture);
            orderDetail.Quantity = Convert.ToInt64(orderDetailForm.Quantity, CultureInfo.InvariantCulture);
            orderDetail.DiscountPercent = Convert.ToDecimal(orderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
            orderDetail.TotalCost = Convert.ToDecimal(orderDetailForm.TotalCost, CultureInfo.InvariantCulture);

            orderDetails.Add(orderDetail);
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
