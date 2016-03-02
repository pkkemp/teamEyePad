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
    public partial class ComposeEmail : Form
    {
        ALSAlarm btnAlarm;
        Label lblTo, lblFrom, lblBody;
        ALSTextbox txtTo, txtFrom, txtBody;
        ALSButton btnCancel;
        ALSButton btnSend;
        Keyboard keyboard;
        EmailMessage previousMessage;

        public enum EmailType { Compose, Reply, ReplyAll, Forward };
        private EmailType type;

        public delegate void Event(object sender, EventArgs args);
        public event Event Cancel_Click;
        public event Event Send_Click;

        public ComposeEmail(bool isQwerty)
        {
            InitializeComponent();
            InitializeControls(isQwerty);
        }

        public void SetKeyboard(Keyboard k)
        {
            Controls.Remove(keyboard);
            keyboard = k;
            keyboard.HideTextBox();
            Controls.Add(keyboard);
            ComposeEmail_Resize(this, EventArgs.Empty);
        }

        public void SetEmailType(EmailType type)
        {
            this.type = type;
        }
        
        public void SetEmailMessage(EmailMessage m)
        {
            previousMessage = m;
        }

        private void InitializeControls(bool isQwerty)
        {
            btnAlarm = new ALSAlarm();
            lblTo = new Label();
            lblFrom = new Label();
            lblBody = new Label();
            txtTo = new ALSTextbox();
            txtFrom = new ALSTextbox();
            txtBody = new ALSTextbox();
            btnCancel = new ALSButton();
            btnSend = new ALSButton();

            if (isQwerty)
                keyboard = new KeyboardControl3();
            else
                keyboard = new KeyboardControl2();

            lblTo.Text = "To:";
            lblFrom.Text = "From:";
            lblBody.Text = "Body:";
            btnCancel.Text = "Cancel";
            btnSend.Text = "Send";

            Controls.Add(btnAlarm);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Controls.Add(lblBody);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(txtBody);
            Controls.Add(btnCancel);
            Controls.Add(btnSend);
            Controls.Add(keyboard);

            btnCancel.Click += BtnCancel_Click;
            btnSend.Click += BtnSend_Click;

            keyboard.HideTextBox();
            txtTo.Multiline = true;
            txtFrom.Multiline = true;
            txtBody.Multiline = true;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            EmailMessage message = new EmailMessage(txtFrom.Text, txtBody.Text, txtTo.Text, txtFrom.Text, new DateTime());
            EmailClient Client = EmailFactory.GetEmailClient();

            switch (type)
            {
                case EmailType.Compose:
                    Client.sendMessage(message);
                    break;
                case EmailType.Forward:
                    Client.sendForward(previousMessage, txtFrom.Text, txtBody.Text);
                    break;
                case EmailType.Reply:
                case EmailType.ReplyAll:
                    Client.sendReply(previousMessage, txtBody.Text);
                    break;
            }
            
            Hide();
            if (Send_Click != null)
                Send_Click(this, e);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
            if (Cancel_Click != null)
                Cancel_Click(this, e);
        }

        private void ComposeEmail_Resize(object sender, EventArgs e)
        {
            int buttonWdidth = (Width - MainMenu.GAP * 7) / 6;
            btnAlarm.Size = new Size(buttonWdidth, buttonWdidth);
            btnCancel.Size = btnAlarm.Size;
            btnSend.Size = btnAlarm.Size;

            btnAlarm.Location = new Point(MainMenu.GAP, MainMenu.GAP);
            int labelHeight = (btnAlarm.Bottom - MainMenu.GAP * 2) / 2;
            lblFrom.Location = new Point(btnAlarm.Right + MainMenu.GAP, btnAlarm.Bottom - labelHeight);
            lblTo.Location = new Point(lblFrom.Right - lblTo.Width, btnAlarm.Top);
            btnSend.Location = new Point(Width - btnSend.Width - MainMenu.GAP, btnAlarm.Top);
            btnCancel.Location = new Point(btnSend.Left - btnCancel.Width - MainMenu.GAP, btnAlarm.Top);
            txtTo.Location = new Point(lblTo.Right + MainMenu.GAP, btnAlarm.Top);
            txtFrom.Location = new Point(lblFrom.Right + MainMenu.GAP, lblFrom.Top);

            txtTo.Size = new Size(btnCancel.Left - txtTo.Left - MainMenu.GAP, labelHeight);
            txtFrom.Size = txtTo.Size;

            lblBody.Location = new Point(MainMenu.GAP, btnAlarm.Bottom + MainMenu.GAP);
            txtBody.Location = new Point(MainMenu.GAP, lblBody.Bottom + MainMenu.GAP);
            keyboard.Location = new Point(MainMenu.GAP, txtBody.Bottom + MainMenu.GAP);
            int bodyHeight = (Height - lblBody.Bottom - MainMenu.GAP * 3) / 3;

            txtBody.Size = new Size(Width - MainMenu.GAP * 2, bodyHeight);
            keyboard.Size = new Size(Width - MainMenu.GAP * 2, bodyHeight * 2);
        }

        private void ComposeEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
