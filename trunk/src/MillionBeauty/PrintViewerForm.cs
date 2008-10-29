using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Controls;

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
            FixedDocumentSequence fds = new FixedDocumentSequence();
            FixedDocument doc = new FixedDocument();

            // Add first page to document
            FixedPage page = new FixedPage();
            PageContent pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(page);
            doc.Pages.Add(pageContent);

            // Add content to second page
            Canvas content = new Canvas();
            page.Children.Add(content);
            ReciptReport reciptReport = new ReciptReport();
            content.Children.Add(reciptReport);

            DocumentReference docReference = new DocumentReference();
            docReference.SetDocument(doc);
            fds.References.Add(docReference);

            documentViewer.LoadDocument(fds);
        }
    }
}
