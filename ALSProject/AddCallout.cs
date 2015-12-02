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
        public AddCallout(Form parent, SpeechSynthesizer voice) : base (parent, voice)
        {
            btnSpeak.Visible = false;
           // this.Controls.Remove(btnCallouts);
            //btnCallouts = new ALSButton();
            //this.Controls.Add(btnCallouts);
            
            btnMenu.Text = "Exit\nwithout\nsaving";
            btnCallouts.Text = "Save";

            //btnCallouts.Location = new Point(Width - UI.GAP, btnMenu.Top);
            btnCallouts.Size = new Size(btnMenu.Size.Width, btnMenu.Size.Height);

            alsKeyboard.SetTextBoxLocation(new Point(alsAlarm1.Right + UI.GAP, alsAlarm1.Top));
            
            //textBox1.Visible = false;
        }

        private void AddCallout_Resize(object sender, EventArgs e)
        {
            btnCallouts.Location = new Point(this.Width - btnCallouts.Width - 2 * UI.GAP, btnMenu.Top);
            alsKeyboard.SetTextBoxSize(new Size(btnCallouts.Location.X, alsAlarm1.Size.Height));
        }

        public ALSButton getSaveButton()
        {
            return btnCallouts;
        }
    }
}
