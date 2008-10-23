using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace MillionBeauty
{
    class ProductsForm : DataViewForm
    {
        public ProductsForm()
            : base()
        {
            this.Text = "Proudcts List";
        }

        internal protected override void FormLoad()
        {
            DataSetSource = SQLiteDB.Instance.ProductsTable;
        }

        internal protected override void AddButtonClicked()
        {
            ShowAddDialog();
        }

        protected override void ShowAddDialog()
        {
            InsertProductForm insertProductForm = new InsertProductForm();
            DialogResult result = insertProductForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                DataSetSource = SQLiteDB.Instance.ProductsTable;
            }
            base.ShowAddDialog();
        }

        protected override void ShowEnterDialog()
        {
            if (SelectedRow != null)
            {
                UpdateProductForm updateProductForm = new UpdateProductForm();
                updateProductForm.Id = SelectedRow.Cells[0].Value.ToString();
                updateProductForm.Product = SelectedRow.Cells[1].Value as string;
                updateProductForm.Description = SelectedRow.Cells[2].Value as string;
                updateProductForm.ProductType = SelectedRow.Cells[3].Value as string;
                updateProductForm.Specification = SelectedRow.Cells[4].Value as string;
                updateProductForm.InStock = SelectedRow.Cells[5].Value.ToString();
                updateProductForm.Price = SelectedRow.Cells[6].Value.ToString();
                DialogResult result = updateProductForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    DataSetSource = SQLiteDB.Instance.ProductsTable;
                }
            }
            base.ShowEnterDialog();
        }

        protected override void ShowDeleteDialog()
        {
            if (SelectedRow != null)
            {
                string index = SelectedRow.Cells[0].Value.ToString();
                string deleteQuery = string.Format(CultureInfo.InvariantCulture, "Are you sure you want to delete product {0}", index);
                DialogResult result = MessageBox.Show(
                    deleteQuery, Properties.Resources.Title,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign &
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    SQLiteDB.Instance.DeleteProduct(index);
                    DataSetSource = SQLiteDB.Instance.ProductsTable;
                }

            }
            base.ShowDeleteDialog();
        } 
    }
}
