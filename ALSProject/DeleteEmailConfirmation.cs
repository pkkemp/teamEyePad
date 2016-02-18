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
    public partial class DeleteEmailConfirmation : Form
    {
        public delegate void Response(bool isConfirmation);
        public event Response DeleteEmail_Click;
        
        public DeleteEmailConfirmation()
        {
            InitializeComponent();

            confirmation1.Confirm.Click += Confirm_Click;
            confirmation1.Cancel.Click += Cancel_Click;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (DeleteEmail_Click != null)
                DeleteEmail_Click(true);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (DeleteEmail_Click != null)
                DeleteEmail_Click(false);
        }

        private void DeleteEmailConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
