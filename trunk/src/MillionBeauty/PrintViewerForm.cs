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
                documentViewer.LoadDocument(Core.LoadReceiptDocument(orderId));
            }            
        }

        private string orderId;

        public string OrderId 
        {
            get { return orderId; }
            set { orderId = value; }
        }

        private void LoadFixedDocument()
        {
            //FixedDocumentSequence fds = new FixedDocumentSequence();
            //FixedDocument doc = new FixedDocument();

            //// Add first page to document
            //FixedPage page = new FixedPage();
            //PageContent pageContent = new PageContent();
            //((IAddChild)pageContent).AddChild(page);
            //doc.Pages.Add(pageContent);

            //// Add content to second page
            //Canvas content = new Canvas();
            //page.Children.Add(content);
            ////ReceiptReport reciptReport = new ReceiptReport();
            ////content.Children.Add(receiptReport);            

            //DocumentReference docReference = new DocumentReference();
            //docReference.SetDocument(doc);
            //fds.References.Add(docReference);

            documentViewer.LoadDocument(Core.LoadReceiptDocument("1"));
        }        
    }
}
