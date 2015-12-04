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
using System.Text.RegularExpressions;

namespace ALSProject
{
    public partial class TextToSpeech : Form
    {
        private new Form Parent;
        SpeechSynthesizer speaker;
        bool predictLock = false; //this prevents the textbox words from being overwritten constantly
        private ClearTextConfirmation clearTextConfirmation;

        public TextToSpeech(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();
            this.Parent = parent;

            // this.alsKeyboard.setRemainingVariables();
            clearTextConfirmation = new ClearTextConfirmation(this);
            //this.alsKeyboard.setupPreditionBox();

            speaker = voice;

            Graphics gr = CreateGraphics();
            btnCallouts.setFontSize(gr);
            btnMenu.setFontSize(gr);
            btnSpeak.setFontSize(gr);

            foreach (ALSButton btn in alsKeyboard.getPredictKeys())
            {
                btn.Click += new System.EventHandler(this.keypad_Click);
            }


            //space.Click += new System.EventHandler(this.space_Click);
            //clear.Click += new System.EventHandler(this.btnClear_Click);

            initControlsRecursive(this.Controls);
            this.MouseClick += (sender, e) =>
            {
                updateCursor();
                //*TODO Delete temporary code
                getCurrentSentence();
            };

            alsKeyboard.Location = new Point(UI.GAP, UI.GAP);
            alsKeyboard.SendToBack();

        }

        public ALSButton getCalloutBtn()
        {
            return btnCallouts;
        }

        private void keypad_Click(object sender, EventArgs e)
        {

            //String word = ((ALSButton)sender).Text;

            //if (!predictLock)
            //{
            //    key_DeleteWord(sender, e);
            //    predictLock = true;
            //}

            //if (textBox1.Text == "" || textBox1.Text[textBox1.Text.Length - 1].ToString() == " ")
            //{
            //    textBox1.Text += word + " ";
            //}
            //else
            //{
            //    textBox1.Text += " " + word + " ";
            //}

            //predictReset();

        }

        protected void predictReset()
        {
            this.alsKeyboard.resetPrediction();
        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Hide();
        }

        protected string getCurrentSentence()
        {
            //Assuming that we don't want the cursor to move around, we want this.
            string text = alsKeyboard.GetText();

            var finalSentence = Regex.Match(text, "[.!?][^.!?]*$");

            //If you do want to move the caret around use this, then concatenate them
            var firstHalf = Regex.Match(text.Substring(0, alsKeyboard.GetSelectionStart()), "[.!?][^.!?]*$");
            var secondHalf = Regex.Match(text.Substring(alsKeyboard.GetSelectionStart()), "[^.!?]*[.!?]");

            string sentence = "";

            if (firstHalf.Success)
            {
                MessageBox.Show(text.Substring(firstHalf.Index, firstHalf.Length));
            }

            if (secondHalf.Success)
            {
                MessageBox.Show(text.Substring(secondHalf.Index, secondHalf.Length));
                System.Diagnostics.Debug.WriteLine(Text.Substring(secondHalf.Index, secondHalf.Length));
            }

            //
            //if (match2.Success)
            //{
            //    sentence = textBox1.Text.Substring(match2.Index, textBox1.Text.Length-1);
            //}

            //Console.WriteLine("Current sentence = " + sentence + " ||..");
            return sentence;
        }

        protected void key_DeleteWord(object sender, EventArgs e)
        {
            string text = alsKeyboard.GetText();

            var match = Regex.Match(text, @"\w+\s*$");
            var match2 = Regex.Match(text, @"\w+\p{P}+\s*$");
            if (match.Success)
            {
                alsKeyboard.SetText(text.Substring(0, match.Index));
            }
            else if (match2.Success)
            {
                alsKeyboard.SetText(text.Substring(0, match2.Index));
            }
            predictReset();
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            clearTextConfirmation.Visible = true;
        }

        public void ClearText()
        {
            alsKeyboard.SetText("");
            predictReset();
            this.Enabled = true;
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
            speaker.SpeakAsync(alsKeyboard.GetText());
        }

        private void initControlsRecursive(System.Windows.Forms.Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => {
                    updateCursor();
                };
                initControlsRecursive(c.Controls);
            }
        }

        protected void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateCursor();
        }

        protected void updateCursor()
        {
            alsKeyboard.SetTextBoxFocus();
            alsKeyboard.SetSelection(alsKeyboard.GetText().Length, 0);
        }

        protected void alsButton3_Click(object sender, EventArgs e)
        {

        }

        protected void alsButton2_Click(object sender, EventArgs e)
        {

        }

        protected void alsButton1_Click(object sender, EventArgs e)
        {

        }

        protected void btnCallouts_Click(object sender, EventArgs e)
        {

        }

        public string GetText()
        {
            return alsKeyboard.GetText();
        }

        public void setText(string text)
        {
            if (text != null)
                alsKeyboard.SetText(text);
        }

        private void TextToSpeech_Resize(object sender, EventArgs e)
        {
            alsKeyboard.Size = new Size(Width - UI.GAP * 2, Height - UI.GAP * 2);
            alsKeyboard.SetTextBoxLocation(new Point(btnSpeak.Right, 0));
            alsKeyboard.SetTextBoxSize(new Size(btnCallouts.Left - btnSpeak.Right - UI.GAP * 2, btnCallouts.Height));
        }
    }
}