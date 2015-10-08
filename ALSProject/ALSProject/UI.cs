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
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();

            ALSButton[] buttons = new ALSButton[8];

            for(int i = 0; i < 8; i++)
            {
                buttons[i] = new ALSButton();
                buttons[i].Visible = true;
                buttons[i].Location = new System.Drawing.Point(i * 128+1, 1);
                buttons[i].Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right); // well this kinda works...
                //buttons[i].Dock = (DockStyle.Left | DockStyle.Right);
                Controls.Add(buttons[i]);
            }




        }

        private void User_Interface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }
    }
}
