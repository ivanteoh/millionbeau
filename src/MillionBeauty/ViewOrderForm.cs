using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace MillionBeauty
{
    class ViewOrderForm : OrderForm
    {
        public ViewOrderForm()
            : base()
        {
            Text = Properties.Resources.Order;
            Edit += ViewOrderFormEdit;
            Delete += ViewOrderFormDelete;
            Save += ViewOrderFormSave;
        }        

        internal protected override void FormLoad()
        {
            ReadOnly();
            AllowEdit();
        }

        private void ViewOrderFormEdit(object sender, EventArgs e)
        {
            EnterKeyForm enterKeyForm = new EnterKeyForm();
            if (enterKeyForm.ShowDialog(this) == DialogResult.OK)
            {
                if (DatabaseBuilder.Instance.CompareDefaultStrongKey(enterKeyForm.Key))
                {
                    EditView();
                }
                else
                {
                    MessageBox.Show(
                        Properties.Resources.ErrorWrongPassword,
                        Properties.Resources.Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign &
                        MessageBoxOptions.RtlReading);
                }
            }    
        }

        private void ViewOrderFormDelete(object sender, EventArgs e)
        {
            EnterKeyForm enterKeyForm = new EnterKeyForm();
            if (enterKeyForm.ShowDialog(this) == DialogResult.OK)
            {
                if (DatabaseBuilder.Instance.CompareDefaultStrongKey(enterKeyForm.Key))
                {
                    if (string.IsNullOrEmpty(OrderId))
                        return;

                    string deleteQuery = string.Format(CultureInfo.InvariantCulture, Properties.Resources.DeleteOrder, OrderId);
                    DialogResult result = MessageBox.Show(
                        deleteQuery, Properties.Resources.Title,
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2,
                        MessageBoxOptions.RightAlign &
                        MessageBoxOptions.RtlReading);
                    if (result == DialogResult.OK)
                    {
                        DatabaseBuilder.Instance.DeleteOrder(OrderId);
                        Close();
                    } 
                }
                else
                {
                    MessageBox.Show(
                        Properties.Resources.ErrorWrongPassword, 
                        Properties.Resources.Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign &
                        MessageBoxOptions.RtlReading);
                }
            }            
        }

        private void ViewOrderFormSave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OrderId))
                return;

            BindingList<OrderDetail> orderDetails = OrderDetailsSource as BindingList<OrderDetail>;

            DatabaseBuilder.Instance.UpdateOrder(OrderId, CustomerId, SalePerson, Total, Discount, GrandTotal);
            DatabaseBuilder.Instance.UpdateOrderDetail(OrderId, orderDetails);

            ReadOnly();            
        }
    }
}
