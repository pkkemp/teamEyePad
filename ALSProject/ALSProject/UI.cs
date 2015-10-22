using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class UI : Form
    {

        // main UI for our application
        // maximize and quit buttons are temporary

        /*
        I had to look up the difference between the constructor and Form_Load. Superficially they seem to do the same thing. The constructor
        is immediately called on creation regardless of whether the form is displayed or not. The _Load method is called when the form becomes
        visible to the user. I am moving the code to the _Load section because that allows all forms within our program to be created before
        any of the elements are loaded. This isn't necessarily helpful now but may be useful in the future.
*/

        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int WM_APPCOMMAND = 0x319;

        private bool alarmOn;
        private SoundPlayer player;
        public Form self { get; set; }

        public UI()
        {
            InitializeComponent();
            this.self = this;
            alarmOn = false;
            player = new SoundPlayer(Properties.Resources.buzz);
            player.Load();
        }

        private void User_Interface_Load(object sender, EventArgs e)
        {
            drawButtons(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void drawButtons(object sender, EventArgs e)
        {

        }



        private void alsButton4_Click(object sender, EventArgs e)
        {
           
            

        }

        private void quitBut_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Form quitScreen = new QuitForm(this);
            quitScreen.ShowDialog(); 
            
           

        }

        private void setBut_Click(object sender, EventArgs e)
        {

        }

        private void setBut_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.self.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        private void alarmBut_Click(object sender, EventArgs e)
        {
            if (alarmOn)
            {
                player.Stop();
                alarmOn = false;
                alarmBut.timeDivision = 10;
                alarmBut.Image = Properties.Resources.speaker_icon;
            } else
            {
                //Maximize volume
                for (int i = 0; i < 64; i++)
                { 
                    //my ears... they bleed. Disable the following line for authentic testing environment
                    //VolUp();
                }
                try
                {
                    player.PlayLooping();
                }
                catch (Exception) { }
                alarmOn = true;
                alarmBut.timeDivision = 50;
                
                alarmBut.Image = Properties.Resources.AlarmOff;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.self.WindowState = System.Windows.Forms.FormWindowState.Normal;

        }
    }
}
