using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class PickCustomerForm : DataViewForm
    {
        public PickCustomerForm()
            : base()
        {
            this.Text = "Select Customer";
            AddButtonName = "Pick";
        }

        internal protected override void FormLoad()
        {
            DataSetSource = SQLiteDB.Instance.CustomersTable;            
        }

        internal protected override void AddButtonClicked()
        {
                   
        }       

        protected override void ShowEnterDialog()
        {
            base.ShowEnterDialog();
        }              
    }
}
