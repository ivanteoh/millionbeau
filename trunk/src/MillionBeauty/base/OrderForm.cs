using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    public partial class OrderForm : Form
    {
        public event EventHandler Save;
        public event EventHandler Edit;
        public event EventHandler Delete;

        public OrderForm()
        {
            InitializeComponent();

            printButton.Enabled = false;

            totalTextBox.Text = "0";
            discountRegexTextBox.Text = "0";
            grandTotalTextBox.Text = "0";

            orderDetails = new BindingList<OrderDetail>();
            OrderDetailsSource = orderDetails;

            discountRegexTextBox.CustomPattern = @"^\d+([-+.]\d+)?$";
            discountRegexTextBox.Validating += DiscountRegexTextBoxValidating;

            customerFindButton.Click += CustomerPickButtonClick;
            orderDetailsControl.AddButtonClicked += OrderDetailsControlAddButtonClicked;
            orderDetailsControl.EnterKeyDowned += OrderDetailsControlEnterKeyDowned;
            orderDetailsControl.DeleteKeyDowned += OrderDetailsControlDeleteKeyDowned;

            editButton.Click += EditButtonClick;
            deleteButton.Click += DeleteButtonClick;
            saveButton.Click += SaveButtonClick;
            printButton.Click += PrintButtonClick;
            KeyDown += OrderFormKeyDown;
            Load += OrderFormLoad;
        }

        private BindingList<OrderDetail> orderDetails;
        private bool viewOnly;
        private string customerId;

        #region Properties
        internal protected string OrderId 
        {
            get { return recordTextBox.Text; }
            set { recordTextBox.Text = value; }
        }

        internal protected string Year 
        {
            get { return yearTextBox.Text; }
            set { yearTextBox.Text = value; }
        }

        internal protected string OrderDate 
        {
            get { return dateTextBox.Text; }
            set { dateTextBox.Text = value; }
        }

        internal protected string OrderTime
        {
            get { return timeTextBox.Text; }
            set { timeTextBox.Text = value; }
        }

        internal protected string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        internal protected string CustomerTitle
        {
            get { return customerTitleTextBox.Text; }
            set { customerTitleTextBox.Text = value; }
        }

        internal protected string CustomerName
        {
            get { return customerNameTextBox.Text; }
            set { customerNameTextBox.Text = value; }
        }

        internal protected string Address
        {
            get { return customerAddressTextBox.Text; }
            set { customerAddressTextBox.Text = value; }
        }

        internal protected string Postcode
        {
            get { return customerPostcodeTextBox.Text; }
            set { customerPostcodeTextBox.Text = value; }
        }

        internal protected string State
        {
            get { return customerStateTextBox.Text; }
            set { customerStateTextBox.Text = value; }
        }

        internal protected string Phone
        {
            get { return customerPhoneTextBox.Text; }
            set { customerPhoneTextBox.Text = value; }
        }

        internal protected string Company
        {
            get { return customerCompanyTextBox.Text; }
            set { customerCompanyTextBox.Text = value; }
        }

        internal protected string SalePerson 
        {
            get { return salesPersonTextBox.Text; }
            set { salesPersonTextBox.Text = value; }
        }

        internal protected string Total
        { 
            get { return totalTextBox.Text; }
            set { totalTextBox.Text = value; }
        }

        internal protected string Discount 
        {
            get { return discountRegexTextBox.Text; }
            set { discountRegexTextBox.Text = value; }
        }

        internal protected string GrandTotal
        {
            get { return grandTotalTextBox.Text; }
            set { grandTotalTextBox.Text = value; }
        }

        internal protected object OrderDetailsSource
        {
            get { return orderDetailsControl.DataSetSource; }
            set { orderDetailsControl.DataSetSource = value; }
        }

        internal protected DataGridViewRow OrderDetailSelectedRow
        {
            get { return orderDetailsControl.SelectedRow; } 
        }

        #endregion Properties

        protected void ReadOnly()
        {
            Text = "Order";

            viewOnly = true;
            
            customerFindButton.Enabled = false;         
            salesPersonTextBox.ReadOnly = true;
            discountRegexTextBox.ReadOnly = true;
            saveButton.Enabled = false;
            printButton.Enabled = true;
            
            orderDetailsControl.ReadOnly();
        }

        protected void AllowEdit()
        {
            editButton.Visible = true;
            editButton.Enabled = true;
            deleteButton.Visible = true;
            deleteButton.Enabled = true;
        }

        protected void EditView()
        {
            Text = "Edit Order";

            viewOnly = false;
            editButton.Visible = false;
            editButton.Enabled = false;
            deleteButton.Visible = false;
            deleteButton.Enabled = false;
            customerFindButton.Enabled = true;
            salesPersonTextBox.Enabled = true;
            discountRegexTextBox.ReadOnly = false;
            saveButton.Enabled = true;
            printButton.Enabled = false;

            orderDetailsControl.EditView();
        }

        private void OrderFormLoad(object sender, EventArgs e)
        {
            FormLoad();
        }

        internal protected virtual void FormLoad()
        {
        }

        #region Customer Pick
        private void CustomerPickButtonClick(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                CustomerPickButtonClicked();
            }
        }

        internal protected virtual void CustomerPickButtonClicked()
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
        #endregion Customer Pick

        #region Order Details Control Event Handlers
        #region Order Details Insert
        private void OrderDetailsControlAddButtonClicked(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsInserted();
            }
        }

        internal protected virtual void OrderDetailsInserted()
        {
            InsertOrderDetailForm insertOrderDetailForm = new InsertOrderDetailForm();
            insertOrderDetailForm.Added += InsertOrderDetailFormAdded;
            insertOrderDetailForm.ShowDialog(this);
            insertOrderDetailForm.Added -= InsertOrderDetailFormAdded;
        }

        private void InsertOrderDetailFormAdded(object sender, EventArgs e)
        {
            BindingList<OrderDetail> orderDetailList = OrderDetailsSource as BindingList<OrderDetail>;

            InsertOrderDetailForm insertOrderDetailForm = sender as InsertOrderDetailForm;
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ProductId = Convert.ToInt64(insertOrderDetailForm.ProductId, CultureInfo.InvariantCulture);
            orderDetail.Product = insertOrderDetailForm.Product;
            orderDetail.Description = insertOrderDetailForm.Description;
            orderDetail.ProductType = insertOrderDetailForm.ProductType;
            orderDetail.InStock = Convert.ToInt64(insertOrderDetailForm.InStock, CultureInfo.InvariantCulture);
            orderDetail.Price = Convert.ToDecimal(insertOrderDetailForm.Price, CultureInfo.InvariantCulture);
            orderDetail.Quantity = Convert.ToInt64(insertOrderDetailForm.Quantity, CultureInfo.InvariantCulture);
            orderDetail.Cost = Convert.ToDecimal(insertOrderDetailForm.Cost, CultureInfo.InvariantCulture);
            orderDetail.DiscountPercent = Convert.ToDecimal(insertOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
            orderDetail.TotalCost = Convert.ToDecimal(insertOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

            (orderDetailList).Add(orderDetail);

            UpdateTotalPrice(orderDetailList);
        }
        #endregion Order Details Insert

        #region Order Details Update
        private void OrderDetailsControlEnterKeyDowned(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsUpdated();
            }
        }

        internal protected virtual void OrderDetailsUpdated()
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
            // must get instock from products
            DataGridViewRow selectedRow = OrderDetailSelectedRow;

            if (selectedRow != null)
            {
                string productId = selectedRow.Cells[0].Value.ToString();

                DataTable productTable = DatabaseBuilder.Instance.Product(productId) as DataTable;

                if (productTable == null && productTable.Rows.Count != 1)
                    return;

                DataRow currentProduct = productTable.Rows[0];
                object[] productInfo = currentProduct.ItemArray;

                if (productInfo.Length != 7)
                    return;                

                UpdateOrderDetailForm updateOrderDetailForm = sender as UpdateOrderDetailForm;
                updateOrderDetailForm.AddButtonText = "Edit";

                updateOrderDetailForm.ProductId = productId;
                updateOrderDetailForm.Product = productInfo[1].ToString();
                updateOrderDetailForm.Description = productInfo[2].ToString();
                updateOrderDetailForm.ProductType = productInfo[3].ToString();

                long inStock = Convert.ToInt64(productInfo[5]);
                updateOrderDetailForm.InStock = inStock.ToString();

                decimal price = Convert.ToDecimal(productInfo[6]);
                updateOrderDetailForm.Price = price.ToString();

                long quantity = Convert.ToInt64(selectedRow.Cells[6].Value);
                updateOrderDetailForm.Quantity = quantity.ToString();

                decimal cost = price * quantity;
                updateOrderDetailForm.Cost = cost.ToString();

                decimal discountPercent = Convert.ToDecimal(selectedRow.Cells[8].Value);
                updateOrderDetailForm.DiscountPercent = discountPercent.ToString();

                decimal totalCost = cost * discountPercent / 100;
                updateOrderDetailForm.TotalCost = decimal.Round(totalCost, 2).ToString();

                updateOrderDetailForm.DefaultInStock = inStock + quantity;
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
                selectedRow.Cells[7].Value = Convert.ToDecimal(updateOrderDetailForm.Cost, CultureInfo.InvariantCulture);
                selectedRow.Cells[8].Value = Convert.ToDecimal(updateOrderDetailForm.DiscountPercent, CultureInfo.InvariantCulture);
                selectedRow.Cells[9].Value = Convert.ToDecimal(updateOrderDetailForm.TotalCost, CultureInfo.InvariantCulture);

                UpdateTotalPrice((BindingList<OrderDetail>)OrderDetailsSource);
            }
        }        
        #endregion Order Details Update

        #region Order Details Delete
        private void OrderDetailsControlDeleteKeyDowned(object sender, EventArgs e)
        {
            if (!viewOnly)
            {
                OrderDetailsDeleted();
            }
        }

        internal protected virtual void OrderDetailsDeleted()
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
                    UpdateTotalPrice((BindingList<OrderDetail>)OrderDetailsSource);
                }
            }     
        }

        protected void DeleteOrderDetailRow(DataGridViewRow selectedRow)
        {
            orderDetailsControl.DeleteRow(selectedRow);
        }
        #endregion Order Details Delete
        #endregion Order Details Control Event Handlers

        private void DiscountRegexTextBoxValidating(object sender, CancelEventArgs e)
        {
            if (!discountRegexTextBox.Valid || String.IsNullOrEmpty(discountRegexTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Discount has to be RM format and can not be empty.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
                discountRegexTextBox.Text = discountRegexTextBox.OldValue;
            }
            else
            {
                Decimal totalPrice = Convert.ToDecimal(totalTextBox.Text, CultureInfo.InvariantCulture);
                Decimal discount = Convert.ToDecimal(discountRegexTextBox.Text, CultureInfo.InvariantCulture);
                Decimal result = totalPrice - discount;

                discountRegexTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", discountRegexTextBox.Text);
                grandTotalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Decimal.Round(result, 2));
            }
        } 

        protected void UpdateTotalPrice(BindingList<OrderDetail> orderDetailList)
        {
            Decimal totalPrice = new decimal();
            totalPrice = 0;

            foreach (OrderDetail orderItem in orderDetailList)
            {
                totalPrice = totalPrice + orderItem.TotalCost;
            }
            Decimal roundTotalPrice = decimal.Round(totalPrice, 2);
            totalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", roundTotalPrice);

            string discountText = discountRegexTextBox.Text;

            Decimal grandTotal = roundTotalPrice - Convert.ToDecimal(discountText, CultureInfo.InvariantCulture);

            discountRegexTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", discountText);

            grandTotalTextBox.Text = String.Format(CultureInfo.InvariantCulture, "{0:0.00}", Decimal.Round(grandTotal, 2));
        }

        private void OrderFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = Edit;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }  
        }

        void DeleteButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = Delete;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }     
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = Save;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }            
        } 

        private void PrintButtonClick(object sender, EventArgs e)
        {
            PrintViewerForm printViewerForm = new PrintViewerForm();
            printViewerForm.OrderId = OrderId;
            printViewerForm.ShowDialog(this);
        }                 
    }
}
