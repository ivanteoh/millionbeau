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
            Text = "Order";
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
            EditView();
        }

        private void ViewOrderFormDelete(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OrderId))
                return;

            string deleteQuery = string.Format(CultureInfo.InvariantCulture, "Are you sure you want to delete order {0}", OrderId);
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
