using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class OrderDetailsControl : UserControl
    {
        public event EventHandler AddButtonClicked;
        public event EventHandler EnterKeyDowned;
        public event EventHandler DeleteKeyDowned;
        public event EventHandler EscapeKeyDowned;
        private bool readOnly;

        public OrderDetailsControl()
        {
            InitializeComponent();

            // Custom DataGridView
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MouseDown += DataGridViewMouseDown;
            dataGridView.RowContextMenuStripNeeded += DataGridViewRowContextMenuStripNeeded;

            editToolStripMenuItem.Click += EditToolStripMenuItemClick;
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItemClick;

            dataGridView.KeyDown += DataGridViewKeyDown;
            addButton.Click += AddButtonClick;
        }

            

        public object DataSetSource
        {
            get
            {
                return bindingSource.DataSource;
            }
            set
            {
                bindingSource.DataSource = value;
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

        public void ReadOnly()
        {
            readOnly = true;
            dataGridView.ReadOnly = true;
            addButton.Enabled = false;
        }

        public void EditView()
        {
            readOnly = false;
            dataGridView.ReadOnly = true;
            addButton.Enabled = true;
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
            EventHandler eventHandler = AddButtonClicked;
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }

        public void DeleteRow(DataGridViewRow row)
        {
            if (row == null)
                return;

            dataGridView.Rows.Remove(row);
        }

        private void DataGridViewMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            int rowIndex;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dataGridView.HitTest(e.X, e.Y);
                rowIndex = hitTestInfo.RowIndex;
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell &&
                    !dataGridView.Rows[rowIndex].Selected)
                {
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.None &&
                        (Control.ModifierKeys & Keys.Control) == Keys.None)
                    {
                        dataGridView.ClearSelection();
                    }
                    dataGridView.Rows[rowIndex].Selected = true;
                }
            }
        }  

        private void DataGridViewRowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            if (dataGridView.CurrentCell == null || readOnly)
            {
                e.ContextMenuStrip = null;
            }
            else
            {
                e.ContextMenuStrip = contextMenuStrip;
            }
        }

        private void EditToolStripMenuItemClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = EnterKeyDowned;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            EventHandler eventHandler = DeleteKeyDowned;
            if (eventHandler != null)
            {
                eventHandler(sender, EventArgs.Empty);
            }
        }        
    }
}
