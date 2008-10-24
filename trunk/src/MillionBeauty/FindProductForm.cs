using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class FindProductForm : DataViewForm
    {
        public FindProductForm()
            : base()
        {
            this.Text = "Select Product";
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
