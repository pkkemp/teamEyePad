using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class ClearTextConfirmation : Form
    {
        Form parent;

        public ClearTextConfirmation(Form parent)
        {
            this.parent = parent;

            InitializeComponent();
            confirmation1.Cancel.Click += new EventHandler(Cancel);
            confirmation1.Confirm.Click += new EventHandler(Confirm);
        }

        private void Cancel(object sender, EventArgs e)
        {
            parent.Visible = true;
            parent.Enabled = true;
            Visible = false;
        }

        private void Confirm(object sender, EventArgs e)
        {
            if (parent is Notepage)
            {
                ((Notepage)parent).ClearText();
            }
            else if (parent is TextToSpeech)
            {
                ((TextToSpeech)parent).ClearText();
            }
            else if (parent is AddCallout)
            {
                ((AddCallout)parent).ClearText();
            }
            parent.Visible = true;
            parent.Enabled = true;
            parent.Focus();
            Visible = false;
        }
    }
}
