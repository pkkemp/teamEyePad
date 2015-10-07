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
    public partial class AddSpeech : Form
    {
        Callouts callout;
        public AddSpeech(Callouts callout)
        {
            InitializeComponent();
            this.callout = callout;
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String language = textBox1.Text;
            if (!language.Equals(""))
            {
                callout.AddItem(language);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
