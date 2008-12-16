using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Text = Properties.Resources.Title;

            customersButton.Click += CustomersButtonClick;
            productsButton.Click += ProductsButtonClick;
            optionsButton.Click += OptionsButtonClick;
            newOrderButton.Click += NewOrderButtonClick;
            ordersButton.Click += OrdersButtonClick;

            KeyDown += MainFormKeyDown;
            Load += MainFormLoad;
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            Text = Properties.Resources.Title;
            string connectionString = string.Format(CultureInfo.InvariantCulture, Properties.Resources.DataSource, Properties.Settings.Default.Database);
            Core.LoadDatabase(connectionString);
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Control)
                    {
                        ShowCustomersForm();
                    }
                    break;
                case Keys.D:
                    if (e.Control)
                    {
                        ShowOptionsForm();
                    }
                    break;
                case Keys.P:
                    if (e.Control)
                    {
                        ShowProductsForm();
                    }
                    break;
                default:
                    break;
            }
        }

        private void CustomersButtonClick(object sender, System.EventArgs e)
        {
            ShowCustomersForm();
        }        

        private void ProductsButtonClick(object sender, System.EventArgs e)
        {
            ShowProductsForm();
        }

        private void OptionsButtonClick(object sender, System.EventArgs e)
        {
            ShowOptionsForm();
        }

        private void NewOrderButtonClick(object sender, System.EventArgs e)
        {
            ShowNewOrderForm();
        }

        private void OrdersButtonClick(object sender, System.EventArgs e)
        {
            ShowOrdersForm();
        }

        private void ShowCustomersForm()
        {
            CustomersForm customersForm = new CustomersForm();            
            customersForm.ShowDialog(this);
        }

        private void ShowProductsForm()
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.ShowDialog(this);
        }

        private void ShowOptionsForm()
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog(this);
        }

        private void ShowNewOrderForm()
        {
            NewOrderForm newOrderForm = new NewOrderForm();
            newOrderForm.ShowDialog(this);
        }

        private void ShowOrdersForm()
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.ShowDialog(this);
        }        
    }
}
