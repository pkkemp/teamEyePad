using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public class ALSKey : ALSButton
    {


        public ALSKey() : base()
        {
        }

        private void ALSButton_Click(object sender, EventArgs e)
        {
            // prevents rapid clicks
            if (!clicked)
            {
                clicked = true;
                Invalidate();
                dwellTimer.Enabled = true;

                pressKey();
            }

        }

        private String pressKey()
        {
            return Text;
        }

    }
}
