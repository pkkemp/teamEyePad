﻿using System;
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
                {
                    if (column.Text == "Backspace")
                        column.Click += new System.EventHandler(this.key_Backspace);
                    else if (column.Text == "Delete\nWord")
                        column.Click += new System.EventHandler(this.key_DeleteWord);
                    else
                        column.Click += new System.EventHandler(this.key_Click);
                }
            
            space.Click += new System.EventHandler(this.space_Click);
            initControlsRecursive(this.Controls);
            this.MouseClick += (sender, e) => {
                updateCursor();
            };
        }

        private void space_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(" ");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Parent.Visible = true;
            this.Close();
        }

        private void key_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((ALSButton)sender).Text;
        }

        private void key_Backspace(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        private void key_DeleteWord(object sender, EventArgs e)
        { 
            var match = Regex.Match(textBox1.Text, @"\s+\w+\s*$");
            if (match.Success)
            {
                textBox1.Text = textBox1.Text.Substring(0, match.Index) + " ";
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void TextToSpeech_Load(object sender, EventArgs e)
        {
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
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
    }
}
