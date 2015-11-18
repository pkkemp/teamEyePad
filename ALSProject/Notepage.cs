using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Notepage : Form
    {
        public Notepage(Form parent, SpeechSynthesizer voice)
        {
            InitializeComponent();
        }

        public TextBox getTextBox()
        {
            return new TextBox();
        }

        public ALSButton getSaveButton()
        {
            return new ALSButton();
        }
    }
}
