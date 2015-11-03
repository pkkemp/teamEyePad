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
    public partial class QuitForm : Form
    {

        Form parentForm;

        public QuitForm(Form parent)
        {
            InitializeComponent();
            parentForm = parent;
        }
        
        private void noBut_Click(object sender, EventArgs e)
        {
            parentForm.Visible = true;
            this.Close();
        }

        private void yesBut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
