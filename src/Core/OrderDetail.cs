using System;
using System.Collections.Generic;
using System.Text;

namespace MillionBeauty
{
    public class OrderDetail
    {
        private Int64 productId;
        private string product;
        private string description;
        private string productType;
        private Int64 inStock;
        private Decimal price;
        private Int64 quantity;
        private Decimal cost;
        private Decimal discountPercent;
        private Decimal totalCost;

        public Int64 ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string Product
        {
            get { return product; }
            set { product = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public Int64 InStock
        {
            get { return inStock; }
            set { inStock = value; }
        }

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Int64 Quantity 
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }

        public Decimal TotalCost 
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}
