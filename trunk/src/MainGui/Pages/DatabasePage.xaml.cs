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
using Microsoft.Win32;
using System.Reflection;
using System.Globalization;

namespace MillionBeauty
{
    /// <summary>
    /// Interaction logic for DatabasePage.xaml
    /// </summary>
    public partial class DatabasePage : Page
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        private bool forceRestart;

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Properties.Settings.Default.GotDatabase)
            {
                forceRestart = true;
            }
            databaseTextBlock.Text = Properties.Settings.Default.Database;
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory =
                System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            saveFileDialog.Title = Properties.Resources.SaveFileTitle;
            saveFileDialog.Filter = Properties.Resources.FileFilter;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }

            if (System.IO.File.Exists(saveFileDialog.FileName))
            {
                System.IO.File.Delete(saveFileDialog.FileName);
            }

            string connectionString = string.Format(
                CultureInfo.InvariantCulture,
                Properties.Resources.DataSource,
                saveFileDialog.FileName);
            Core.NewDatabase(connectionString);

            if (forceRestart || MessageBox.Show(
                Properties.Resources.RestartApplication,
                Properties.Resources.Title, MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.Yes,
                MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading) ==
                MessageBoxResult.Yes)
            {
                Properties.Settings.Default.GotDatabase = true;
                Properties.Settings.Default.Database = saveFileDialog.FileName;
                Properties.Settings.Default.Save();
                System.Windows.Forms.Application.Restart();
                Application.Current.Shutdown();
            }
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory =
                System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            openFileDialog.Title = Properties.Resources.OpenFileTitle;
            openFileDialog.Filter = Properties.Resources.FileFilter;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            string connectionString = string.Format(
                CultureInfo.InvariantCulture,
                Properties.Resources.DataSource,
                openFileDialog.FileName);
            Core.LoadDatabase(connectionString);

            MessageBox.Show(
                Properties.Resources.RestartLoadDatabase,
                Properties.Resources.Title,
                MessageBoxButton.OK,
                MessageBoxImage.Information,
                MessageBoxResult.OK,
                MessageBoxOptions.RightAlign & MessageBoxOptions.RtlReading);
            Properties.Settings.Default.GotDatabase = true;
            Properties.Settings.Default.Database = openFileDialog.FileName;
            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }
    }
}
