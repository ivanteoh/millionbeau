using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class OrdersForm : DataViewForm
    {
        public OrdersForm()
            : base()
        {
            this.Text = "Orders List";
            AddButtonName = "Pick";
        }

        internal protected override void FormLoad()
        {
            DataSetSource = SQLiteDB.Instance.OrdersTable;
        }
    }
}
