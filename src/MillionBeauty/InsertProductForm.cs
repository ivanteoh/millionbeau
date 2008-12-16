using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class InsertProductForm : ProductForm
    {
        public InsertProductForm()
            : base()
        {
            Text = Properties.Resources.AddNewProduct;
        }

        internal protected override void FormLoad()
        {
            HideIdLabel();
        }

        protected override void EnterProductInfo()
        {
            DatabaseBuilder.Instance.InsertProduct(
                Product,
                Description,
                ProductType,
                Specification,
                InStock,
                Price);
        }
    }
}
