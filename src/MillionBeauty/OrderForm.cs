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
            
        private void CustomerPickButtonClick(object sender, EventArgs e)
        {
            FindCustomerForm pickCustomerForm = new FindCustomerForm();
            pickCustomerForm.ShowDialog(this);
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
