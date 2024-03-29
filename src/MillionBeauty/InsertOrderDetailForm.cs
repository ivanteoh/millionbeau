﻿using System;
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
            AddButtonText = Properties.Resources.Add;
            Quantity = Properties.Resources.Zero;
            Cost = Properties.Resources.Zero;
            DiscountPercent = Properties.Resources.Zero;
            TotalCost = Properties.Resources.Zero;
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
