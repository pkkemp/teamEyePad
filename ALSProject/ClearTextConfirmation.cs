using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class ClearTextConfirmation : Form
    {
        public delegate void Event(bool confirm);
        public event Event ClearText_Click;

        public ClearTextConfirmation()
        {
            InitializeComponent();
            confirmation1.Cancel.Click += new EventHandler(Cancel);
            confirmation1.Confirm.Click += new EventHandler(Confirm);
        }

        private void Cancel(object sender, EventArgs e)
        {
            Hide();
            if (ClearText_Click != null)
                ClearText_Click(false);
        }

        private void Confirm(object sender, EventArgs e)
        {
            Hide();
            if (ClearText_Click != null)
                ClearText_Click(true);
        }

        private void ClearTextConfirmation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
