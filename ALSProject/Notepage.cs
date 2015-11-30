using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Notepage : Form
    {
        private Form parentForm;
        private SpeechSynthesizer voice;
        KeyboardControl2 keyboard;
        
        const int MENU_BUTTON_SIZE = 140;
        const int ARROW_KEY_SIZE = 80;
        ALSButton alarm, speak, back;
        ALSButton up, left, right, down, backWord, forwardWord;
        TextBox txtContect;

        public Notepage(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.voice = voice;

            this.WindowState = FormWindowState.Maximized;

            keyboard = new KeyboardControl2(this);

            foreach(ALSButton button in keyboard.getKeyboard())
            { 
                    button.Click += new System.EventHandler(key_Click);
                
            }

            alarm = new ALSAlarm();
            speak = new ALSButton();
            back = new ALSButton();
            up = new ALSButton();
            left = new ALSButton();
            right = new ALSButton();
            down = new ALSButton();
            backWord = new ALSButton();
            forwardWord = new ALSButton();
            txtContect = new TextBox();

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
            Controls.Add(txtContect);

            speak.Click += new EventHandler(Speak_Click);
            back.Click += new EventHandler(Back_Click);
            up.Click += new EventHandler(Up_Click);
            left.Click += new EventHandler(Left_Click);
            right.Click += new EventHandler(Right_Click);
            down.Click += new EventHandler(Down_Click);
            backWord.Click += new EventHandler(BackWord_Click);
            forwardWord.Click += new EventHandler(ForwardWord_Click);

            speak.Text = "Speak";
            back.Text = "Notebook";
            up.Text = "Up";
            left.Text = "Left";
            right.Text = "Right";
            down.Text = "Down";
            backWord.Text = "Left one word";
            forwardWord.Text = "right one word";

            txtContect.Multiline = true;
            txtContect.Font = new Font("Microsoft Sans Serif", 20F);
            initControlsRecursive(this.Controls);
        }

        private void ForwardWord_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            string content = txtContect.Text.Substring(txtContect.SelectionStart);

            //Find the first whitespace. Move the cursor at the end of the whitespace
            var match = Regex.Match(content, @"\s*\S+\s+");
            if (match.Success)
            {
                txtContect.SelectionStart += match.Index + match.Length;
            }
            else
            {
                txtContect.SelectionStart = txtContect.Text.Length;
            }
        }

        private void BackWord_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            string content = txtContect.Text.Substring(0, txtContect.SelectionStart);

            var match = Regex.Match(content, @"\s+\S+\s*$");
            if (match.Success)
            {
                txtContect.SelectionStart = match.Index;
            }
            else
            {
                txtContect.SelectionStart = 0;
            }
        }

        private void key_Click(object sender, EventArgs e)
        {
            txtContect.Text += ((ALSButton)sender).Text;
            this.keyboard.predictType(((ALSButton)sender).Text);
            //predictLock = false;
        }

        private void Down_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            SendKeys.Send("{DOWN}");
        }

        private void Right_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            if (txtContect.SelectionStart != txtContect.Text.Length)
                txtContect.SelectionStart++;
            txtContect.SelectionLength = 0;
        }

        private void Left_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            if (txtContect.SelectionStart != 0)
                txtContect.SelectionStart--;
            txtContect.SelectionLength = 0;
        }

        private void Notepage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Up_Click(object sender, EventArgs e)
        {
            txtContect.Focus();
            SendKeys.Send("{UP}");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void Speak_Click(object sender, EventArgs e)
        {
            voice.SpeakAsyncCancelAll();
            if (txtContect.SelectionStart == txtContect.Text.Length)
                voice.SpeakAsync(txtContect.Text);
            else
                voice.SpeakAsync(txtContect.Text.Substring(txtContect.SelectionStart));
        }

        void initControlsRecursive(System.Windows.Forms.Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) =>
                {
                    updateCursor();
                };
                initControlsRecursive(c.Controls);
            }
        }

        private void updateCursor()
        {
            txtContect.Focus();
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
            txtContect.Location = new Point(speak.Right + UI.GAP, UI.GAP);

            txtContect.Focus();
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
            txtContect.Size = new Size(back.Left - MENU_BUTTON_SIZE * 2 - UI.GAP * 4, MENU_BUTTON_SIZE);
        }

        public string getText()
        {
            return txtContect.Text;
        }

        public ALSButton getBackBtn()
        {
            return back;
        }

        public void setText(string text)
        {
            if (text != null)
                txtContect.Text = text;
        }

        public void ClearText() //erases the textbox for when a new note is to be added
        {
            txtContect.Text = "";
        }

        public void setCursorAtEnd()
        {
            txtContect.SelectionStart = txtContect.Text.Length;
        }

        public ALSButton getSaveButton()
        {
            return new ALSButton();
        }
    }
}
