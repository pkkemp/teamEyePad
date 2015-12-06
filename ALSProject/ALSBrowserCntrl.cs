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
    public partial class ALSBrowserCntrl : WebBrowser
    {
        private Form parentForm;
        MouseRectangle mouseBox;
        Timer timer;
        

        public ALSBrowserCntrl(Form parent)
        {
            parentForm = parent;
            mouseBox = new MouseRectangle(this);
            InitializeComponent();

        }

    }
}
