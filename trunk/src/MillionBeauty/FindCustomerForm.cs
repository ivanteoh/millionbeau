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
            this.Text = "Select Customer";
            AddButtonName = "Pick";
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
            //set { id = value; }
        }

        internal string TitleOfCourtesy
        {
            get { return titleOfCourtesy; }
            //set { titleOfCourtesy = value; }
        }

        internal string CustomerName
        {
            get { return customerName; }
            //set { customerName = value; }
        }

        internal string Address
        {
            get { return address; }
            //set { address = value; }
        }

        internal string Postcode
        {
            get { return postcode; }
            //set { postcode = value; }
        }

        internal string State
        {
            get { return state; }
            //set { state = value; }
        }

        internal string Phone
        {
            get { return phone; }
            //set { phone = value; }
        }

        internal string Company
        {
            get { return company; }
            //set { company = value; }
        }

        internal protected override void FormLoad()
        {
            DataSetSource = DatabaseBuilder.Instance.CustomersTable;            
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
