using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    class InsertOrderDetailForm : OrderDetailForm
    {
        public event EventHandler Added;
        
        public InsertOrderDetailForm()
            : base()
        {
            Load += InsertOrderDetailFormLoad; 
        }

        private void InsertOrderDetailFormLoad(object sender, EventArgs e)
        {
            Quantity = "0";
            Cost = "0";
            DiscountPercent = "0";
            TotalCost = "0";
        }

        protected override void AddButtonClicked()
        {
            base.AddButtonClicked();

            if (string.IsNullOrEmpty(ProductId))
            {
                MessageBox.Show(
                    "Pick a product before adding to order form.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            }
            else if (Convert.ToInt64(Quantity, CultureInfo.InvariantCulture) == 0)
            {
                MessageBox.Show(
                    "Quantity can not be zero.",
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);                
            }
            else
            {
                EventHandler eventHandler = Added;
                if (eventHandler != null)
                {
                    eventHandler(this, EventArgs.Empty);
                }

                Close();
            }
        }

        
    }
}
