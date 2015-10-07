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
    public partial class frmNotepad : Form
    {
        Form sender;
        public frmNotepad(Form sender)
        {
            InitializeComponent();
            this.sender = sender;
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.sender.Show();
            }
            catch (Exception ex) { }
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\buzz.mp3";
                player.Load();
                player.Play();
            }
            catch (System.IO.FileNotFoundException ex) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            KeyboardV1 kb = new KeyboardV1();
            kb.Show();
        }
    }
}
