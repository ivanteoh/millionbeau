using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class ViewOrderForm : OrderForm
    {
        public ViewOrderForm()
            : base()
        {
            Text = "Order";
        }

        internal protected override void FormLoad()
        {
            ReadOnly();
        }        
    }
}
