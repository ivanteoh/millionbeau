using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class OrderDetailForm : Form
    {
        public OrderDetailForm()
        {
            InitializeComponent();
            productFindButton.Click += PoductFindButtonClick;
            addButton.Click += AddButtonClick;
            KeyDown += OrderDetailFormKeyDown;
        }              

        private void PoductFindButtonClick(object sender, EventArgs e)
        {
            FindProductForm findProductForm = new FindProductForm();
            findProductForm.ShowDialog(this);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
