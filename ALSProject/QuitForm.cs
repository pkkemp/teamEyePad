using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ALSProject
{
    public partial class QuitForm : Form
    {
        public delegate void MainMenuClick(object sender, EventArgs args);
        public event MainMenuClick MainMenu_Click;
        
        #region Constructors
        public QuitForm()
        {
            InitializeComponent();
            yesBut.dwellTimeInterval = 100;
            yesBut.btnType = ALSButton.ButtonType.immutable;
        }
        #endregion

        #region Events
        private void noBut_Click(object sender, EventArgs e)
        {
            Hide();
            if (MainMenu_Click != null)
                MainMenu_Click(this, e);
        }

        private void yesBut_Click(object sender, EventArgs e)
        {
            CVInterface.PleaseStop();
            Application.Exit();
        }

        private void QuitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
