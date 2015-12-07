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
        protected Timer dwellTimer;
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
            alsButtons.Add(this);
            btnType = ButtonType.normal;
        }

        protected void dwellTimeEvent(object sender, EventArgs e)
        {

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
                this.CreateGraphics().Clear(baseColor);    //clears rectangle if there is no image
            }
            Text = text;

            heightCounter = 0;
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
            float HeightScaleRatio = Height / RealSize.Height;
            float WidthScaleRatio = Width / RealSize.Width;
            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? ScaleRatio = HeightScaleRatio : ScaleRatio = WidthScaleRatio;
            float ScaleFontSize = Font.Size * ScaleRatio;

            if (Text.Equals("Up"))
                Font = new Font(Font.FontFamily, 37);
            else
                Font = new Font(Font.FontFamily, Math.Min(ScaleFontSize < 8 ? 5 : ScaleFontSize - 4, 50));
        }
    }
}
