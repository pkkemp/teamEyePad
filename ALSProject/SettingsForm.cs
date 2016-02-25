using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ALSProject
{
    public partial class SettingsForm : Form
    {
        ALSButton btnLock;
        ALSButton btnToggleKeyboard;
        ALSButton btnToggleDecay;
        ALSButton btnAbout;
        Slider sldrDwellTime, sldrKeyboard, sldrVoiceSpeed;
        frmAbout frmAboutPage;
        bool isQwerty;  //Shows if the program's keyboards are qwerty or large button 
        bool isDecay = false;
        //The reason these are necessary is because the form closing needs them for the form closing portion
        private double dwellTime, keyboardDwellTime, voiceSpeed;

        public delegate void MainMenuClick(object sender, EventArgs args);
        public event MainMenuClick MainMenu_Click;

        public delegate void ChangeKeyboard_Click(bool isQwerty);
        public event ChangeKeyboard_Click ToggleKeyboard;

        public SettingsForm()
        {
            InitializeComponent();

            dwellTime = -1;
            keyboardDwellTime = -1;
            voiceSpeed = -1;
            try
            {
                //XDocument doc = XDocument.Load();
                XmlDataDocument doc = new XmlDataDocument();
                //var doc = new XmlDocument();
                FileStream fs = new FileStream("settings.xml", FileMode.Open, FileAccess.Read);
                doc.Load(fs);

                XmlNode xmlnode = doc.FirstChild; //doc.GetElementsByTagName("wrench");
                xmlnode = xmlnode.NextSibling;
               
                isQwerty = xmlnode["keyboard"].InnerText.Equals("Qwerty");
                isDecay = xmlnode["decay"].InnerText.Equals("Decay");
                dwellTime = Convert.ToInt32(xmlnode["dwellTime"].InnerText);
                keyboardDwellTime = Convert.ToInt32(xmlnode["keyboardDwellTime"].InnerText);
                voiceSpeed = Convert.ToInt32(xmlnode["voiceSpeed"].InnerText);
            }
            catch (Exception) {}

            

            btnAlarm.BackgroundImageLayout = ImageLayout.Zoom;

            btnAlarm.setFontSize();
            btnBack.setFontSize();
            btnResetCallouts.setFontSize();

            btnLock = new ALSButton();
            btnLock.BackgroundImage = Properties.Resources.Lock;
            btnLock.BackgroundImageLayout = ImageLayout.Zoom;
            btnLock.Click += _lock_Click;
            btnLock.Size = btnBack.Size;
            Controls.Add(btnLock);

            btnToggleKeyboard = new ALSButton();
            btnToggleKeyboard.Text = isQwerty ? "Large\nButton\nKeyboard" :"Qwerty\nKeyboard";
            btnToggleKeyboard.Size = btnBack.Size;
            btnToggleKeyboard.Click += Toggle_Click;
            Controls.Add(btnToggleKeyboard);

            btnToggleDecay = new ALSButton();
            btnToggleDecay.Text = isDecay ? "Prevent\nDecay" : "Allow\nDecay";
            btnToggleDecay.Size = btnBack.Size;
            btnToggleDecay.Click += btnDecay_Click;
            Controls.Add(btnToggleDecay);

            btnAbout = new ALSButton();
            btnAbout.Text = "About";
            btnAbout.Size = btnBack.Size;
            btnAbout.Click += BtnAbout_Click;
            Controls.Add(btnAbout);

            if (voiceSpeed != -1)
            {
                sldrDwellTime = new Slider("Dwell Time", dwellTime);
                sldrKeyboard = new Slider("Keyboard Dwell Time", keyboardDwellTime);
                sldrVoiceSpeed = new Slider("Voice Speed", voiceSpeed);
            }
            else
            {
                sldrDwellTime = new Slider("Dwell Time");
                sldrKeyboard = new Slider("Keyboard Dwell Time");
                sldrVoiceSpeed = new Slider("Voice Speed");

            }
            Controls.Add(sldrDwellTime);
            Controls.Add(sldrKeyboard);
            Controls.Add(sldrVoiceSpeed);
            
            sldrDwellTime.BtnRight_Click += SldrDwellTime_Btn_Click;
            sldrDwellTime.BtnLeft_Click += SldrDwellTime_Btn_Click;
            sldrKeyboard.BtnLeft_Click += SldrKeyboard_Btn_Click;
            sldrKeyboard.BtnRight_Click += SldrKeyboard_Btn_Click;
            sldrVoiceSpeed.BtnRight_Click += SldrVoiceSpeed_Btn_Click;
            sldrVoiceSpeed.BtnLeft_Click += SldrVoiceSpeed_Btn_Click;

            frmAboutPage = new frmAbout();
            frmAboutPage.VisibleChanged += FrmAboutPage_VisibleChanged;

            updateSldrDwellTime();

            dwellTime = sldrDwellTime.value;
            keyboardDwellTime = sldrDwellTime.value;
            voiceSpeed = sldrVoiceSpeed.value;
        }

        private void FrmAboutPage_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!((Form)sender).Visible)
                    this.Show();
            }
            catch (Exception) { }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            frmAboutPage.Show();
            this.Hide();
        }

        private void SldrVoiceSpeed_Btn_Click(object sender, EventArgs e)
        {
            voiceSpeed = sldrVoiceSpeed.value;
            MainMenu.SetVoiceSpeed((int)(voiceSpeed + .5) - 4);
        }

        private void SldrKeyboard_Btn_Click(object sender, EventArgs e)
        {
            keyboardDwellTime = sldrKeyboard.value;
            updateSldrKeyboard();
        }

        private void SldrDwellTime_Btn_Click(object sender, EventArgs e)
        {
            dwellTime = sldrDwellTime.value;
            updateSldrDwellTime();
        }

        private void _lock_Click(object sender, EventArgs e)
        {
            MainMenu.showLockScreen();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (MainMenu_Click != null)
                MainMenu_Click(this, e);
        }

        private void updateSldrDwellTime()
        {
            ALSButton.setTimerSpeed(sldrDwellTime.value, ALSButton.ButtonType.normal);
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (btnLock == null)
                return;

            int btnWidth = (Width - MainMenu.GAP * 8) / 7;
            btnAlarm.Size = new Size(btnWidth, btnWidth);
            btnAbout.Size = new Size(btnWidth, btnWidth);
            btnResetCallouts.Size = new Size(btnWidth, btnWidth);
            btnToggleKeyboard.Size = new Size(btnWidth, btnWidth);
            btnToggleDecay.Size = new Size(btnWidth, btnWidth);
            btnLock.Size = new Size(btnWidth, btnWidth);
            btnBack.Size = new Size(btnWidth, btnWidth);

            btnAlarm.Location = new Point(MainMenu.GAP, MainMenu.GAP);
            btnAbout.Location = new Point(MainMenu.GAP + btnAlarm.Right, MainMenu.GAP);
            btnResetCallouts.Location = new Point(MainMenu.GAP + btnAbout.Right, MainMenu.GAP);
            btnToggleKeyboard.Location = new Point(MainMenu.GAP + btnResetCallouts.Right, MainMenu.GAP);
            btnToggleDecay.Location = new Point(MainMenu.GAP + btnToggleKeyboard.Right, MainMenu.GAP);
            btnLock.Location = new Point(MainMenu.GAP + btnToggleDecay.Right, MainMenu.GAP);
            btnBack.Location = new Point(MainMenu.GAP + btnLock.Right, MainMenu.GAP);

            int sliderHeight = (Height - MainMenu.GAP * 4 - btnAlarm.Bottom) / 3;
            sldrDwellTime.Size = new Size(Width - 2 * MainMenu.GAP, sliderHeight);
            sldrKeyboard.Size = sldrDwellTime.Size;
            sldrVoiceSpeed.Size = sldrDwellTime.Size;

            sldrDwellTime.Location = new Point(MainMenu.GAP, btnAlarm.Bottom + MainMenu.GAP);
            sldrKeyboard.Location = new Point(MainMenu.GAP, sldrDwellTime.Bottom + MainMenu.GAP);
            sldrVoiceSpeed.Location = new Point(MainMenu.GAP, sldrKeyboard.Bottom + MainMenu.GAP);
        }

        private void updateSldrKeyboard()
        {
            ALSButton.setTimerSpeed(sldrKeyboard.value, ALSButton.ButtonType.key);
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            isQwerty = !isQwerty;
            if (ToggleKeyboard != null)
                ToggleKeyboard(isQwerty);
            ((ALSButton)sender).Text = isQwerty ? "Large\nButton\nKeyboard" : "Qwerty\nKeyboard";
        }

        private void btnDecay_Click(object sender, EventArgs e)
        {
            ALSButton.toggleDecay();
            isDecay = !isDecay;
            ((ALSButton)sender).Text = isDecay ? "Prevent\nDecay" : "Allow\nDecay";
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<item><name>Settings</name></item>");

                // Add a price element.
                XmlElement keyboard = doc.CreateElement("keyboard");
                keyboard.InnerText = isQwerty ? "Qwerty" : "Large Button";
                doc.DocumentElement.AppendChild(keyboard);

                XmlElement decay = doc.CreateElement("decay");
                decay.InnerText = isDecay ? "Decay" : "No Decay";
                doc.DocumentElement.AppendChild(decay);

                XmlElement xmlDwellTime = doc.CreateElement("dwellTime");
                xmlDwellTime.InnerText = dwellTime.ToString();
                doc.DocumentElement.AppendChild(xmlDwellTime);

                XmlElement xmlKeyboardDwellTime = doc.CreateElement("keyboardDwellTime");
                xmlKeyboardDwellTime.InnerText = keyboardDwellTime.ToString();
                doc.DocumentElement.AppendChild(xmlKeyboardDwellTime);

                XmlElement xmlVoiceSpeed = doc.CreateElement("voiceSpeed");
                xmlVoiceSpeed.InnerText = voiceSpeed.ToString();
                doc.DocumentElement.AppendChild(xmlVoiceSpeed);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                // Save the document to a file and auto-indent the output.
                XmlWriter writer = XmlWriter.Create("settings.xml", settings);
                doc.Save(writer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Application.Exit();
        }
    }

    public class SettingsEventArgs : EventArgs
    {
        private bool isQwerty;

        public SettingsEventArgs(bool isQwerty)
        {
            this.isQwerty = isQwerty;
        }

        public bool getIsQwerty()
        {
            return isQwerty;
        }
    }
}