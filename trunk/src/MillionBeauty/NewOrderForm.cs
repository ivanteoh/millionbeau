using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace MillionBeauty
{
    class NewOrderForm : OrderForm
    {
        public NewOrderForm()
            : base()
        {
            Text = "New Order";

            orderDetails = new BindingList<OrderDetail>();
            OrderDetailsSource = orderDetails;
            Save += NewOrderFormSave;            
        }        

        private BindingList<OrderDetail> orderDetails;

        internal protected override void CustomerPickButtonClicked()
        {
            FindCustomerForm findCustomerForm = new FindCustomerForm();
            findCustomerForm.CustomerSelected += FindCustomerFormCustomerSelected;
            findCustomerForm.ShowDialog(this);
            findCustomerForm.CustomerSelected -= FindCustomerFormCustomerSelected;
        }

        private void FindCustomerFormCustomerSelected(object sender, EventArgs e)
        {
            FindCustomerForm findCustomerForm = sender as FindCustomerForm;
            CustomerId = findCustomerForm.Id;
            CustomerTitle = findCustomerForm.TitleOfCourtesy;
            CustomerName = findCustomerForm.CustomerName;
            Address = findCustomerForm.Address;
            Postcode = findCustomerForm.Postcode;
            State = findCustomerForm.State;
            Phone = findCustomerForm.Phone;
            Company = findCustomerForm.Company;
        }

        internal protected override void OrderDetailsInserted()
        {
            InsertOrderDetailForm insertOrderDetailForm = new InsertOrderDetailForm();
            insertOrderDetailForm.Added += InsertOrderDetailFormAdded;
            insertOrderDetailForm.ShowDialog(this);
            insertOrderDetailForm.Added -= InsertOrderDetailFormAdded;
        }

        private void InsertOrderDetailFormAdded(object sender, EventArgs e)
        {
            InsertOrderDetailForm insertOrderDetailForm = sender as InsertOrderDetailForm;
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = Convert.ToInt64(insertOrderDetailForm.ProductId, CultureInfo.InvariantCulture);
            orderDetail.Product = insertOrderDetailForm.Product;
            orderDetail.Description = insertOrderDetailForm.Description;
            orderDetail.ProductType = insertOrderDetailForm.ProductType;
            orderDetail.InStock = Convert.ToInt64(insertOrderDetailForm.InStock, CultureInfo.InvariantCulture);
            orderDetail.Price = Convert.ToDecimal(insertOrderDetailForm.Price, CultureInfo.InvariantCulture);
            orderDetail.Quantity = Convert.ToInt64(insertOrderDetailForm.Quantity, CultureInfo.InvariantCulture);
            orderDetail.DiscountPercent = Convert.ToDecimal(insertOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
            orderDetail.TotalCost = Convert.ToDecimal(insertOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

            orderDetails.Add(orderDetail);

            UpdateTotalPrice(orderDetails);
        }

        internal protected override void OrderDetailsUpdated()
        {
            UpdateOrderDetailForm updateOrderDetailForm = new UpdateOrderDetailForm();
            updateOrderDetailForm.Inserted += UpdateOrderDetailFormInserted;
            updateOrderDetailForm.Updated += UpdateOrderDetailFormUpdated;
            updateOrderDetailForm.ShowDialog(this);
            updateOrderDetailForm.Inserted -= UpdateOrderDetailFormInserted;
            updateOrderDetailForm.Updated -= UpdateOrderDetailFormUpdated;
        }

        private void UpdateOrderDetailFormInserted(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = OrderDetailSelectedRow;

            if (selectedRow != null)
            {
                UpdateOrderDetailForm updateOrderDetailForm = sender as UpdateOrderDetailForm;
                updateOrderDetailForm.ProductId = selectedRow.Cells[0].Value.ToString();
                updateOrderDetailForm.Product = selectedRow.Cells[1].Value.ToString();
                updateOrderDetailForm.Description = selectedRow.Cells[2].Value.ToString();
                updateOrderDetailForm.ProductType = selectedRow.Cells[3].Value.ToString();
                updateOrderDetailForm.InStock = selectedRow.Cells[4].Value.ToString();
                updateOrderDetailForm.Price = selectedRow.Cells[5].Value.ToString();
                updateOrderDetailForm.Quantity = selectedRow.Cells[6].Value.ToString();
                updateOrderDetailForm.DiscountPercent = selectedRow.Cells[7].Value.ToString();
                updateOrderDetailForm.TotalCost = selectedRow.Cells[8].Value.ToString();
                Int64 left = Convert.ToInt64(selectedRow.Cells[4].Value, CultureInfo.InvariantCulture) + Convert.ToInt64(selectedRow.Cells[6].Value, CultureInfo.InvariantCulture);
                updateOrderDetailForm.DefaultInStock = left;
            }
        }

        private void UpdateOrderDetailFormUpdated(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = OrderDetailSelectedRow;

            if (selectedRow != null)
            {
                UpdateOrderDetailForm updateOrderDetailForm = sender as UpdateOrderDetailForm;
                selectedRow.Cells[0].Value = Convert.ToInt64(updateOrderDetailForm.ProductId, CultureInfo.InvariantCulture);
                selectedRow.Cells[1].Value = updateOrderDetailForm.Product;
                selectedRow.Cells[2].Value = updateOrderDetailForm.Description;
                selectedRow.Cells[3].Value = updateOrderDetailForm.ProductType;
                selectedRow.Cells[4].Value = Convert.ToInt64(updateOrderDetailForm.InStock, CultureInfo.InvariantCulture);
                selectedRow.Cells[5].Value = Convert.ToDecimal(updateOrderDetailForm.Price, CultureInfo.InvariantCulture);
                selectedRow.Cells[6].Value = Convert.ToInt64(updateOrderDetailForm.Quantity, CultureInfo.InvariantCulture);
                selectedRow.Cells[7].Value = Convert.ToDecimal(updateOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
                selectedRow.Cells[8].Value = Convert.ToDecimal(updateOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

                UpdateTotalPrice(orderDetails);
            }
        }

        internal protected override void OrderDetailsDeleted()
        {
            DataGridViewRow selectedRow = OrderDetailSelectedRow;

            if (selectedRow != null)
            {
                string index = selectedRow.Cells[0].Value.ToString();
                string deleteQuery = string.Format(CultureInfo.InvariantCulture, "Are you sure you want to delete product {0}", index);
                DialogResult result = MessageBox.Show(
                    deleteQuery, Properties.Resources.Title,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign &
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    DeleteOrderDetailRow(selectedRow);
                    UpdateTotalPrice(orderDetails);
                }
            }     
        }

        private void NewOrderFormSave(object sender, EventArgs e)
        {
            SQLiteDB.Instance.InsertOrder(CustomerId, SalePerson, Total, Discount, GrandTotal);
            object[] orderInfo = SQLiteDB.Instance.LastOrder();
            OrderId = orderInfo[0].ToString();
            Year = orderInfo[1].ToString();
            OrderDate = orderInfo[2].ToString();
            OrderTime = orderInfo[3].ToString();
            SQLiteDB.Instance.InsertOrderDetail(OrderId, orderDetails);

            ReadOnly();
        }        
    }
}
