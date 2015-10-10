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
        Color baseColor = Color.FromArgb(224, 224, 224);
        Timer dwellTimer;
        bool clicked = false; //prevents rapid clicks

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
            gr.FillRectangle(new SolidBrush(Color.FromArgb(127,128,128,128)), new Rectangle(0, this.Height - heightCounter, this.Width, this.Height / 10));

            if (heightCounter > this.Height * 12 / 10)
            {
                //this.ALSButton_Click(sender, e); // calls the click event programmatically rather than through an actual click
                this.OnClick(e);

            }
            else
            {
                heightCounter += this.Height / 10;
            }
        }

        private void ALSButton_Load(object sender, EventArgs e)
        {

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
        private void ClearRect()
        {
            try {

                Image temp = (Image)this.BackgroundImage.Clone(); //deep copy
                gr.Clear(baseColor);
                this.BackgroundImage = temp;
                
            }catch(Exception e) {//this just prevents the program from crashing if there is no Background Image set
                gr.Clear(baseColor);//clears rectangle if there is no image
            }

            heightCounter = 0;
        }


        private void ALSButton_Resize(object sender, EventArgs e)
        {

           // this is necessary because otherwise the graphics object won't let you draw things bigger than the original size
           // it was also a huge pain in the butt to fix. It took me like 3 hours lol
            gr = this.CreateGraphics(); 
        }

        private void ALSButton_Click(object sender, EventArgs e)
        {
            if (!clicked) { //prevents rapid clicks
                clicked = true;
                //MessageBox.Show("Click!");
                dwellTimer.Enabled = false;
            }

        }
    }
}
