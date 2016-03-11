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
    public partial class EmailResponseType : Form
    {
        ALSButton btnReply, btnReplyAll, btnForward;
        private EmailMessage message;

        public EmailResponseType()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            btnReply = new ALSButton();
            btnReplyAll = new ALSButton();
            btnForward = new ALSButton();

            btnReply.Text = "Reply";
            btnReplyAll.Text = "Reply\nAll";
            btnForward.Text = "Forward";

            btnReply.Click += BtnReply_Click;
            btnReplyAll.Click += BtnReplyAll_Click;
            btnForward.Click += BtnForward_Click;

            Controls.Add(btnReply);
            Controls.Add(btnReplyAll);
            Controls.Add(btnForward);
        }

        public void SetEmailMessage(EmailMessage m)
        {
            message = m;
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            Respond(ComposeEmail.EmailType.Forward);
        }

        private void BtnReplyAll_Click(object sender, EventArgs e)
        {
            Respond(ComposeEmail.EmailType.ReplyAll);
        }

        private void BtnReply_Click(object sender, EventArgs e)
        {
            Respond(ComposeEmail.EmailType.Reply);
        }

        private void Respond(ComposeEmail.EmailType type)
        {

            ComposeEmail compose = EmailFactory.GetComposeEmail();
            compose.SetEmailType(type, message);
            compose.Show();
            Hide();
        }

        private void EmailResponseType_Resize(object sender, EventArgs e)
        {
            int buttonHeight = (Height - MainMenu.GAP * 4) / 3;
            int buttonWidth = Width - MainMenu.GAP * 2;
            btnReply.Size = new Size(buttonWidth, buttonHeight);
            btnReplyAll.Size = new Size(buttonWidth, buttonHeight);
            btnForward.Size = new Size(buttonWidth, buttonHeight);
            btnReply.Location = new Point(MainMenu.GAP, MainMenu.GAP);
            btnReplyAll.Location = new Point(MainMenu.GAP, btnReply.Bottom + MainMenu.GAP);
            btnForward.Location = new Point(MainMenu.GAP, btnReplyAll.Bottom + MainMenu.GAP);
        }

        private void EmailResponseType_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
