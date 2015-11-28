using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ALSProject
{
    public partial class QuitForm : Form
    {

        Form parentForm;

        public QuitForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
            yesBut.dwellTimeInterval = 100;
            yesBut.btnType = ALSButton.ButtonType.immutable;
        }
        
        private void noBut_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void yesBut_Click(object sender, EventArgs e)
        {
            CVInterface.PleaseStop();
            Application.Exit();
        }
    }
}
