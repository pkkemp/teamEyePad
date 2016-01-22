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
    public partial class Email : Form
    {
        Form parent;

        public Email(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Hide();

        }
    }
}
