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
    public partial class Notepage : Form
    {
        KeyboardControl keyboard;
        const int MENU_BUTTON_SIZE = 140;
        const int ARROW_KEY_SIZE = 80;
        ALSButton alarm, speak, back;
        ALSButton up, left, right, down, backWord, forwardWord;
        TextBox content;

        public Notepage(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            keyboard = new KeyboardControl(this);
            
            alarm = new ALSAlarm();
            speak = new ALSButton();
            back = new ALSButton();
            up = new ALSButton();
            left = new ALSButton();
            right = new ALSButton();
            down = new ALSButton();
            backWord = new ALSButton();
            forwardWord = new ALSButton();
            content = new TextBox();

            Controls.Add(alarm);
            Controls.Add(speak);
            Controls.Add(back);
            Controls.Add(up);
            Controls.Add(left);
            Controls.Add(right);
            Controls.Add(down);
            Controls.Add(backWord);
            Controls.Add(forwardWord);
            Controls.Add(keyboard);
            Controls.Add(content);

            speak.Text = "Speak";
            back.Text = "Notebook";
            up.Text = "Up";
            left.Text = "Left";
            right.Text = "Right";
            down.Text = "Down";
            backWord.Text = "Left one word";
            forwardWord.Text = "right one word";

            content.Multiline = true;
        }

        private void Notepage_Load(object sender, EventArgs e)
        {
            alarm.Size = new Size(MENU_BUTTON_SIZE, MENU_BUTTON_SIZE);
            speak.Size = new Size(MENU_BUTTON_SIZE, MENU_BUTTON_SIZE);
            back.Size = new Size(MENU_BUTTON_SIZE, MENU_BUTTON_SIZE);
            up.Size = new Size(ARROW_KEY_SIZE, ARROW_KEY_SIZE);
            left.Size = new Size(ARROW_KEY_SIZE, ARROW_KEY_SIZE);
            right.Size = new Size(ARROW_KEY_SIZE, ARROW_KEY_SIZE);
            down.Size = new Size(ARROW_KEY_SIZE, ARROW_KEY_SIZE);
            backWord.Size = new Size((int)(ARROW_KEY_SIZE * 1.5), ARROW_KEY_SIZE);
            forwardWord.Size = new Size((int)(ARROW_KEY_SIZE * 1.5), ARROW_KEY_SIZE);

            alarm.Location = new Point(UI.GAP, UI.GAP);
            speak.Location = new Point(UI.GAP + alarm.Right, UI.GAP);
            keyboard.Location = new Point(UI.GAP, alarm.Bottom + UI.GAP);
            content.Location = new Point(speak.Right + UI.GAP, UI.GAP);
        }

        private void Notepage_Resize(object sender, EventArgs e)
        {
            
            back.Location = new Point(this.Right - MENU_BUTTON_SIZE - UI.GAP, UI.GAP);
            forwardWord.Location = new Point(Width - UI.GAP - forwardWord.Width, Height - UI.GAP - ARROW_KEY_SIZE);
            backWord.Location = new Point(forwardWord.Left - UI.GAP - backWord.Width, forwardWord.Top);
            right.Location = new Point(Width - UI.GAP - ARROW_KEY_SIZE, forwardWord.Top - UI.GAP - ARROW_KEY_SIZE);
            down.Location = new Point(right.Left - UI.GAP - ARROW_KEY_SIZE, right.Top);
            left.Location = new Point(down.Left - UI.GAP - ARROW_KEY_SIZE, right.Top);
            up.Location = new Point(down.Left, down.Top - UI.GAP - ARROW_KEY_SIZE);

            keyboard.Size = new Size(this.Width - UI.GAP * 2, this.Height - 3 * UI.GAP - MENU_BUTTON_SIZE);
            content.Size = new Size(back.Left - MENU_BUTTON_SIZE * 2 - UI.GAP * 4, MENU_BUTTON_SIZE);
            MessageBox.Show(speak.Right + "");

        }

        public TextBox getTextBox()
        {
            return new TextBox();
        }

        public ALSButton getSaveButton()
        {
            return new ALSButton();
        }
    }
}
