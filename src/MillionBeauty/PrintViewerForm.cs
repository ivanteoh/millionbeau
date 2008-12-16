using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Xml;

namespace MillionBeauty
{
    public partial class PrintViewerForm : Form
    {
        public PrintViewerForm()
        {
            InitializeComponent();

            Load += PrintViewerFormLoad;
        }

        private void PrintViewerFormLoad(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(orderId))
            {
                documentViewer.LoadDocument(
                    Core.LoadReceiptDocument(
                    orderId,
                    Properties.Settings.Default.CompanyName,
                    Properties.Settings.Default.CompanyNumber,
                    Properties.Settings.Default.CompanyContact));
            }            
        }

        private string orderId;

        public string OrderId 
        {
            get { return orderId; }
            set { orderId = value; }
        }        
    }
}
