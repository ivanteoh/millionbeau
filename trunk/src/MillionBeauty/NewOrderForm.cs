using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace MillionBeauty
{
    class NewOrderForm : OrderForm
    {
        public NewOrderForm()
            : base()
        {
            Text = "New Order";            
            Save += NewOrderFormSave;            
        }    

        private void NewOrderFormSave(object sender, EventArgs e)
        {
            BindingList<OrderDetail> orderDetails = OrderDetailsSource as BindingList<OrderDetail>;

            DatabaseBuilder.Instance.InsertOrder(CustomerId, SalePerson, Total, Discount, GrandTotal);
            object[] orderInfo = DatabaseBuilder.Instance.LastOrder();
            OrderId = orderInfo[0].ToString();
            Year = orderInfo[1].ToString();
            OrderDate = orderInfo[2].ToString();
            OrderTime = orderInfo[3].ToString();
            DatabaseBuilder.Instance.InsertOrderDetail(OrderId, orderDetails);

            ReadOnly();
        }        
    }
}
