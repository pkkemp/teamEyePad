using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class ViewEmail : Form
    {
        ALSAlarm btnAlarm;
        ALSButton btnRespond, btnPageUp, btnUp, btnDown, btnPageDown, btnBack;
        TextBox tbEmail;
        Panel panel;
        private EmailMessage message;
        EmailResponseType frmRespond;
        int currentHeight;

        enum ScrollDirection { PageUp, ScrollUp, ScrollDown, PageDown };
        public delegate void Event(object sender, EventArgs args);
        public event Event Back_Click;
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg, UIntPtr wParam, IntPtr lParam);

        public ViewEmail()
        {
            InitializeComponent();
            InitializeControls();

            frmRespond = new EmailResponseType();
        }

        public void SetMailMessage(EmailMessage m)
        {
            message = m;
            tbEmail.Text = message.body;
            ViewEmail_Resize(this, EventArgs.Empty);

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
            tbEmail = new TextBox();
            panel = new Panel();

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
            btnPageDown.Click += BtnPageDown_Click;
            btnBack.Click += BtnBack_Click;

            panel.Controls.Add(tbEmail);
            Controls.Add(btnAlarm);
            Controls.Add(btnRespond);
            Controls.Add(btnPageUp);
            Controls.Add(btnUp);
            Controls.Add(btnDown);
            Controls.Add(btnPageDown);
            Controls.Add(btnBack);
            Controls.Add(panel);

            tbEmail.Multiline = true;
            tbEmail.ReadOnly = true;
            panel.AutoScroll = true;
            tbEmail.Size = new Size(100, 700);

        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            Hide();
            if (Back_Click != null)
                Back_Click(this, e);
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            ScrollClick(ScrollDirection.ScrollDown);
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            ScrollClick(ScrollDirection.ScrollUp);
        }

        private void BtnPageDown_Click(object sender, EventArgs e)
        {
            ScrollClick(ScrollDirection.PageDown);
        }

        private void BtnPageUp_Click(object sender, EventArgs e)
        {
            ScrollClick(ScrollDirection.PageUp);
        }

        private void ScrollClick(ScrollDirection scrollDirection)
        {
            Control c = new Control();
            panel.Controls.Add(c);
            switch (scrollDirection)
            {
                case ScrollDirection.PageDown:
                    c.Location = new Point(0, currentHeight + panel.Height + (2 * panel.Height) / 3);
                    currentHeight += (2 * panel.Height) / 3;
                    break;
                case ScrollDirection.PageUp:
                    c.Location = new Point(0, -(2 * panel.Height) / 3);
                    currentHeight -= (2 * panel.Height) / 3;
                    break;
                case ScrollDirection.ScrollDown:
                    c.Location = new Point(0, currentHeight + panel.Height + (1 * panel.Height) / 10);
                    currentHeight += (1 * panel.Height) / 10;
                    break;
                case ScrollDirection.ScrollUp:
                    c.Location = new Point(0, -(1 * panel.Height) / 10);
                    currentHeight -= (1 * panel.Height) / 10;
                    break;
            }
            if (currentHeight < 0)
                currentHeight = 0;
            int pixelsPastEdge = c.Location.Y - panel.Height - currentHeight;
            if (pixelsPastEdge > 0)
            {
                currentHeight -= pixelsPastEdge;
                c.Location = new Point(0, c.Location.Y - pixelsPastEdge);
            }
            panel.ScrollControlIntoView(c);
            panel.Controls.Remove(c);
        }

        private void BtnRespond_Click(object sender, EventArgs e)
        {
            frmRespond.SetEmailMessage(message);
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
            panel.Size = new Size(Width - MainMenu.GAP * 2, Height - btnAlarm.Bottom - MainMenu.GAP * 2);

            btnAlarm.Location = new Point(MainMenu.GAP, MainMenu.GAP);
            placeRightOf(btnRespond, btnAlarm);
            placeRightOf(btnPageUp, btnRespond);
            placeRightOf(btnUp, btnPageUp);
            placeRightOf(btnDown, btnUp);
            placeRightOf(btnPageDown, btnDown);
            placeRightOf(btnBack, btnPageDown);
            panel.Location = new Point(MainMenu.GAP, btnAlarm.Bottom + MainMenu.GAP);


            string[] rows = tbEmail.Text.Split(new char[] { '\n' });

            Graphics g = tbEmail.CreateGraphics();
            Font font = tbEmail.Font;
            int numLines = rows.Length;
            foreach (string row in rows)
            {
                SizeF p = g.MeasureString(row, font);
                numLines += (int)(p.Width / (tbEmail.Width - 10));
            }
            numLines += 3;  //to be safe
            SizeF textSize = g.MeasureString("Test", font);
            int textBoxHeight = (int)((numLines) * (textSize.Height));
            tbEmail.Size = new Size(panel.Width - 20, Math.Max(textBoxHeight, panel.Height));

        }

        private void placeRightOf(ALSButton right, ALSButton left)
        {
            right.Location = new Point(left.Right + MainMenu.GAP, left.Top);
        }
    }
}
