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
        bool isQwerty = false;  //Shows if the program's keyboards are qwerty or large button 
        //TODO: make a setting for keyboard button speed vs all ALSButton speed

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

            updateSldrDwellTime();
        }

        private void _lock_Click(object sender, EventArgs e)
        {
            MainMenu.showLockScreen();
        }

        private void alsButton1_Click(object sender, EventArgs e)
        {
            sldrDwellTime.UpdatePos(Slider.direction.LEFT);
            updateSldrDwellTime();
        }

        private void alsButton2_Click(object sender, EventArgs e)
        {
            sldrDwellTime.UpdatePos(Slider.direction.RIGHT);
            updateSldrDwellTime();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void updateSldrDwellTime()
        {
            //label2.Text = "" + slider1.value;
            ALSButton.setTimerSpeed(sldrDwellTime.value, ALSButton.ButtonType.normal);
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            if (btnLock == null)
                return;
            label1.Location = new Point(Width / 2 - label1.Width / 2, label1.Top);
            btnLock.Location = new Point(Width - btnLock.Size.Width - MainMenu.GAP, Height - btnLock.Size.Height - MainMenu.GAP);
            btnToggleKeyboard.Location = new Point(btnLock.Left - btnToggleKeyboard.Width - MainMenu.GAP, btnLock.Top);
        }

        private void btnKeyboardLeft_Click(object sender, EventArgs e)
        {
            sldrKeyboard.UpdatePos(Slider.direction.LEFT);
            updateSldrKeyboard();
        }

        private void updateSldrKeyboard()
        {
            ALSButton.setTimerSpeed(sldrKeyboard.value, ALSButton.ButtonType.key);
        }

        private void btnKeyboardRight_Click(object sender, EventArgs e)
        {
            sldrKeyboard.UpdatePos(Slider.direction.RIGHT);
            updateSldrKeyboard();
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
            isQwerty = !isQwerty;
            ((MainMenu)parentForm).SetKeyboard(isQwerty);
            ((ALSButton)sender).Text = isQwerty ? "Large\nButton\nKeyboard" : "Qwerty\nKeyboard";
        }
    }
}
