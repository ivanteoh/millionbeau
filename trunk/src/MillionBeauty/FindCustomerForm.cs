using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class FindCustomerForm : DataViewForm
    {
        public event EventHandler CustomerSelected;

        public FindCustomerForm()
            : base()
        {
            this.Text = Properties.Resources.SelectCustomer;
            AddButtonName = Properties.Resources.Pick;
            ReadOnly = true;
        }

        private string id;
        private string titleOfCourtesy;
        private string customerName;
        private string address;
        private string postcode;
        private string state;
        private string phone;
        private string company;

        internal string Id
        {
            get { return id; }            
        }

        internal string TitleOfCourtesy
        {
            get { return titleOfCourtesy; }            
        }

        internal string CustomerName
        {
            get { return customerName; }            
        }

        internal string Address
        {
            get { return address; }            
        }

        internal string Postcode
        {
            get { return postcode; }            
        }

        internal string State
        {
            get { return state; }            
        }

        internal string Phone
        {
            get { return phone; }            
        }

        internal string Company
        {
            get { return company; }            
        }

        internal protected override void FormLoad()
        {
            DataSetSource = DatabaseBuilder.Instance.CustomersTable.Tables[0];            
        }

        internal protected override void AddButtonClicked()
        {
            SelectCustomer();                   
        }       

        protected override void ShowEnterDialog()
        {
            base.ShowEnterDialog();     
            SelectCustomer();                   
        }

        private void SelectCustomer()
        {
            if (SelectedRow != null)
            {
                id = SelectedRow.Cells[0].Value.ToString();
                titleOfCourtesy = SelectedRow.Cells[1].Value as string;
                customerName = SelectedRow.Cells[2].Value as string;
                address = SelectedRow.Cells[3].Value as string;
                postcode = SelectedRow.Cells[4].Value as string;
                state = SelectedRow.Cells[5].Value as string;
                phone = SelectedRow.Cells[6].Value as string;
                company = SelectedRow.Cells[7].Value as string;

                EventHandler eventHandler = CustomerSelected;
                if (eventHandler != null)
                {
                    eventHandler(this, EventArgs.Empty);
                }                
            }
            this.Close();            
        }
    }
}
