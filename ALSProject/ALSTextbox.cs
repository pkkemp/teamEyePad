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
    public partial class ALSTextbox : TextBox
    {

        Timer dwellTimer = new Timer();
        private int heightDivider = 30;
        int heightCounter;
        Graphics gr;
        bool clicked;
        Color baseColor = Color.White;

        public ALSTextbox()
        {
            
            InitializeComponent();
            dwellTimer = new Timer();
            dwellTimer.Enabled = false;
            dwellTimer.Tick += new EventHandler(dwellTimeEvent);

        }

        protected void dwellTimeEvent(object sender, EventArgs e)
        {

            this.CreateGraphics().FillRectangle(new SolidBrush(Color.FromArgb(127, 128, 128, 128)), new Rectangle(0, this.Height - heightCounter, this.Width, this.Height / heightDivider));

            if (heightCounter > this.Height)
            {

                this.OnClick(e);
            }
            else
            {
                heightCounter += this.Height / heightDivider;
            }
        }

        private void ALSTextbox_MouseEnter(object sender, EventArgs e)
        {
            dwellTimer.Enabled = true;
        }

        private void ALSTextBox_MouseLeave(object sender, EventArgs e)
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


        private void ALSTextbox_Resize(object sender, EventArgs e)
        {
            gr = this.CreateGraphics();
        }

        private void ALSTextbox_Click(object sender, EventArgs e)
        {

            if (!clicked)
            { //prevents rapid clicks
                clicked = true;
                ClearRect();
                dwellTimer.Enabled = true;

                this.Focus();

                //reset
                dwellTimer.Stop();
                dwellTimer.Start();
                this.Refresh();
            }

        }
    }
}
