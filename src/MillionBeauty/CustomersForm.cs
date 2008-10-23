using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    public class CustomersForm : DataViewForm
    {
        public CustomersForm()
            : base()
        {
            this.Text = "Customers List";
        }

        internal protected override void FormLoad()
        {
            DataSetSource = SQLiteDB.Instance.CustomersTable;            
        }

        internal protected override void AddButtonClicked()
        {
            ShowInsertDialog();            
        }

        protected override void ShowInsertDialog()
        {            
            InsertCustomerForm insertCustomerForm = new InsertCustomerForm();
            DialogResult result = insertCustomerForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                DataSetSource = SQLiteDB.Instance.CustomersTable;
            }
            base.ShowInsertDialog();
        }

        protected override void ShowUpdateDialog()
        {
            if (SelectedRow != null)
            {
                UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm();
                updateCustomerForm.Id = SelectedRow.Cells[0].Value.ToString();
                updateCustomerForm.TitleOfCourtesy = SelectedRow.Cells[1].Value as string;
                updateCustomerForm.CustomerName = SelectedRow.Cells[2].Value as string;
                updateCustomerForm.Address = SelectedRow.Cells[3].Value as string;
                updateCustomerForm.Postcode = SelectedRow.Cells[4].Value as string;
                updateCustomerForm.State = SelectedRow.Cells[5].Value as string;
                updateCustomerForm.Phone = SelectedRow.Cells[6].Value as string;
                updateCustomerForm.Company = SelectedRow.Cells[7].Value as string;
                DialogResult result = updateCustomerForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    DataSetSource = SQLiteDB.Instance.CustomersTable;
                }
            }
            base.ShowUpdateDialog();
        }

        protected override void ShowDeleteDialog()
        {
            if (SelectedRow != null)
            {
                string index = SelectedRow.Cells[0].Value.ToString();
                string deleteQuery = string.Format(CultureInfo.InvariantCulture, "Are you sure you want to delete customer {0}", index);
                DialogResult result = MessageBox.Show(
                    deleteQuery, Properties.Resources.Title,
                    MessageBoxButtons.OKCancel, 
                    MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2, 
                    MessageBoxOptions.RightAlign & 
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    SQLiteDB.Instance.DeleteCustomer(index);
                    DataSetSource = SQLiteDB.Instance.CustomersTable;
                }

            }
            base.ShowDeleteDialog();
        }        
    }
}
