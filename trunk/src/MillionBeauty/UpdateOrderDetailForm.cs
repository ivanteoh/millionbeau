using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MillionBeauty
{
    class UpdateOrderDetailForm : OrderDetailForm
    {
        public event EventHandler Inserted;
        public event EventHandler Updated;

        public UpdateOrderDetailForm()
            : base()
        {
            Load += UpdateOrderDetailFormLoad;
        }

        private void UpdateOrderDetailFormLoad(object sender, EventArgs e)
        {
            EventHandler eventHandler = Inserted;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }

        protected override void AddButtonClicked()
        {
            base.AddButtonClicked();

            if (string.IsNullOrEmpty(ProductId))
            {
                MessageBox.Show(
                    Properties.Resources.ErrorPickProduct,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            }
            else if (Convert.ToInt64(Quantity, CultureInfo.InvariantCulture) == 0)
            {
                MessageBox.Show(
                    Properties.Resources.ErrorQuantityZero,
                    Properties.Resources.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            }
            else
            {
                EventHandler eventHandler = Updated;
                if (eventHandler != null)
                {
                    eventHandler(this, EventArgs.Empty);
                }

                Close();
            }
        }
    }
}
