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
using System.Text.RegularExpressions;

namespace ALSProject
{
    public partial class ALSButton : Button
    {
        public enum ButtonType { key, normal, immutable };

        public ButtonType btnType
        {
            get; set;
        }

        int heightCounter;
        Graphics gr;
        protected Timer dwellTimer, decayTimer;
        protected bool clicked = false; //prevents rapid clicks
        private int heightDivider = 30;
        //bool immutableDwellTime = false;
        public int dwellTimeInterval
        {
            get
            {
                return dwellTimer.Interval;
            }
            set
            {
                //btnType = ButtonType.immutable;
                dwellTimer.Interval = value;
            }
        }
        private static List<ALSButton> alsButtons = new List<ALSButton>();

        public static Color baseColor = Color.FromArgb(224, 224, 224);

        public ALSButton()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
            heightCounter = 0;
            dwellTimer = new Timer();
            dwellTimer.Enabled = false;
            dwellTimer.Tick += new EventHandler(dwellTimeEvent);

            decayTimer = new Timer();
            decayTimer.Enabled = false;
            decayTimer.Tick += decayTimer_Tick;

            alsButtons.Add(this);
            btnType = ButtonType.normal;
        }

        private void decayTimer_Tick(object sender, EventArgs e)
        {
            if (firstTime)
            {
                ClearRect();
                this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, heightCounter));
                firstTime = false;
            }
            else
            {
                ClearRect();
                //g.ExcludeClip(new Rectangle(0, 0, Width, Height - heightCounter));
                this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, heightCounter));
                // g.Clip = new Region(new RectangleF(0, Height - heightCounter, Width, Height / heightDivider));
                // g.Clear(BackColor);
            }
            if (heightCounter < 0)
            {
                heightCounter = 0;
                decayTimer.Stop();
                decayTimer.Enabled = false;
            }
            else
            {
                heightCounter -= this.Height / heightDivider;
            }
        }

        private bool firstTime = true;
        protected void dwellTimeEvent(object sender, EventArgs e)
        {
            if(firstTime)
            {
                this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, heightCounter));
                firstTime = false;
            }
            else 
            //ClearRect();
            //this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, heightCounter));
            this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, this.Height / heightDivider));

            if (heightCounter > this.Height)
            {

                this.PerformClick();
            }
            else
            {
                heightCounter += this.Height / heightDivider;
            }
        }

        private void ALSButton_MouseEnter(object sender, EventArgs e)
        {
            dwellTimer.Enabled = true;
            firstTime = true;
            decayTimer.Stop();
        }

        private void ALSButton_MouseLeave(object sender, EventArgs e)
        {
            dwellTimer.Enabled = false;
            clicked = false;
            //ClearRect();
            decayTimer.Start();
            firstTime = true;
        }

        //deletes rectangle, restores image if any
        protected void ClearRect()
        {
            string text = Text;
            try
            {
                Image temp = (Image)this.BackgroundImage.Clone(); //deep copy
                gr.Clear(baseColor);
                this.BackgroundImage = temp;
            }
            catch (Exception)
            {         //this just prevents the program from crashing if there is no Background Image set
                this.CreateGraphics().Clear(baseColor);    //clears rectangle if there is no image
            }
            Text = text;
            
            //heightCounter = 0;
            clicked = false;
        }


        private void ALSButton_Resize(object sender, EventArgs e)
        {
            gr = this.CreateGraphics();
            setFontSize(gr);
        }

        private void ALSButton_Click(object sender, EventArgs e)
        {
            if (!clicked)
            { //prevents rapid clicks
                clicked = true;
                ClearRect();
                dwellTimer.Enabled = true;
                decayTimer.Stop();

                //reset
                dwellTimer.Stop();
                dwellTimer.Start();
                this.Refresh();
            }

        }

        public static void setTimerSpeed(double speed, ButtonType buttonType)
        {
            if (speed < 0)
                return;
            foreach (ALSButton btn in alsButtons)
            {
                if (btn.btnType.Equals(buttonType))
                {
                    btn.dwellTimer.Interval = Math.Max((int)(speed * 7), 1);
                }
            }
        }

        //This function checks the room size and your text and appropriate font for your text to fit in room
        //Text is the string which it's bounds is more than room bounds.
        public void setFontSize(Graphics g)
        {
            SizeF RealSize = g.MeasureString(Text, Font);
            float HeightScaleRatio = (Height - 16) / RealSize.Height;
            float WidthScaleRatio = (Width - 16) / RealSize.Width;
            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;
            float ScaleFontSize = Font.Size * ScaleRatio;

            Font = new Font(Font.FontFamily, Math.Min(ScaleFontSize < 8 ? 5 : ScaleFontSize, 50));
        }
    }
}
