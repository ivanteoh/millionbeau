using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Xml;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Globalization;

namespace MillionBeauty
{
    public static class Core
    {
        public static void NewDatabase(string connectionString)
        {
            SQLiteDB.Instance.ConnectionString = connectionString;
            SQLiteDB.Instance.CreateDatabase();
        }

        public static void LoadDatabase(string connectionString)
        {
            SQLiteDB.Instance.ConnectionString = connectionString;
            SQLiteDB.Instance.CreateConnection();
        }

        public static FixedDocumentSequence LoadReceiptDocument(string orderId)
        {
            // Get order info
            object[] orderInfo = SQLiteDB.Instance.Order(orderId);
            string year = orderInfo[1].ToString();
            string orderDate = orderInfo[2].ToString();
            string orderTime = orderInfo[3].ToString();
            string customerId = orderInfo[4].ToString();
            string customerTitle = orderInfo[5].ToString();
            string customerName = orderInfo[6].ToString();
            string customerAddress = orderInfo[7].ToString();
            string customerPostcode = orderInfo[8].ToString();
            string customerState = orderInfo[9].ToString();
            string customerPhone = orderInfo[10].ToString();
            string customerCompany = orderInfo[11].ToString();
            string salesPerson = orderInfo[12].ToString();
            string sum = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderInfo[13]);
            string discount = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderInfo[14]);
            string total = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderInfo[15]);

            FixedDocumentSequence fds = new FixedDocumentSequence();
            FixedDocument doc = new FixedDocument();

            // Add first page to document
            FixedPage page = new FixedPage();
            PageContent pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(page);
            doc.Pages.Add(pageContent);

            #region Header
            // Add grid to first page
            Grid grid = new Grid();
            page.Children.Add(grid);

            StackPanel stackPanel = new StackPanel();
            grid.Children.Add(stackPanel);

            TextBlock companyTextBlock = new TextBlock();
            companyTextBlock.TextAlignment = TextAlignment.Center;
            stackPanel.Children.Add(companyTextBlock);

            Span spanName = new Span();
            spanName.FontWeight = FontWeights.Bold;
            spanName.Inlines.Add("Million Beauty Lights Trading Sdn. Bhd. ");
            companyTextBlock.Inlines.Add(spanName);  

            Span spanCode = new Span();
            spanCode.BaselineAlignment = BaselineAlignment.Subscript;
            spanCode.Inlines.Add("(800526-T)");
            companyTextBlock.Inlines.Add(spanCode);

            companyTextBlock.Inlines.Add(new LineBreak());
            companyTextBlock.Inlines.Add(new Run("17, 1st Floor, Tingkat Bukit Minyak 7,"));
            companyTextBlock.Inlines.Add(new LineBreak());
            companyTextBlock.Inlines.Add(new Run("Taman Bukit Minyak, 14000 Bukit Mertajam,"));
            companyTextBlock.Inlines.Add(new LineBreak());
            companyTextBlock.Inlines.Add(new Run("Penang"));
            companyTextBlock.Inlines.Add(new LineBreak());
            companyTextBlock.Inlines.Add(new Run("Tel no: 04-5022118 / 5089118 Fax no: 04-5089118"));

            stackPanel.Children.Add(new Separator());
            #endregion Header            

            TextBlock titleTextBlock = new TextBlock();
            titleTextBlock.TextAlignment = TextAlignment.Center;
            stackPanel.Children.Add(titleTextBlock);

            Span titleSpan = new Span();
            titleSpan.TextDecorations = TextDecorations.Underline;
            titleSpan.Inlines.Add("Offical Receipt");
            titleTextBlock.Inlines.Add(titleSpan);

            #region Record Grid
            Grid recordGrid = new Grid();

            recordGrid.ColumnDefinitions.Add(new ColumnDefinition());
            recordGrid.ColumnDefinitions.Add(new ColumnDefinition());
            recordGrid.ColumnDefinitions.Add(new ColumnDefinition());
            recordGrid.ColumnDefinitions.Add(new ColumnDefinition());            

            recordGrid.RowDefinitions.Add(new RowDefinition());
            recordGrid.RowDefinitions.Add(new RowDefinition());            

            TextBlock record00TextBlock = new TextBlock();
            record00TextBlock.Text = "Record Id:";
            recordGrid.Children.Add(record00TextBlock);
            Grid.SetRow(record00TextBlock, 0);
            Grid.SetColumn(record00TextBlock, 0);

            string recordId = string.Format(CultureInfo.InvariantCulture, "{0} / {1}", orderId, year);

            TextBlock record01TextBlock = new TextBlock();
            record01TextBlock.Text = recordId;
            recordGrid.Children.Add(record01TextBlock);
            Grid.SetRow(record01TextBlock, 0);
            Grid.SetColumn(record01TextBlock, 1);
            Grid.SetColumnSpan(record01TextBlock, 3);

            TextBlock record10TextBlock = new TextBlock();
            record10TextBlock.Text = "Date:";
            recordGrid.Children.Add(record10TextBlock);
            Grid.SetRow(record10TextBlock, 1);
            Grid.SetColumn(record10TextBlock, 0);

            TextBlock record11TextBlock = new TextBlock();
            record11TextBlock.Text = orderDate;
            recordGrid.Children.Add(record11TextBlock);
            Grid.SetRow(record11TextBlock, 1);
            Grid.SetColumn(record11TextBlock, 1);

            TextBlock record12TextBlock = new TextBlock();
            record12TextBlock.Text = "Time:";
            recordGrid.Children.Add(record12TextBlock);
            Grid.SetRow(record12TextBlock, 1);
            Grid.SetColumn(record12TextBlock, 2);

            TextBlock record13TextBlock = new TextBlock();
            record13TextBlock.Text = orderTime;
            recordGrid.Children.Add(record13TextBlock);
            Grid.SetRow(record13TextBlock, 1);
            Grid.SetColumn(record13TextBlock, 3);

            stackPanel.Children.Add(recordGrid);
            #endregion Record Grid

            stackPanel.Children.Add(new Separator());

            #region Customer Grid
            Grid customerGrid = new Grid();

            customerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            customerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            customerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            customerGrid.ColumnDefinitions.Add(new ColumnDefinition());

            customerGrid.RowDefinitions.Add(new RowDefinition());
            customerGrid.RowDefinitions.Add(new RowDefinition());
            customerGrid.RowDefinitions.Add(new RowDefinition());
            customerGrid.RowDefinitions.Add(new RowDefinition());
            customerGrid.RowDefinitions.Add(new RowDefinition());
            customerGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock customerNameLabelTextBlock = new TextBlock();
            customerNameLabelTextBlock.Text = "Customer:";
            customerGrid.Children.Add(customerNameLabelTextBlock);
            Grid.SetRow(customerNameLabelTextBlock, 0);
            Grid.SetColumn(customerNameLabelTextBlock, 0);

            TextBlock customerNameTextBlock = new TextBlock();
            string customerFullName = string.Format(CultureInfo.InvariantCulture, "{0} {1}", customerTitle, customerName);
            customerNameTextBlock.Text = customerFullName;
            customerGrid.Children.Add(customerNameTextBlock);
            Grid.SetRow(customerNameTextBlock, 0);
            Grid.SetColumn(customerNameTextBlock, 1);
            Grid.SetColumnSpan(customerNameTextBlock, 3);

            TextBlock customerAddressLabelTextBlock = new TextBlock();
            customerAddressLabelTextBlock.Text = "Address:";
            customerGrid.Children.Add(customerAddressLabelTextBlock);
            Grid.SetRow(customerAddressLabelTextBlock, 1);
            Grid.SetColumn(customerAddressLabelTextBlock, 0);

            TextBlock customerAddressTextBlock = new TextBlock();
            customerAddressTextBlock.Text = customerAddress;
            customerGrid.Children.Add(customerAddressTextBlock);
            Grid.SetRow(customerAddressTextBlock, 1);
            Grid.SetColumn(customerAddressTextBlock, 1);
            Grid.SetColumnSpan(customerAddressTextBlock, 3);

            TextBlock customerPostcodeLabelTextBlock = new TextBlock();
            customerPostcodeLabelTextBlock.Text = "Postcode:";
            customerGrid.Children.Add(customerPostcodeLabelTextBlock);
            Grid.SetRow(customerPostcodeLabelTextBlock, 2);
            Grid.SetColumn(customerPostcodeLabelTextBlock, 0);

            TextBlock customerPostcodeTextBlock = new TextBlock();
            customerPostcodeTextBlock.Text = customerPostcode;
            customerGrid.Children.Add(customerPostcodeTextBlock);
            Grid.SetRow(customerPostcodeTextBlock, 2);
            Grid.SetColumn(customerPostcodeTextBlock, 1);

            TextBlock customerStateLabelTextBlock = new TextBlock();
            customerStateLabelTextBlock.Text = "State:";
            customerGrid.Children.Add(customerStateLabelTextBlock);
            Grid.SetRow(customerStateLabelTextBlock, 2);
            Grid.SetColumn(customerStateLabelTextBlock, 2);

            TextBlock customerStateTextBlock = new TextBlock();
            customerStateTextBlock.Text = customerState;
            customerGrid.Children.Add(customerStateTextBlock);
            Grid.SetRow(customerStateTextBlock, 2);
            Grid.SetColumn(customerStateTextBlock, 3);

            TextBlock customerPhoneLabelTextBlock = new TextBlock();
            customerPhoneLabelTextBlock.Text = "Phone:";
            customerGrid.Children.Add(customerPhoneLabelTextBlock);
            Grid.SetRow(customerPhoneLabelTextBlock, 3);
            Grid.SetColumn(customerPhoneLabelTextBlock, 0);

            TextBlock customerPhoneTextBlock = new TextBlock();
            customerPhoneTextBlock.Text = customerPhone;
            customerGrid.Children.Add(customerPhoneTextBlock);
            Grid.SetRow(customerPhoneTextBlock, 3);
            Grid.SetColumn(customerPhoneTextBlock, 1);
            Grid.SetColumnSpan(customerPhoneTextBlock, 3);

            TextBlock customerCompanyLabelTextBlock = new TextBlock();
            customerCompanyLabelTextBlock.Text = "Company:";
            customerGrid.Children.Add(customerCompanyLabelTextBlock);
            Grid.SetRow(customerCompanyLabelTextBlock, 4);
            Grid.SetColumn(customerCompanyLabelTextBlock, 0);

            TextBlock customerCompanyTextBlock = new TextBlock();
            customerCompanyTextBlock.Text = customerCompany;
            customerGrid.Children.Add(customerCompanyTextBlock);
            Grid.SetRow(customerCompanyTextBlock, 4);
            Grid.SetColumn(customerCompanyTextBlock, 1);
            Grid.SetColumnSpan(customerCompanyTextBlock, 3);

            TextBlock customerSalesPersonLabelTextBlock = new TextBlock();
            customerSalesPersonLabelTextBlock.Text = "Sales Person:";
            customerGrid.Children.Add(customerSalesPersonLabelTextBlock);
            Grid.SetRow(customerSalesPersonLabelTextBlock, 5);
            Grid.SetColumn(customerSalesPersonLabelTextBlock, 0);

            TextBlock customerSalesPersonTextBlock = new TextBlock();
            customerSalesPersonTextBlock.Text = salesPerson;
            customerGrid.Children.Add(customerSalesPersonTextBlock);
            Grid.SetRow(customerSalesPersonTextBlock, 5);
            Grid.SetColumn(customerSalesPersonTextBlock, 1);
            Grid.SetColumnSpan(customerSalesPersonTextBlock, 3);
            
            stackPanel.Children.Add(customerGrid);
            #endregion Customer Grid

            #region Product Grid
            BindingList<OrderDetail> orderDetails = SQLiteDB.Instance.OrderDetail(orderId);

            Grid productGrid = new Grid();

            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            productGrid.ColumnDefinitions.Add(new ColumnDefinition());
            

            productGrid.RowDefinitions.Add(new RowDefinition());
            Separator startSeparator = new Separator();
            productGrid.Children.Add(startSeparator);
            Grid.SetRow(startSeparator, 0);
            Grid.SetColumn(startSeparator, 0);
            Grid.SetColumnSpan(startSeparator, 7);

            productGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock productLabelTextBlock = new TextBlock();
            productLabelTextBlock.Text = "Product";
            productGrid.Children.Add(productLabelTextBlock);
            Grid.SetRow(productLabelTextBlock, 1);
            Grid.SetColumn(productLabelTextBlock, 0);

            TextBlock descriptionLabelTextBlock = new TextBlock();
            descriptionLabelTextBlock.Text = "Description";
            productGrid.Children.Add(descriptionLabelTextBlock);
            Grid.SetRow(descriptionLabelTextBlock, 1);
            Grid.SetColumn(descriptionLabelTextBlock, 1);

            TextBlock quantityLabelTextBlock = new TextBlock();
            quantityLabelTextBlock.Text = "Quantity";
            productGrid.Children.Add(quantityLabelTextBlock);
            Grid.SetRow(quantityLabelTextBlock, 1);
            Grid.SetColumn(quantityLabelTextBlock, 2);

            TextBlock priceLabelTextBlock = new TextBlock();
            priceLabelTextBlock.Text = "Unit Price";
            productGrid.Children.Add(priceLabelTextBlock);
            Grid.SetRow(priceLabelTextBlock, 1);
            Grid.SetColumn(priceLabelTextBlock, 3);

            TextBlock totalLabelTextBlock = new TextBlock();
            totalLabelTextBlock.Text = "Total (RM)";
            productGrid.Children.Add(totalLabelTextBlock);
            Grid.SetRow(totalLabelTextBlock, 1);
            Grid.SetColumn(totalLabelTextBlock, 4);

            TextBlock discountLabelTextBlock = new TextBlock();
            discountLabelTextBlock.Text = "Discount (%)";
            productGrid.Children.Add(discountLabelTextBlock);
            Grid.SetRow(discountLabelTextBlock, 1);
            Grid.SetColumn(discountLabelTextBlock, 5);

            TextBlock amountLabelTextBlock = new TextBlock();
            amountLabelTextBlock.Text = "Amount (RM)";
            productGrid.Children.Add(amountLabelTextBlock);
            Grid.SetRow(amountLabelTextBlock, 1);
            Grid.SetColumn(amountLabelTextBlock, 6);

            productGrid.RowDefinitions.Add(new RowDefinition());
            Separator middlerSeparator = new Separator();
            productGrid.Children.Add(middlerSeparator);
            Grid.SetRow(middlerSeparator, 2);
            Grid.SetColumn(middlerSeparator, 0);
            Grid.SetColumnSpan(middlerSeparator, 7);

            int count = 3;
            foreach (OrderDetail orderDetail in orderDetails)
            {
                productGrid.RowDefinitions.Add(new RowDefinition());

                TextBlock productTextBlock = new TextBlock();
                productTextBlock.Text = orderDetail.Product;
                productGrid.Children.Add(productTextBlock);
                Grid.SetRow(productTextBlock, count);
                Grid.SetColumn(productTextBlock, 0);

                TextBlock descriptionTextBlock = new TextBlock();
                descriptionTextBlock.Text = orderDetail.Description;
                productGrid.Children.Add(descriptionTextBlock);
                Grid.SetRow(descriptionTextBlock, count);
                Grid.SetColumn(descriptionTextBlock, 1);

                TextBlock quantityTextBlock = new TextBlock();
                quantityTextBlock.Text = orderDetail.Quantity.ToString();
                productGrid.Children.Add(quantityTextBlock);
                Grid.SetRow(quantityTextBlock, count);
                Grid.SetColumn(quantityTextBlock, 2);

                TextBlock priceTextBlock = new TextBlock();
                priceTextBlock.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderDetail.Price);
                productGrid.Children.Add(priceTextBlock);
                Grid.SetRow(priceTextBlock, count);
                Grid.SetColumn(priceTextBlock, 3);

                TextBlock totalTextBlock = new TextBlock();
                totalTextBlock.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderDetail.Cost);
                productGrid.Children.Add(totalTextBlock);
                Grid.SetRow(totalTextBlock, count);
                Grid.SetColumn(totalTextBlock, 4);

                TextBlock discountTextBlock = new TextBlock();
                discountTextBlock.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderDetail.DiscountPercent);
                productGrid.Children.Add(discountTextBlock);
                Grid.SetRow(discountTextBlock, count);
                Grid.SetColumn(discountTextBlock, 5);

                TextBlock amountTextBlock = new TextBlock();
                amountTextBlock.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00}", orderDetail.TotalCost);
                productGrid.Children.Add(amountTextBlock);
                Grid.SetRow(amountTextBlock, count);
                Grid.SetColumn(amountTextBlock, 6);

                count++;
            }

            productGrid.RowDefinitions.Add(new RowDefinition());
            Separator endSeparator = new Separator();
            productGrid.Children.Add(endSeparator);
            Grid.SetRow(endSeparator, count);
            Grid.SetColumn(endSeparator, 0);
            Grid.SetColumnSpan(endSeparator, 7);

            count++;

            productGrid.RowDefinitions.Add(new RowDefinition());
            TextBlock chargeLabelTextBlock = new TextBlock();
            chargeLabelTextBlock.Text = "Charge (RM):";
            chargeLabelTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(chargeLabelTextBlock);
            Grid.SetRow(chargeLabelTextBlock, count);
            Grid.SetColumn(chargeLabelTextBlock, 0);
            Grid.SetColumnSpan(chargeLabelTextBlock, 6);

            TextBlock chargeTextBlock = new TextBlock();
            string chargeText = string.Format(CultureInfo.InvariantCulture,
                "$ {0}", sum);
            chargeTextBlock.Text = chargeText;
            chargeTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(chargeTextBlock);
            Grid.SetRow(chargeTextBlock, count);
            Grid.SetColumn(chargeTextBlock, 6);            

            count++;

            productGrid.RowDefinitions.Add(new RowDefinition());
            TextBlock discountRmLabelTextBlock = new TextBlock();
            discountRmLabelTextBlock.Text = "Discount (RM):";
            discountRmLabelTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(discountRmLabelTextBlock);
            Grid.SetRow(discountRmLabelTextBlock, count);
            Grid.SetColumn(discountRmLabelTextBlock, 0);
            Grid.SetColumnSpan(discountRmLabelTextBlock, 6);

            TextBlock discountRmTextBlock = new TextBlock();
            string discountRmText = string.Format(CultureInfo.InvariantCulture,
                "$ {0}", discount);
            discountRmTextBlock.Text = discountRmText;
            discountRmTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(discountRmTextBlock);
            Grid.SetRow(discountRmTextBlock, count);
            Grid.SetColumn(discountRmTextBlock, 6);            

            count++;

            productGrid.RowDefinitions.Add(new RowDefinition());
            Separator beforeTotalSeparator = new Separator();
            productGrid.Children.Add(beforeTotalSeparator);
            Grid.SetRow(beforeTotalSeparator, count);
            Grid.SetColumn(beforeTotalSeparator, 0);
            Grid.SetColumnSpan(beforeTotalSeparator, 7);

            count++;

            productGrid.RowDefinitions.Add(new RowDefinition());
            TextBlock totalChargeLabelTextBlock = new TextBlock();
            totalChargeLabelTextBlock.Text = "Total Charge (RM):";
            totalChargeLabelTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(totalChargeLabelTextBlock);
            Grid.SetRow(totalChargeLabelTextBlock, count);
            Grid.SetColumn(totalChargeLabelTextBlock, 0);
            Grid.SetColumnSpan(totalChargeLabelTextBlock, 6);

            TextBlock totalChargeTextBlock = new TextBlock();
            string totalChargeText = string.Format(CultureInfo.InvariantCulture,
                "$ {0}", total);            
            totalChargeTextBlock.Text = totalChargeText;
            totalChargeTextBlock.TextAlignment = TextAlignment.Right;
            productGrid.Children.Add(totalChargeTextBlock);
            Grid.SetRow(totalChargeTextBlock, count);
            Grid.SetColumn(totalChargeTextBlock, 6);            

            count++;

            productGrid.RowDefinitions.Add(new RowDefinition());
            Separator afterTotalSeparator = new Separator();
            productGrid.Children.Add(afterTotalSeparator);
            Grid.SetRow(afterTotalSeparator, count);
            Grid.SetColumn(afterTotalSeparator, 0);
            Grid.SetColumnSpan(afterTotalSeparator, 7);

            stackPanel.Children.Add(productGrid);
            #endregion Product Grid

            #region Footer            
            TextBlock remarkTextBlock = new TextBlock();
            remarkTextBlock.Text = "Remarks:";
            stackPanel.Children.Add(remarkTextBlock);

            TextBlock noteTextBlock = new TextBlock();
            noteTextBlock.Text = "Goods sold are not returnable / Barang yang dijual tidak boleh dikembalikan.";
            stackPanel.Children.Add(noteTextBlock);

            TextBlock signTextBlock = new TextBlock();
            signTextBlock.Text = "------------------------------------";
            signTextBlock.TextAlignment = TextAlignment.Right;
            stackPanel.Children.Add(signTextBlock);

            TextBlock issuedTextBlock = new TextBlock();
            issuedTextBlock.Text = "Issued By / Dikeluarkan Oleh";
            issuedTextBlock.TextAlignment = TextAlignment.Right;
            stackPanel.Children.Add(issuedTextBlock);
            #endregion Footer

            Run runIndex = new Run(orderId);
            companyTextBlock.Inlines.Add(runIndex);    

            DocumentReference docReference = new DocumentReference();
            docReference.SetDocument(doc);
            fds.References.Add(docReference);

            return fds;
        }    
    }
}
