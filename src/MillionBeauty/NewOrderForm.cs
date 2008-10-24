using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
            customerPickButton.Click += CustomerPickButtonClick;
            
        }

        private void CustomerPickButtonClick(object sender, EventArgs e)
        {
            PickCustomerForm pickCustomerForm = new PickCustomerForm();
            pickCustomerForm.ShowDialog(this);
        }
    }
}
