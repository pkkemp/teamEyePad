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
using System.Threading;
using EyeXFramework;
using Tobii.EyeX.Framework;
using System.Speech.Synthesis;
using Timer = System.Windows.Forms.Timer;

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
        private CVInterface tobiiInt;
        private Notebook notebook;
        private Thread eyeTrackingThread;
        public const int GAP = 10;

        TextToSpeech texttospeech;
        Callout callout;
        SettingsForm settingsScreen;
        QuitForm quitScreen;
        Browser browser;

        Timer closeTimer;


        public UI()
        {
            InitializeComponent();
            this.self = this;
            initBECM();
            alarmBut.Click += new System.EventHandler(alarmBut_Click);
            




            //Temp code
            tobiiInt = new CVInterface();
            eyeTrackingThread = new Thread(tobiiInt.StartEyeTracking);
            eyeTrackingThread.Name = "Eye Tracking Thread";
            eyeTrackingThread.Start();

            SpeechSynthesizer voice = new SpeechSynthesizer();

            voice.SetOutputToDefaultAudioDevice();
            voice.Volume = 100;
            voice.SelectVoiceByHints(VoiceGender.Male);

            texttospeech = new TextToSpeech(this, voice);
            notebook = new Notebook(this, voice);
            callout = new Callout(this, voice);
            settingsScreen = new SettingsForm(this);
            quitScreen = new QuitForm(this);
            browser = new Browser(this);

            texttospeech.getCalloutBtn().Click += new System.EventHandler(this.openCallouts);
            settingsScreen.btnResetCallouts.Click += new System.EventHandler(this.resetCallouts);

            foreach (ALSButton btn in callout.getMenuBtns())
            {
                if (btn.Text == "Main Menu" || btn.Text == "Text to Speech")
                {
                    btn.Click += new System.EventHandler(this.closeCallouts);
                }
            }

            //listen for close
            closeTimer = new Timer();
            closeTimer.Enabled = true;
            closeTimer.Interval = 1000;
            closeTimer.Tick += new EventHandler(closeTimeEvent);
        }

        private void closeTimeEvent(object sender, EventArgs e)
        {

            if (callout != null && settingsScreen != null && texttospeech != null) {
                
                //this.Close();
            }


        }

        private void resetCallouts(object sender, EventArgs e)
        {
            callout.resetList();
         
        }

        private void closeCallouts(object sender, EventArgs e)
        {
            if(((ALSButton)sender).Text=="Main Menu")
            {
                this.Show();
                callout.Hide(); 
            }
            else if (((ALSButton)sender).Text == "Text to Speech")
            {
                texttospeech.Show();
                callout.Hide();
                
            }
        }

        public void openCallouts(object sender, EventArgs e)
        {
            callout.Show();
            texttospeech.Hide(); 
        }



        public void initBECM()
        {
            //becm = new BECM(Properties.Resources.buzz);
            becm = new BECM();
        }
        private void User_Interface_Load(object sender, EventArgs e)
        {
            drawButtons(sender, e);
            resizeScreen();
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
            callout.Show();
            this.Hide();
        }

        private void quitBut_Click(object sender, EventArgs e)
        {

            if (!alarmBut.isAlarmOn())
            {
                quitScreen.Show();
                this.Hide();

            }
        }

        private void setBut_Click(object sender, EventArgs e)
        {
            settingsScreen.Show();
            this.Hide();

        }

        private void setBut_MouseEnter(object sender, EventArgs e)
        {
        }


        private void alarmBut_Click(object sender, EventArgs e)
        {
            if (!alarmBut.isAlarmOn())
            {
                quitBut.BackColor = ALSButton.baseColor;
                quitBut.Enabled = true;
                alarmBut.Text = "Activate Alarm";

            }
            else
            {
                quitBut.BackColor = Color.Red;
                quitBut.Enabled = false;
                alarmBut.Text = "Deactivate Alarm";
            }


        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            notebook.Show();
            texttospeech.Hide();
        }

        private void ttsBut_Click(object sender, EventArgs e)
        {

            
            texttospeech.Show();
            this.Hide();
        }

        private void resizeScreen()
        {
            int height = (this.Height - 4 * UI.GAP) / 3;
            int width = (this.Width);


            alarmBut.Location = new Point(GAP, GAP);
            alarmBut.Size = new Size(height, height);

            btnMin.Location = new Point(GAP, 2 * GAP + height);
            btnMin.Size = new Size(height, height);

            btnBrowser.Location = new Point(GAP, 3 * GAP + 2 * height);
            btnBrowser.Size = new Size(height, height);

            ttsBut.Location = new Point(width / 2 - height / 2, GAP);
            ttsBut.Size = new Size(height, height);

            alsButton5.Location = new Point(width / 2 - height / 2, 2 * GAP + height);
            alsButton5.Size = new Size(height, height);

            setBut.Location = new Point(width / 2 - height / 2, 3 * GAP + 2 * height);
            setBut.Size = new Size(height, height);

            noteBut.Location = new Point(width - GAP - height, GAP);
            noteBut.Size = new Size(height, height);

            alsButton4.Location = new Point(width - GAP - height, 2 * GAP + height);
            alsButton4.Size = new Size(height, height);

            quitBut.Location = new Point(width - GAP - height, 3 * GAP + 2 * height);
            quitBut.Size = new Size(height, height);


        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            CVInterface.PleaseStop();
            Application.Exit();
            
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            browser.Show();
            this.Hide();
        }

    }


}  
