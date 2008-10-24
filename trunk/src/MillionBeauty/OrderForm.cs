using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            customerFindButton.Click += CustomerPickButtonClick;
            dataGridViewControl.AddButtonClicked += DataGridViewControlAddButtonClicked;
            KeyDown += OrderFormKeyDown;
        }

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

        private void DataGridViewControlAddButtonClicked(object sender, EventArgs e)
        {
            OrderDetailForm orderDetailForm = new OrderDetailForm();
            orderDetailForm.ShowDialog(this);
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
