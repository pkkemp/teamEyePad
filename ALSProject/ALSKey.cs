using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public class ALSKey : ALSButton
    {


        public ALSKey()
        {


        }

        private void ALSButton_Click(object sender, EventArgs e)
        {
            if (!clicked)
            { //prevents rapid clicks
                clicked = true;
                ClearRect();
                dwellTimer.Enabled = true;

                pressKey();
            }

        }

        private void ALSButton_Resize(object sender, EventArgs e)
        {


        }

        private String pressKey()
        {
            return Text;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ALSKey
            // 
            this.FlatAppearance.BorderSize = 0;
            this.Resize += new System.EventHandler(this.ALSKey_Resize);
            this.ResumeLayout(false);

        }



        //I thought this would fix this and it didn't. Can you look at this Daniel? - Allison

        private void ALSKey_Resize(object sender, EventArgs e)
        {
            gr = this.CreateGraphics();

            if (this.Text != null)
            {
                float p = this.Font.SizeInPoints;
                this.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                this.Font = new Font(this.Font.Name, this.Width * 11 / 20);
                if (this.Width * 11 / 20 == 110)
                    this.Font = new Font(this.Font.Name, 40);
            }
        }
    }
}
