using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class UpdateProductForm : ProductForm
    {
        public UpdateProductForm()
            : base()
        {
            Text = "Update Product Info";
        }

        protected override void EnterProductInfo()
        {
            DatabaseBuilder.Instance.UpdateProduct(
                Id,
                Product,
                Description,
                ProductType,
                Specification,
                InStock,
                Price);
        }
    }
}
