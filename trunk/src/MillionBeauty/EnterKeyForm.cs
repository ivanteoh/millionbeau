using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MillionBeauty
{
    public partial class EnterKeyForm : Form
    {
        public EnterKeyForm()
        {
            InitializeComponent();
        }

        public string Key
        {
            get { return keyTextBox.Text; }
        }
    }
}
