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
        private double minAmount, maxAmount, increment;
        public double value;

        Rectangle slideBox;
        Rectangle bounds;
        private static Color sliderColor = Color.FromArgb(220, 220, 220);

        public Slider() : this(1, 0, 10)
        {

        }


        public Slider(double inc, double min, double max)
        {
            InitializeComponent();
            initSlider(inc, min, max);

        }

        public void initSlider(double inc, double min, double max)
        {
            increment = inc;
            minAmount = min;
            maxAmount = max;

            int numIncrements = (int)((max - min) / inc);

            value = numIncrements / 2 * inc + min;
            int leftBounds = (int)((value - minAmount) / (maxAmount - minAmount) * this.Width);
            slideBox = new Rectangle(leftBounds, 0, this.Width / 100, this.Height);
            bounds = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
        }

        public void UpdatePos(Slider.direction dir)
        {
            switch (dir)
            {
                case direction.LEFT:
                    if (value > minAmount)
                        value -= increment;
                    break;
                case direction.RIGHT:
                    if (value < maxAmount)
                        value += increment;
                    break;
            }
            int leftBounds;
            if (value >= maxAmount)
                leftBounds = Width - slideBox.Width;
            else
                leftBounds = (int)((value - minAmount) / (maxAmount - minAmount) * this.Width);

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
