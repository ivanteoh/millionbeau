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

            dataGridViewControl.EnterKeyDowned += DataGridViewControlEnterKeyDowned;
            dataGridViewControl.DeleteKeyDowned += DataGridViewControlDeleteKeyDowned;
            dataGridViewControl.EscapeKeyDowned += DataGridViewControlEscapeKeyDowned;
            dataGridViewControl.AddButtonClicked += DataGridViewControlAddButtonClicked;
            KeyDown += DataViewFormKeyDown;
            Load += DataViewFormLoad;
        }

        protected bool ReadOnly 
        {
            get { return dataGridViewControl.ReadOnly; }
            set { dataGridViewControl.ReadOnly = value; }
        }

        protected object DataSetSource
        {
            get
            {
                return dataGridViewControl.DataSetSource;
            }
            set
            {
                dataGridViewControl.DataSetSource = value;
            }
        }

        protected DataGridViewRow SelectedRow
        {
            get
            {
                return dataGridViewControl.SelectedRow;
            }
        }

        protected string AddButtonName
        {
            get { return dataGridViewControl.AddButtonName; }
            set { dataGridViewControl.AddButtonName = value; }
        }

        private void DataViewFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    ShowAddDialog();
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

        private void DataGridViewControlEnterKeyDowned(object sender, EventArgs e)
        {
            ShowEnterDialog();
        }

        protected virtual void ShowEnterDialog()
        {
        }

        private void DataGridViewControlDeleteKeyDowned(object sender, EventArgs e)
        {
            ShowDeleteDialog();
        }

        protected virtual void ShowDeleteDialog()
        {
        }

        private void DataGridViewControlEscapeKeyDowned(object sender, EventArgs e)
        {
            Close();
        }

        private void DataGridViewControlAddButtonClicked(object sender, EventArgs e)
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
