﻿using System;
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
            this.Text = Properties.Resources.OrdersList;
            AddButtonName = Properties.Resources.Pick;
            ReadOnly = true;
        }

        internal protected override void FormLoad()
        {
            DataSetSource = DatabaseBuilder.Instance.OrdersTable;
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
                viewOrderForm.CustomerId = SelectedRow.Cells[4].Value.ToString();
                viewOrderForm.CustomerTitle = SelectedRow.Cells[5].Value as string;
                viewOrderForm.CustomerName = SelectedRow.Cells[6].Value as string;
                viewOrderForm.Address = SelectedRow.Cells[7].Value as string;
                viewOrderForm.Postcode = SelectedRow.Cells[8].Value.ToString();
                viewOrderForm.State = SelectedRow.Cells[9].Value.ToString();
                viewOrderForm.Phone = SelectedRow.Cells[10].Value.ToString();
                viewOrderForm.Company = SelectedRow.Cells[11].Value.ToString();
                viewOrderForm.SalePerson = SelectedRow.Cells[12].Value.ToString();

                viewOrderForm.Total = String.Format(CultureInfo.InvariantCulture, Properties.Resources.CurrencyFormat, SelectedRow.Cells[13].Value);
                viewOrderForm.Discount = String.Format(CultureInfo.InvariantCulture, Properties.Resources.CurrencyFormat, SelectedRow.Cells[14].Value);
                viewOrderForm.GrandTotal = String.Format(CultureInfo.InvariantCulture, Properties.Resources.CurrencyFormat, SelectedRow.Cells[15].Value);
                BindingList<OrderDetail> orderDetails = DatabaseBuilder.Instance.OrderDetail(orderId);
                if (orderDetails != null)
                {
                    viewOrderForm.OrderDetailsSource = orderDetails;
                }
                viewOrderForm.ShowDialog(this);
                DataSetSource = DatabaseBuilder.Instance.OrdersTable;
            }          
        }
    }
}
