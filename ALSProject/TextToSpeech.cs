using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace ALSProject
{
    public partial class TextToSpeech : Form
    {
        private new Form Parent;
        SpeechSynthesizer speaker;
        public TextToSpeech(Form parent)
        {
            this.Parent = parent;
            InitializeComponent();
            this.alsKeyboard.setRemainingVariables();
            speaker = new SpeechSynthesizer();
   
            speaker.SetOutputToDefaultAudioDevice();
            speaker.Volume = 100;
            speaker.SelectVoiceByHints(VoiceGender.Male);

            ALSButton[][] keyboard = this.alsKeyboard.getKeyboard();
            ALSButton space = this.alsKeyboard.getSpace();
            foreach (ALSButton[] rows in keyboard)
                foreach (ALSButton column in rows)
                    column.Click += new System.EventHandler(this.key_Click);

            space.Click += new System.EventHandler(this.space_Click);
            

            
        }

        private void space_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(" ");
        }

        private void alsButton1_Click(object sender, EventArgs e)
        {
            Parent.Visible = true;
            this.Close();
        }

        private void key_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((ALSButton)sender).Text;
        }



        private void TextToSpeech_Load(object sender, EventArgs e)
        {
        }

        

        private void alsButton3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void alsButton2_Click(object sender, EventArgs e)
        {
            speaker.SpeakAsync(textBox1.Text);
        }
    }
}
