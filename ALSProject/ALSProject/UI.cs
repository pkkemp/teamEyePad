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

  
        public Form self { get; set; }
        private BECM becm;

        public UI()
        {
            InitializeComponent();
            this.self = this;
            initBECM();

        }


        public void initBECM()
        {
            becm = new BECM(new SoundPlayer(Properties.Resources.buzz));

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
            if (!becm.getAlarmState())
            {
                this.Visible = false;
                Form quitScreen = new QuitForm(this);
                quitScreen.ShowDialog();
            }
            
           

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

        



        private void alarmBut_Click(object sender, EventArgs e)
        {
            if (!becm.alarmAction())
            {
                alarmBut.timeDivision = ALSButton.defaultTimeDivision;
                alarmBut.Image = Properties.Resources.speaker_icon;
                quitBut.BackColor = ALSButton.baseColor;
                quitBut.Enabled = true;

            }
            else
            {
                alarmBut.timeDivision = 50;
                alarmBut.Image = Properties.Resources.AlarmOff;
                quitBut.BackColor = Color.Red;
                quitBut.Enabled = false;
            }

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.self.WindowState = System.Windows.Forms.FormWindowState.Normal;

        }
    }
}
