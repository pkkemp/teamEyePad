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
    public partial class LockScreen : Form
    {
        private ALSButton _lock;
        private ALSAlarm alarm;

        #region Constructors
        public LockScreen()
        {
            InitializeComponent();
            _lock = new ALSButton();
            alarm = new ALSAlarm();

            Controls.Add(_lock);
            Controls.Add(alarm);

            _lock.Click += new System.EventHandler(this.Lock_Click);
            _lock.BackgroundImage = Properties.Resources.Unlock;
            _lock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            Resize += this.Resize_LockScreen;
        }
        #endregion

        #region Events
        private void Resize_LockScreen(object sender, EventArgs e)
        {
            int length = Height / 3;
            _lock.Location = new Point((Width - length) / 2, Height / 12);
            alarm.Location = new Point((Width - length) / 2, (Height*7) / 12);
            _lock.Size = new Size(length, length);
            alarm.Size = new Size(length, length);

        }

        private void Lock_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void LockScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
