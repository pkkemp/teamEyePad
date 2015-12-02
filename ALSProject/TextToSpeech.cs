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
        String buffer = "";
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

            //ALSButton[][] keyboard = this.alsKeyboard.getKeyboard();
            //ALSButton space = this.alsKeyboard.getSpace();
            //ALSButton clear = this.alsKeyboard.getClear();
            //foreach (ALSButton[] rows in keyboard)
            //    foreach (ALSButton column in rows)
            //    {
            //        if (column.Text == "Backspace")
            //        {
            //            column.Click += new System.EventHandler(this.key_Backspace);
            //            column.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //        }
            //        else if (column.Text == "Delete\nWord")
            //        {
            //            column.Click += new System.EventHandler(this.key_DeleteWord);
            //            column.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        }
            //        else
            //        {
            //            column.Click += new System.EventHandler(this.key_Click);
            //            column.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //        }
                        
            //        clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    

            //    }
            /*
            foreach (ALSButton[] rows in keypad)
            {
                foreach (ALSButton column in rows)
                {
                    column.Click += new System.EventHandler(this.keypad_Click);
                    column.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }*/

            foreach(ALSButton btn in alsKeyboard.getPredictKeys())
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

            alsKeyboard.Size = new Size(Width-2*UI.GAP, Height - alsAlarm1.Bottom - 2 * UI.GAP);

        }

        public ALSButton getCalloutBtn()
        {
            return btnCallouts;
        }

        private void keypad_Click(object sender, EventArgs e)
        {/*
            /*
            String word = alsKeyboard.wordPrediction(Convert.ToInt16(((ALSButton)sender).Text));

            if (!predictLock) { 
                key_DeleteWord(sender, e);
                predictLock = true;
            }

            if (textBox1.Text == "" || textBox1.Text[textBox1.Text.Length-1].ToString() == " ")
            {
                textBox1.Text += word + " ";
            }
            else
            {
                textBox1.Text += " " + word + " ";
            }*/
            /*
            String word = ((ALSButton)sender).Text;

            if (!predictLock)
            {
                key_DeleteWord(sender, e);
                predictLock = true;
            }

            if (textBox1.Text == "" || textBox1.Text[textBox1.Text.Length - 1].ToString() == " ")
            {
                textBox1.Text += word + " ";
            }
            else
            {
                textBox1.Text += " " + word + " ";
            }*/


        }

        private void space_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(" ");
            predictLock = true;
            buffer = "";
            predictReset();
            
        }

        private void predictReset()
        {
           // this.alsKeyboard.resetPrediction();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Hide();
        }

        private void key_Click(object sender, EventArgs e)
        {
            /*
            string letter = ((ALSButton)sender).Text;
            textBox1.Text += letter;
            buffer += letter;
            //MessageBox.Show(buffer);
            
            
            alsKeyboard.setBuffer(buffer);
            
           // Console.WriteLine(getCurrentSentence());*/
            textBox1.Text += ((ALSButton)sender).Text;
            //alsKeyboard.setBuffer(getCurrentSentence());
            predictLock = false;
        }

        private void key_Backspace(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        private string getCurrentSentence()
        {
            //Assuming that we don't want the cursor to move around, we want this.
            var finalSentence = Regex.Match(textBox1.Text, "[.!?][^.!?]*$");

            //If you do want to move the caret around use this, then concatenate them
            var firstHalf = Regex.Match(textBox1.Text.Substring(0, textBox1.SelectionStart), "[.!?][^.!?]*$");
            var secondHalf = Regex.Match(textBox1.Text.Substring(textBox1.SelectionStart), "[^.!?]*[.!?]");
            
            string sentence = "";

            if(firstHalf.Success)
            {
                string sen = textBox1.Text.Substring(firstHalf.Index, firstHalf.Length);
                //MessageBox.Show(sen);
                sentence = sen;
            }
            /*
            if (secondHalf.Success)
            {
                string sen = textBox1.Text.Substring(secondHalf.Index, secondHalf.Length);
                MessageBox.Show(sen);
                sentence = sen;
                //System.Diagnostics.Debug.WriteLine(Text.Substring(secondHalf.Index, secondHalf.Length));
            }*/

            //
            //if (match2.Success)
            //{
            //    sentence = textBox1.Text.Substring(match2.Index, textBox1.Text.Length-1);
            //}

            //Console.WriteLine("Current sentence = " + sentence + " ||..");
            return sentence;
        }

        private void key_DeleteWord(object sender, EventArgs e)
        { 
            var match = Regex.Match(textBox1.Text, @"\w+\s*$");
            var match2 = Regex.Match(textBox1.Text, @"\w+\p{P}+\s*$");
            if (match.Success)
            {
                textBox1.Text = textBox1.Text.Substring(0, match.Index);
            }
            else if(match2.Success)
            {
                textBox1.Text = textBox1.Text.Substring(0, match2.Index);
            }

            predictReset();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            clearTextConfirmation.Visible = true;
        }

        public void ClearText()
        {
            textBox1.Clear();
            predictReset();
            this.Enabled = true;
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            speaker.SpeakAsyncCancelAll();
            speaker.SpeakAsync(textBox1.Text);
        }

        void initControlsRecursive(System.Windows.Forms.Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => {
                    updateCursor();
                };
                initControlsRecursive(c.Controls);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateCursor();

        }

        private void updateCursor()
        {
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.SelectionLength = 0;
        }

        private void alsButton3_Click(object sender, EventArgs e)
        {

        }

        private void alsButton2_Click(object sender, EventArgs e)
        {

        }

        private void alsButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnCallouts_Click(object sender, EventArgs e)
        {

        }




    }
}
