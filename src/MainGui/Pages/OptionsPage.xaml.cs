// <summary>
//     Options page.
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
using System.Reflection;
using Microsoft.Win32;
using System.Diagnostics;

namespace MillionBeauty
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();

            #region About Tag
            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            productNameLabel.Content = AssemblyProduct;
            versionLabel.Content = String.Format(
                CultureInfo.InvariantCulture, 
                Properties.Resources.Version, 
                AssemblyVersion);
            copyrightLabel.Content = AssemblyCopyright;
            descriptionTextBox.Text = AssemblyDescription;
            #endregion About Tag
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            databaseFrame.Navigate(new Uri("Pages/DatabasePage.xaml", UriKind.Relative));

            CompanyInfo companyInfo = DatabaseBuilder.Instance.CompanyInfo;

            companyNameTextBox.Text = companyInfo.CompanyName;
            companyNumberTextBox.Text = companyInfo.CompanyNumber;
            companyContactTextBox.Text = companyInfo.CompanyContact;
            EnableTextBox(false);
        }        

        #region Password Tag
        private void okButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
        }
        #endregion Password Tag

        #region Company Tag
        private void EnableTextBox(bool isEnabled)
        {
            companyNameTextBox.IsEnabled = isEnabled;
            companyNumberTextBox.IsEnabled = isEnabled;
            companyContactTextBox.IsEnabled = isEnabled;
            saveButton.IsEnabled = isEnabled;
            editButton.IsEnabled = !isEnabled;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            EnableTextBox(true);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            CompanyInfo companyInfo = new CompanyInfo();

            companyInfo.CompanyName = companyNameTextBox.Text;
            companyInfo.CompanyNumber = companyNumberTextBox.Text;
            companyInfo.CompanyContact = companyContactTextBox.Text;
            DatabaseBuilder.Instance.CompanyInfo = companyInfo;            
            EnableTextBox(false);      
        }
        #endregion Company Tag

        #region About Tag
        #region Assembly Attribute Accessors
        /// <summary>
        /// Gets the assembly title name.
        /// </summary>
        /// <value>The assembly title name.</value>
        public static string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!String.IsNullOrEmpty(titleAttribute.Title))
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>The assembly version.</value>
        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gets the assembly description.
        /// </summary>
        /// <value>The assembly description.</value>
        public static string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Gets the assembly product.
        /// </summary>
        /// <value>The assembly product.</value>
        public static string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Gets the assembly copyright.
        /// </summary>
        /// <value>The assembly copyright.</value>
        public static string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion Assembly Attribute Accessors

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/MainPage.xaml", UriKind.Relative));
        }
        #endregion About Tag

        
    }
}
