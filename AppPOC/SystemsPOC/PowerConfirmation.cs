using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SystemsPOC
{
    public partial class PowerConfirmation : Form
    {
        private Form sender;

        public PowerConfirmation(Form sender)
        {
            InitializeComponent();
            this.sender = sender;
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.sender.Show();
            }
            catch (Exception ex) { }
            this.Close();
        }
    }
}
