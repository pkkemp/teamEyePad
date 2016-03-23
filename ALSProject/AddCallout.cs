using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class AddCallout : TextToSpeech
    {

        #region Constructors
        public AddCallout(bool isQwerty) : base(isQwerty)
        {
            btnSpeak.Visible = false;

            btnMenu.Text = "Exit\nwithout\nsaving";
            btnCallouts.Text = "Save";

            btnCallouts.Size = new Size(btnMenu.Size.Width, btnMenu.Size.Height);

            alsKeyboard.SetTextBoxLocation(new Point(alsAlarm1.Right + MainMenu.GAP, alsAlarm1.Top));

            Graphics g = CreateGraphics();
            btnSpeak.setFontSize();
            btnMenu.setFontSize();
            btnCallouts.setFontSize();

            if(isQwerty)
            alsKeyboard.setClearConfirmation(false);
        }
        #endregion

        #region Public Methods
        public ALSButton getSaveButton()
        {
            return btnCallouts;
        }
        #endregion

        #region Events
        protected override void btnMenu_Click(object sender, EventArgs e)
        {
            btnCallouts_Click(sender, e);
        }


        private void AddCallout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
