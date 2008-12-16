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
            Text = Properties.Resources.UpdateCustomerInfo;
        }

        protected override void EnterCustomerInfo()
        {
            DatabaseBuilder.Instance.UpdateCustomer(
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
