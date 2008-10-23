using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    class InsertCustomerForm : CustomerForm
    {
        public InsertCustomerForm()
            : base()
        {
            Text = "Add New Customer";
        }

        internal protected override void FormLoad()
        {
            HideIdLabel();            
        }

        protected override void EnterCustomerInfo()
        {
            SQLiteDB.Instance.InsertCustomer(
                TitleOfCourtesy,
                CustomerName,
                Address,
                Postcode,
                State,
                Phone,
                Company);            
        }
    }
}
