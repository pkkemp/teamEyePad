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
    public partial class SettingsForm : Form
    {
        Form parentForm;
        ALSButton btnLock;
        ALSButton btnToggleKeyboard;
        ALSButton btnToggleDecay;
        ALSButton btnAbout;
        Slider sldrVoiceSpeed;
        frmAbout frmAboutPage;
        bool isQwerty = false;  //Shows if the program's keyboards are qwerty or large button 


        public SettingsForm(Form pForm)
        {
            InitializeComponent();
            parentForm = pForm;

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
            btnToggleKeyboard.Text = "Qwerty\nKeyboard";
            btnToggleKeyboard.Size = btnBack.Size;
            btnToggleKeyboard.Click += Toggle_Click;
            Controls.Add(btnToggleKeyboard);

            btnToggleDecay = new ALSButton();
            btnToggleDecay.Text = "Allow\nDecay";
            btnToggleDecay.Size = btnBack.Size;
            btnToggleDecay.Click += btnDecay_Click;
            Controls.Add(btnToggleDecay);

            btnAbout = new ALSButton();
            btnAbout.Text = "About";
            btnAbout.Size = btnBack.Size;
            btnAbout.Click += BtnAbout_Click;
            Controls.Add(btnAbout);

            sldrVoiceSpeed = new Slider("Voice Speed");
            sldrVoiceSpeed.BtnRight_Click += SldrVoiceSpeed_Btn_Click;
            sldrVoiceSpeed.BtnLeft_Click += SldrVoiceSpeed_Btn_Click;
            Controls.Add(sldrVoiceSpeed);

            sldrDwellTime.BtnRight_Click += SldrDwellTime_Btn_Click;
            sldrDwellTime.BtnLeft_Click += SldrDwellTime_Btn_Click;
            sldrKeyboard.BtnLeft_Click += SldrKeyboard_Btn_Click;
            sldrKeyboard.BtnRight_Click += SldrKeyboard_Btn_Click;

            frmAboutPage = new frmAbout();
            frmAboutPage.VisibleChanged += FrmAboutPage_VisibleChanged;

            updateSldrDwellTime();
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
            double voiceSpeed = sldrVoiceSpeed.value;
            MainMenu.SetVoiceSpeed((int)(voiceSpeed + .5) - 4);
        }

        private void SldrKeyboard_Btn_Click(object sender, EventArgs e)
        {
            updateSldrKeyboard();
        }

        private void SldrDwellTime_Btn_Click(object sender, EventArgs e)
        {
            updateSldrDwellTime();
        }

        private void _lock_Click(object sender, EventArgs e)
        {
            MainMenu.showLockScreen();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void updateSldrDwellTime()
        {
            ALSButton.setTimerSpeed(sldrDwellTime.value, ALSButton.ButtonType.normal);
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (btnLock == null)
                return;
            label1.Location = new Point(Width / 2 - label1.Width / 2, label1.Top);

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
            ((MainMenu)parentForm).SetKeyboard(isQwerty);
            ((ALSButton)sender).Text = isQwerty ? "Large\nButton\nKeyboard" : "Qwerty\nKeyboard";
        }

        private void btnDecay_Click(object sender, EventArgs e)
        {
            ALSButton.toggleDecay();
            ((ALSButton)sender).Text = ALSButton.getDecay() ? "Prevent\nDecay" : "Allow\nDecay";
        }
    }
}