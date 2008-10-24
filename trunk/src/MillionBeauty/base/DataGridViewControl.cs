using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class DataGridViewControl : UserControl
    {
        public event EventHandler OkButtonClicked;
        public event EventHandler EnterKeyDowned;
        public event EventHandler DeleteKeyDowned;
        public event EventHandler EscapeKeyDowned;

        public DataGridViewControl()
        {
            InitializeComponent();

            // Custom DataGridView
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dataGridView.KeyDown += DataGridViewKeyDown;
            addButton.Click += AddButtonClick;
        }

        public object DataSetSource
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

        public DataGridViewRow SelectedRow
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

        public string AddButtonName
        {
            get { return addButton.Text; }
            set { addButton.Text = value; }
        }

        private void DataGridViewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    EnterKeyDown(sender);
                    break;
                case Keys.Delete:
                    DeleteKeyDown(sender);
                    break;
                case Keys.Escape:
                    EscapeKeyDown(sender);
                    break;
                default:
                    break;
            }
        }

        private void EnterKeyDown(object sender)
        {
            EventHandler eventHandler = EnterKeyDowned;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }

        private void DeleteKeyDown(object sender)
        {
            EventHandler eventHandler = DeleteKeyDowned;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }

        private void EscapeKeyDown(object sender)
        {
            EventHandler eventHandler = EscapeKeyDowned;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = OkButtonClicked;
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }        
    }
}
