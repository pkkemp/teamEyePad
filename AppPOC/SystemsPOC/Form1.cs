using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



///
///#include <windows.h>
///
///void GetMonitorResolution(int *horizontal, int *vertical) {
///    *height = GetSystemMetrics(SM_CYSCREEN);
///    *width = GetSystemMetrics(SM_CXSCREEN);
///}

namespace SystemsPOC
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer hoverTimer;
        System.Windows.Forms.Timer progressTimer;
        int progress;
        Button hoverButton;

        public Form1()
        {
            InitializeComponent();

            hoverTimer = new System.Windows.Forms.Timer();
            hoverTimer.Interval = 3000; 
            hoverTimer.Tick += new EventHandler(timer_Tick);

            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = hoverTimer.Interval/ 10;
            progressTimer.Tick += new EventHandler(progressTimer_Tick);
            progress = 0;

            WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Power button clicked");
            this.Hide();
            PowerConfirmation pc = new PowerConfirmation(this);
            pc.Show();

        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\buzz.wav";
                player.Load();
                player.Play();
            }
            catch (System.IO.FileNotFoundException ex) {}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSettings pc = new frmSettings(this);
            pc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Callouts pc = new Callouts(this);
            pc.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNotepad pc = new frmNotepad(this);
            pc.Show();

        }

        private void HandleMouseEnter(Button sender)
        {
            hoverButton = sender;
            hoverTimer.Start();
            progressTimer.Start();
        }

        private void HandleMouseLeave()
        {
            hoverButton = null;
            hoverTimer.Stop();
            progressTimer.Stop();
            progress = 0;
            label1.Text = "0";
        }

        void timer_Tick(object sender, EventArgs e)
        {
            hoverButton.PerformClick();
            hoverTimer.Stop();

            progress = 0;
            label1.Text =  "100";
            label1.Refresh();

            progressTimer.Stop();
        }

        void progressTimer_Tick(object sender, EventArgs e)
        {
            progress += 10;
            label1.Text = progress + "";
            label1.Refresh();
        }

        private void btnSpeech_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();
        }

        private void btnSpeech_MouseHover(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            HandleMouseEnter((Button)sender);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.HandleMouseLeave();
        }

    }
}
