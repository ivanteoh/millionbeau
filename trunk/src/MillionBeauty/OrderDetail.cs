using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    class OrderDetail
    {
        private Int64 productId;
        private string product;
        private string description;
        private string productType;
        private Int64 inStock;
        private Decimal price;
        private Int64 quantity;
        private Decimal discountPercent;
        private Decimal totalCost;

        internal Int64 ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        internal string Product
        {
            get { return product; }
            set { product = value; }
        }

        internal string Description
        {
            get { return description; }
            set { description = value; }
        }

        internal string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        internal Int64 InStock
        {
            get { return inStock; }
            set { inStock = value; }
        }

        internal Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        internal Int64 Quantity 
        {
            get { return quantity; }
            set { quantity = value; }
        }

        internal Decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }

        internal Decimal TotalCost 
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}
