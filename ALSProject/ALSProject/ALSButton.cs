using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Timers;

namespace ALSProject
{
    public partial class ALSButton : UserControl
    {

        int heightCounter;
        Graphics gr;
        Color baseColor =Color.FromArgb(224, 224, 224);
        Timer dwellTimer;

        public ALSButton()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            heightCounter =  0;

            dwellTimer = new Timer();
            dwellTimer.Interval = 50; // interval in milliseconds
            dwellTimer.Enabled = false;
            dwellTimer.Elapsed += dwellTimeEvent;
            dwellTimer.AutoReset = true;
        }


        private void dwellTimeEvent(object sender, ElapsedEventArgs e)
        {
            gr.FillRectangle(Brushes.Gray, new Rectangle(0, this.Height - heightCounter, this.Width, this.Height / 10));

            heightCounter += this.Height / 10;

            if (heightCounter > this.Height * 12 / 10)
            {
                heightCounter = 0;
                this.Click();
                gr.Clear(baseColor);
            }
        }

        private void ALSButton_Load(object sender, EventArgs e)
        {

        }

        private void ALSButton_MouseEnter(object sender, EventArgs e)
        {
            dwellTimer.Enabled = true;
          
        }

        private void Click()
        {
            MessageBox.Show("Click!");
        }

        private void ALSButton_MouseLeave(object sender, EventArgs e)
        {
            dwellTimer.Enabled = false;
            gr.Clear(baseColor);
            heightCounter = 0;


        }


        //this doesn't work the way it should so I am disabling it
        private void ALSButton_Resize(object sender, EventArgs e)
        {
            //this.Width = Screen.FromControl(this).Bounds.Width / 8;
        }

    }
}
