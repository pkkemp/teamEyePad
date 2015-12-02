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
    public partial class Confirmation : UserControl
    {
        public ALSButton Cancel
        {
            get { return btnCancel; }
            set { btnCancel = value; }
        }

        public ALSButton Confirm
        {
            get { return btnConfirm; }
            set { btnConfirm = value; }
        }

        public Confirmation()
        {
            InitializeComponent();
        }
    }
}
