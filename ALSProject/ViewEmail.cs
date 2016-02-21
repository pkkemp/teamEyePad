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
    public partial class ViewEmail : Form
    {
        ALSAlarm btnAlarm;
        ALSButton btnRespond, btnPageUp, btnUp, btnDown, btnPageDown, btnBack;
        ALSTextbox tbEmail;

        EmailResponseType frmRespond;

        public delegate void Event(object sender, EventArgs args);
        public event Event Back_Click;

        public ViewEmail()
        {
            InitializeComponent();
            InitializeControls();

            frmRespond = new EmailResponseType();
        }

        private void InitializeControls()
        {
            btnAlarm = new ALSAlarm();
            btnRespond = new ALSButton();
            btnPageUp = new ALSButton();
            btnUp = new ALSButton();
            btnDown = new ALSButton();
            btnPageDown = new ALSButton();
            btnBack = new ALSButton();
            tbEmail = new ALSTextbox();

            btnRespond.Text = "Respond";
            btnPageUp.Text = "Page\nup";
            btnUp.Text = "Scroll\nUp";
            btnDown.Text = "Scroll\nDown";
            btnPageDown.Text = "Page\nDown";
            btnBack.Text = "Back";

            btnRespond.Click += BtnRespond_Click;
            btnPageUp.Click += BtnPageUp_Click;
            btnUp.Click += BtnUp_Click;
            btnDown.Click += BtnDown_Click;
            btnBack.Click += BtnBack_Click;

            Controls.Add(btnAlarm);
            Controls.Add(btnRespond);
            Controls.Add(btnPageUp);
            Controls.Add(btnUp);
            Controls.Add(btnDown);
            Controls.Add(btnPageDown);
            Controls.Add(btnBack);
            Controls.Add(tbEmail);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            if (Back_Click != null)
                Back_Click(this, e);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnPageUp_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRespond_Click(object sender, EventArgs e)
        {
            frmRespond.Show();
            Hide();
        }

        private void ViewEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ViewEmail_Resize(object sender, EventArgs e)
        {
            int buttonWidth = (Width - MainMenu.GAP * 8) / 7;
            btnAlarm.Size = new Size(buttonWidth, buttonWidth);
            btnRespond.Size = btnAlarm.Size;
            btnPageUp.Size = btnAlarm.Size;
            btnUp.Size = btnAlarm.Size;
            btnDown.Size = btnAlarm.Size;
            btnPageDown.Size = btnAlarm.Size;
            btnBack.Size = btnAlarm.Size;
            tbEmail.Size = new Size(Width - MainMenu.GAP * 2, Height - btnAlarm.Bottom - MainMenu.GAP * 2);

            btnAlarm.Location = new Point(MainMenu.GAP, MainMenu.GAP);
            placeRightOf(btnRespond, btnAlarm);
            placeRightOf(btnPageUp, btnRespond);
            placeRightOf(btnUp, btnPageUp);
            placeRightOf(btnDown, btnUp);
            placeRightOf(btnPageDown, btnDown);
            placeRightOf(btnBack, btnPageDown);
            tbEmail.Location = new Point(MainMenu.GAP, btnAlarm.Bottom + MainMenu.GAP);

        }

        private void placeRightOf(ALSButton right, ALSButton left)
        {
            right.Location = new Point(left.Right + MainMenu.GAP, left.Top);
        }
    }
}
