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
            Text = "Add New Product";
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
