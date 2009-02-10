// <summary>
//     Main page.
// </summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace MillionBeauty
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/OptionsPage.xaml", UriKind.Relative));     
        }

        private void customersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/CustomersPage.xaml", UriKind.Relative));
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = string.Format(CultureInfo.InvariantCulture, Properties.Resources.DataSource, Properties.Settings.Default.Database);
            Core.LoadDatabase(connectionString);
        }
    }
}
