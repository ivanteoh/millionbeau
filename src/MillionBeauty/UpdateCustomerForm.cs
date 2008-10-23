using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class UpdateCustomerForm : CustomerForm
    {
        public UpdateCustomerForm()
            : base()
        {
            Text = "Update Customer Info";
        }

        protected override void EnterCustomerInfo()
        {
            SQLiteDB.Instance.UpdateCustomer(
                Id,
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
