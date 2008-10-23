using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class DataViewForm : Form
    {
        public DataViewForm()
        {
            InitializeComponent();

            // Custom DataGridView
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            KeyDown += DataViewtFormKeyDown;
            dataGridView.KeyDown += DataGridViewKeyDown;
            addButton.Click += AddButtonClick;
            Load += DataViewFormLoad;
        }

        protected object DataSetSource
        {
            get
            {
                return dataGridView.DataSource;
            }
            set
            {
                dataGridView.DataSource = value;
            }
        }

        protected DataGridViewRow SelectedRow
        {
            get
            {
                if (dataGridView.SelectedRows != null && dataGridView.SelectedRows.Count == 1)
                {
                    return dataGridView.SelectedRows[0];
                }
                else
                {
                    return null;
                }
            }
        }

        protected string AddButtonName
        {
            get { return addButton.Text; }
            set { addButton.Text = value; }
        }

        private void DataViewtFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    ShowAddDialog();
                    break;
                default:
                    break;
            }
        }

        private void DataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowEnterDialog();
                    break;
                case Keys.Delete:
                    ShowDeleteDialog();
                    break;
                case Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        protected virtual void ShowAddDialog()
        {
        }

        protected virtual void ShowEnterDialog()
        {
        }

        protected virtual void ShowDeleteDialog()
        {
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddButtonClicked();
        }

        internal protected virtual void AddButtonClicked()
        {
        }

        private void DataViewFormLoad(object sender, EventArgs e)
        {
            FormLoad();
        }

        internal protected virtual void FormLoad()
        {
        }
    }
}
