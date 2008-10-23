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

            customersToolStripButton.Click += CustomersToolStripButtonClick;
            productsToolStripButton.Click += ProductsToolStripButtonClick;
            databaseToolStripMenuItem.Click += DatabaseToolStripMenuItemClick;
            newOrderButton.Click += NewOrderButtonClick;

            KeyDown += MainFormKeyDown;
            Load += MainFormLoad;
        }

              

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            Text = Properties.Resources.Title;
            string connectionString = string.Format(CultureInfo.InvariantCulture, "data source=\"{0}\"", Properties.Settings.Default.Database);
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
                        ShowDatabaseForm();
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

        private void CustomersToolStripButtonClick(object sender, System.EventArgs e)
        {
            ShowCustomersForm();
        }        

        private void ProductsToolStripButtonClick(object sender, System.EventArgs e)
        {
            ShowProductsForm();
        }        

        private void DatabaseToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            ShowDatabaseForm();
        }

        private void NewOrderButtonClick(object sender, System.EventArgs e)
        {
            ShowNewOrderForm();
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

        private void ShowDatabaseForm()
        {
            DatabaseForm databaseForm = new DatabaseForm();
            databaseForm.ShowDialog(this);
        }

        private void ShowNewOrderForm()
        {
            NewOrderForm newOrderForm = new NewOrderForm();
            newOrderForm.ShowDialog(this);
        }
    }
}
