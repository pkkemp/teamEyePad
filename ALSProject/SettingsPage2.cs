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
    public partial class SettingsPage2 : Form
    {
        private ALSButton goBack;
        private ALSAlarm alarm;
        private ALSButton btnToggleDecay;
        private bool isDecay = false;
        private Form parent;
        private ALSButton btnAutoAlarm;


        #region Constructors

        #endregion

        #region Public Methods

        #endregion

        #region Events

        #endregion

        #region Private Events

        #endregion


        public SettingsPage2(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
            btnAutoAlarm = new ALSButton();
            alarm = new ALSAlarm();
            goBack = new ALSButton();

            int btnWidth = (Width - MainMenu.GAP * 8) / 7;

            btnAutoAlarm.Text = CVInterface.GetAutoAlarm() ? "Disable\nauto-alarm" : "Enable\nauto-alarm";
            btnAutoAlarm.Size = new Size(btnWidth, btnWidth);
            

            btnToggleDecay = new ALSButton();
            btnToggleDecay.Text = isDecay ? "Prevent\nDecay" : "Allow\nDecay";
            btnToggleDecay.Size = new Size(btnWidth, btnWidth);
            btnToggleDecay.Click += btnDecay_Click;
            Controls.Add(btnToggleDecay);

            Controls.Add(btnAutoAlarm);
            Controls.Add(goBack);
            Controls.Add(alarm);

            goBack.Click += new System.EventHandler(this.GoBack_Click);
            goBack.Text = "Go Back";

            Resize += this.Resize_SettingsScreen;
            btnAutoAlarm.Click += this.btAutoAlarm_Click;
        }

        private void GoBack_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Hide();
        }

        private void Resize_SettingsScreen(object sender, EventArgs e)
        {
            int length = Height / 3;
            goBack.Location = new Point(Width/10,Height/10);
            alarm.Location = new Point((Width - length) / 2, (Height*7) / 12);
            btnToggleDecay.Location = new Point(7 * Width / 10, Height / 10);
            btnToggleDecay.Size = new Size(length, length);
            goBack.Size = new Size(length, length);
            alarm.Size = new Size(length, length);

            btnAutoAlarm.Location = new Point(4 * Width / 10, Height / 10);
            btnAutoAlarm.Size = new Size(length, length);
           


        }

        private void btnDecay_Click(object sender, EventArgs e)
        {
            ALSButton.toggleDecay();
            isDecay = !isDecay;
            ((ALSButton)sender).Text = isDecay ? "Prevent\nDecay" : "Allow\nDecay";
        }

        private void btAutoAlarm_Click(object sender, EventArgs e)
        {
            CVInterface.SetAutoAlarm(!CVInterface.GetAutoAlarm());
            ((ALSButton)sender).Text = CVInterface.GetAutoAlarm() ? "Disable\nauto-alarm" : "Enable\nauto-alarm";
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
