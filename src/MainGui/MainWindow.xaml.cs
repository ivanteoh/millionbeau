// <summary>
//     Main window.
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

namespace MillionBeauty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

#if (!DEBUG)          
            if (Properties.Settings.Default.GotDatabase)
            {
                this.Source = new Uri("Pages/MainPage.xaml", UriKind.Relative);                
            }
            else
            {
                Properties.Settings.Default.Upgrade();
                this.Height = 300;
                this.Width = 400;
                this.Source = new Uri("Pages/DatabasePage.xaml", UriKind.Relative);                
            }
#else
            // Debug code: Straight away run main form
            Properties.Settings.Default.Database = @"D:\work\Data\MillionBeautyDB.db";
            this.Height = 300;
            this.Width = 400;
            this.Source = new Uri("Pages/MainPage.xaml", UriKind.Relative);
            //this.Source = new Uri("Pages/DatabasePage.xaml", UriKind.Relative);
#endif            
        }              
    }
}
