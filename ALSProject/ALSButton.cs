using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Timers;
using System.Diagnostics;

namespace ALSProject
{
    public partial class ALSButton : Button
    {

        int heightCounter;
        Graphics gr;
        protected Timer dwellTimer;
        protected bool clicked = false; //prevents rapid clicks
        public int timeDivision { get; set; }

        public static Color baseColor = Color.FromArgb(224, 224, 224);
        public static int defaultTimeDivision = 15;
        
        public ALSButton()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            heightCounter =  0;

            dwellTimer = new Timer();
            dwellTimer.Interval = 50; // interval in milliseconds
            dwellTimer.Enabled = false;
            dwellTimer.Tick += new EventHandler(dwellTimeEvent);
            this.timeDivision = defaultTimeDivision;
        }

        protected void dwellTimeEvent(object sender, EventArgs e)
        {
            gr.FillRectangle(new SolidBrush(Color.FromArgb(127,128,128,128)), new Rectangle(0, this.Height - heightCounter, this.Width, this.Height / timeDivision));
            
            if (heightCounter > this.Height * 12 / 10)
            {
               
                this.PerformClick();
            }
            else
            {
                heightCounter += this.Height / timeDivision;
            }
        }

        private void ALSButton_MouseEnter(object sender, EventArgs e)
        {
            dwellTimer.Enabled = true;
        }

        private void ALSButton_MouseLeave(object sender, EventArgs e)
        {
            dwellTimer.Enabled = false;
            clicked = false;
            ClearRect();
        }

        //deletes rectangle, restores image if any
        protected void ClearRect()
        {
            String text = Text;
            try
            {
                Image temp = (Image)this.BackgroundImage.Clone(); //deep copy)
                gr.Clear(baseColor);
                this.BackgroundImage = temp;
            }
            catch (Exception)
            {         //this just prevents the program from crashing if there is no Background Image set
                gr.Clear(baseColor);    //clears rectangle if there is no image
            }
            Text = text;

            heightCounter = 0;
            clicked = false;
        }


        private void ALSButton_Resize(object sender, EventArgs e)
        {
            gr = this.CreateGraphics(); 

            if(this.Text != null)
            {
                float p = this.Font.SizeInPoints;
                this.TextAlign =  System.Drawing.ContentAlignment.TopCenter;     
                this.Font = new Font(this.Font.Name, this.Width * 11 / 20);
                if(this.Width * 11 / 20 == 110)
                    this.Font = new Font(this.Font.Name, 40);
            }
        }

        private void ALSButton_Click(object sender, EventArgs e)
        {
           
            if (!clicked)
            { //prevents rapid clicks
                clicked = true;
                ClearRect();
                dwellTimer.Enabled = true;

                //reset
                dwellTimer.Stop();
                dwellTimer.Start();
                this.Refresh();
            }

        }
    }
}
