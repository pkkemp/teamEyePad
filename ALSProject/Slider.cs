using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Slider : UserControl
    {
        public enum direction { LEFT, RIGHT };
        public double MIN_AMOUNT, MAX_AMOUNT, INCREMENT;
        public double value;

        Rectangle slideBox;
        Rectangle bounds;
        private static Color sliderColor = Color.FromArgb(220, 220, 220);

        public Slider(): this(1,0,10)
        {

        }


        public Slider(double inc, double min, double max)
        {
            InitializeComponent();
            //MIN_AMOUNT = 0.25;
            //INCREMENT = 0.25;
            //MAX_AMOUNT = 5;
            INCREMENT = inc;
            MIN_AMOUNT = min;
            MAX_AMOUNT = max;

            value = 1;
            int leftBounds = (int)((value - MIN_AMOUNT) / (MAX_AMOUNT - MIN_AMOUNT) * this.Width);
            slideBox = new Rectangle(leftBounds, 0, this.Width / 100, this.Height);
            bounds = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
        }

        public void initSlider(double inc, double min, double max)
        {
            INCREMENT = inc;
            MIN_AMOUNT = min;
            MAX_AMOUNT = max;
        }

        public void UpdatePos(Slider.direction dir)
        {
            switch(dir)
            {
                case direction.LEFT:
                    if (value > MIN_AMOUNT)
                        value -= INCREMENT;
                    break;
                case direction.RIGHT:
                    if (value < MAX_AMOUNT)
                        value += INCREMENT;
                    break;
            }
            int leftBounds;
            if (value >= MAX_AMOUNT)
                leftBounds = Width - slideBox.Width;
            else
                leftBounds  = (int)((value - MIN_AMOUNT) / (MAX_AMOUNT - MIN_AMOUNT) * this.Width);
            
            slideBox.Location = new Point(leftBounds, slideBox.Location.Y);

            Graphics gr = this.CreateGraphics();
            gr.Clear(sliderColor);
            gr.FillRectangle(Brushes.Red, slideBox);
        }

        private void Slider_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            gr.FillRectangle(Brushes.Red, slideBox);
        }
        
        private void Slider_Resize(object sender, EventArgs e)
        {
            bounds = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
        }
    }
}
