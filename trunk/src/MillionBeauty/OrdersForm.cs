using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Globalization;

namespace MillionBeauty
{
    class OrdersForm : DataViewForm
    {
        public OrdersForm()
            : base()
        {
            this.Text = "Orders List";
            AddButtonName = "Pick";
        }

        internal protected override void FormLoad()
        {
            DataSetSource = SQLiteDB.Instance.OrdersTable;
        }

        internal protected override void AddButtonClicked()
        {
            SelectOrder();
        }

        protected override void ShowEnterDialog()
        {
            base.ShowEnterDialog();
            SelectOrder();
        }

        private void SelectOrder()
        {
            string orderId;

            if (SelectedRow != null)
            {
                ViewOrderForm viewOrderForm = new ViewOrderForm();
                orderId = SelectedRow.Cells[0].Value.ToString();
                viewOrderForm.OrderId = orderId;
                viewOrderForm.Year = SelectedRow.Cells[1].Value as string;
                viewOrderForm.OrderDate = SelectedRow.Cells[2].Value as string;
                viewOrderForm.OrderTime = SelectedRow.Cells[3].Value as string;
                viewOrderForm.CustomerId = SelectedRow.Cells[4].Value as string;
                viewOrderForm.CustomerTitle = SelectedRow.Cells[5].Value as string;
                viewOrderForm.CustomerName = SelectedRow.Cells[6].Value as string;
                viewOrderForm.Address = SelectedRow.Cells[7].Value as string;
                viewOrderForm.Postcode = SelectedRow.Cells[8].Value.ToString();
                viewOrderForm.State = SelectedRow.Cells[9].Value.ToString();
                viewOrderForm.Phone = SelectedRow.Cells[10].Value.ToString();
                viewOrderForm.Company = SelectedRow.Cells[11].Value.ToString();
                viewOrderForm.SalePerson = SelectedRow.Cells[12].Value.ToString();

                viewOrderForm.Total = Decimal.Round(Convert.ToDecimal(SelectedRow.Cells[13].Value, CultureInfo.InvariantCulture), 2).ToString();
                viewOrderForm.Discount = Decimal.Round(Convert.ToDecimal(SelectedRow.Cells[14].Value, CultureInfo.InvariantCulture), 2).ToString();
                viewOrderForm.GrandTotal = Decimal.Round(Convert.ToDecimal(SelectedRow.Cells[15].Value, CultureInfo.InvariantCulture), 2).ToString();
                BindingList<OrderDetail> orderDetails = SQLiteDB.Instance.OrderDetail(orderId);
                if (orderDetails != null)
                {
                    viewOrderForm.OrderDetailsSource = orderDetails;
                }
                viewOrderForm.ShowDialog(this);
            }          
        }
    }
}
