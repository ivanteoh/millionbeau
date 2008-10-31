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
            this.Text = "Select Product";
            AddButtonName = "Pick";
        }

        private string id;
        private string product;
        private string description;
        private string productType;
        //private string specification;
        private string inStock;
        private string price;

        internal string Id
        {
            get { return id; }
            //set { id = value; }
        }

        internal string Product
        {
            get { return product; }
            //set { product = value; }
        }

        internal string Description
        {
            get { return description; }
            //set { description = value; }
        }

        internal string ProductType
        {
            get { return productType; }
            //set { productType = value; }
        }

        //internal string Specification
        //{
        //    get { return specification; }
        //    set { specification = value; }
        //}

        internal string InStock
        {
            get { return inStock; }
            //set { inStock = value; }
        }

        internal string Price
        {
            get { return price; }
            //set { price = value; }
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
                //specification = SelectedRow.Cells[4].Value as string;
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
