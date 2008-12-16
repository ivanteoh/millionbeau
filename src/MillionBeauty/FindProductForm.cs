using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class FindProductForm : DataViewForm
    {
        public event EventHandler ProductSelected;

        public FindProductForm()
            : base()
        {
            this.Text = Properties.Resources.SelectProduct;
            AddButtonName = Properties.Resources.Pick;
        }

        private string id;
        private string product;
        private string description;
        private string productType;
        private string inStock;
        private string price;

        internal string Id
        {
            get { return id; }            
        }

        internal string Product
        {
            get { return product; }            
        }

        internal string Description
        {
            get { return description; }            
        }

        internal string ProductType
        {
            get { return productType; }            
        }

        internal string InStock
        {
            get { return inStock; }            
        }

        internal string Price
        {
            get { return price; }            
        }

        internal protected override void FormLoad()
        {
            DataSetSource = DatabaseBuilder.Instance.ProductsTable;
        }

        internal protected override void AddButtonClicked()
        {
            SelectProduct();
        }

        protected override void ShowEnterDialog()
        {
            base.ShowEnterDialog();
            SelectProduct();
        }

        private void SelectProduct()
        {
            if (SelectedRow != null)
            {
                id = SelectedRow.Cells[0].Value.ToString();
                product = SelectedRow.Cells[1].Value as string;
                description = SelectedRow.Cells[2].Value as string;
                productType = SelectedRow.Cells[3].Value as string;
                inStock = SelectedRow.Cells[5].Value.ToString();
                price = SelectedRow.Cells[6].Value.ToString();

                EventHandler eventHandler = ProductSelected;
                if (eventHandler != null)
                {
                    eventHandler(this, EventArgs.Empty);
                }
            }
            this.Close();
        }
    }
}
