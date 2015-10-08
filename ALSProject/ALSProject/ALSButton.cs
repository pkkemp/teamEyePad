using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class ALSButton : UserControl
    {
        public ALSButton()
        {
            InitializeComponent();
        }

        private void ALSButton_Load(object sender, EventArgs e)
        {

        }

        private void ALSButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void ALSButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
        }


        //this doesn't work the way it should so I am disabling it
        private void ALSButton_Resize(object sender, EventArgs e)
        {
            //this.Width = Screen.FromControl(this).Bounds.Width / 8;
        }
    }
}
