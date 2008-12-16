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
            Text = Properties.Resources.AddNewCustomer;
        }

        internal protected override void FormLoad()
        {
            HideIdLabel();            
        }

        protected override void EnterCustomerInfo()
        {
            DatabaseBuilder.Instance.InsertCustomer(
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
