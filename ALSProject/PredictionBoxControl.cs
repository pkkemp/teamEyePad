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
    public partial class PredictionBoxControl : UserControl
    {
        private int GAP = KeyboardControl.GAP;
        public PredictionBoxControl(Form parent)
        {
            InitializeComponent();
            this.Size = new Size(KeyboardControl.spacebarLocation.X-GAP*2, parent.Height-KeyboardControl.spacebarLocation.Y);

        }

        public PredictionBoxControl(UserControl parent)
        {
            InitializeComponent();
            this.Size = new Size(KeyboardControl.spacebarLocation.X - GAP * 2, parent.Height - KeyboardControl.spacebarLocation.Y);

        }
    }
}
