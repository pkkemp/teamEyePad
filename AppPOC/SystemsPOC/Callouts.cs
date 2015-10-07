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
    public partial class Callouts : Form
    {
        private Form sender;
        public Callouts(Form sender)
        {
            InitializeComponent();
            this.sender = sender;
            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.Application.Exit();
        //}

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
                player.SoundLocation = @"C:\applause_y.wav";
                player.Load();
                player.Play();
            }
            catch (System.IO.FileNotFoundException ex) { }
        }

        public void AddItem(String item)
        {
            this.listBox1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSpeech addSpeech = new AddSpeech(this);
            addSpeech.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex != -1)
            {
                listBox1.Items.RemoveAt(selectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KeyboardV1 kb = new KeyboardV1();
            kb.Show();

        }
    }
}
