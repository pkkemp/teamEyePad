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
    public partial class frmAbout : Form
    {
        ALSAlarm btnAlarm;
        ALSButton btnBack;
        Label lblObjective;

        public frmAbout()
        {
            InitializeComponent();

            btnAlarm = new ALSAlarm();
            btnBack = new ALSButton();
            lblObjective = new Label();

            btnBack.Text = "Back";
            lblObjective.Text = "This application is an Oklahoma Christian University systems " +
                                "design project, Team eyePad, whose team members consist of " +
                                "Allison Chilton, Daniel Griffin, and Drew Harris. The team mentor " +
                                "is Professor Steve Maher, and the customer is Ash Srinivas.\n\n" +
                                "Team eyePad’s goal is to create a series of products that increase " +
                                "the quality of life of people that have Amyotrophic Lateral Sclerosis " +
                                "the designing an assistive interface via an application suite that " +
                                "the increase the ability to communicate and function independently.\n\n" +
                                "This application is dedicated to " + 
                                "Dr. Weyton Tam.";

            btnBack.Click += BtnBack_Click;

            lblObjective.TextAlign = ContentAlignment.TopCenter;

            lblObjective.ForeColor = Color.AntiqueWhite;

            Controls.Add(btnAlarm);
            Controls.Add(btnBack);
            Controls.Add(lblObjective);

            btnAlarm.Location = new Point(MainMenu.GAP, MainMenu.GAP);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void frmAbout_Resize(object sender, EventArgs e)
        {
            btnAlarm.Size = new Size(Width / 6, Width / 6);
            btnBack.Size = btnAlarm.Size;
            lblObjective.Size = new Size(Width - btnAlarm.Width - btnBack.Width - MainMenu.GAP * 4, 3 * Height / 4);
            //lblGoal.Size = lblObjective.Size;
            //lblDedication.Size = lblObjective.Size;

            lblObjective.Location = new Point(btnAlarm.Right + MainMenu.GAP, Height/4);
            btnBack.Location = new Point(Width - MainMenu.GAP - btnBack.Width, MainMenu.GAP);

            //setFontSize(lblObjective);
            //setFontSize(lblGoal);
            //setFontSize(lblDedication);
            lblObjective.Font = new Font(Font.FontFamily, 20);
        }

        private void setFontSize(Label lbl)
        {
            Graphics g = CreateGraphics();
            SizeF RealSize = g.MeasureString(lbl.Text, lbl.Font);
            float HeightScaleRatio = (lbl.Height - 18) / RealSize.Height;
            float WidthScaleRatio = (lbl.Width - 100) / RealSize.Width;
            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;
            float ScaleFontSize = Font.Size * ScaleRatio;

            lbl.Font = new Font(Font.FontFamily, Math.Min(ScaleFontSize < 8 ? 5 : ScaleFontSize, 50));
        }

        private void frmAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
