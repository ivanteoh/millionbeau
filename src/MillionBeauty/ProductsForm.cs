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
            this.Text = Properties.Resources.ProductsList;            
        }

        internal protected override void FormLoad()
        {
            DataSetSource = DatabaseBuilder.Instance.ProductsTable;
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
                DataSetSource = DatabaseBuilder.Instance.ProductsTable;
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
                    DataSetSource = DatabaseBuilder.Instance.ProductsTable;
                }
            }
            base.ShowEnterDialog();
        }

        protected override void ShowDeleteDialog()
        {
            if (SelectedRow != null)
            {
                string index = SelectedRow.Cells[0].Value.ToString();
                string deleteQuery = string.Format(CultureInfo.InvariantCulture, Properties.Resources.DeleteProduct, index);
                DialogResult result = MessageBox.Show(
                    deleteQuery, Properties.Resources.Title,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign &
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    DatabaseBuilder.Instance.DeleteProduct(index);
                    DataSetSource = DatabaseBuilder.Instance.ProductsTable;
                }

            }
            base.ShowDeleteDialog();
        } 
    }
}
