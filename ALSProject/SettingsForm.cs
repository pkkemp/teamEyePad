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
    public partial class SettingsForm : Form
    {
        Form parentForm;

        //TO DO: make a setting for keyboard button speed vs all ALSButton speed


        public SettingsForm(Form pForm)
        {
            InitializeComponent();
            parentForm = pForm;
        }

        private void alsButton1_Click(object sender, EventArgs e)
        {
            slider1.UpdatePos(Slider.direction.LEFT);
            label2.Text = "Seconds: " + slider1.value;
        }

        private void alsButton2_Click(object sender, EventArgs e)
        {
            slider1.UpdatePos(Slider.direction.RIGHT);
            label2.Text = "Seconds: " + slider1.value;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Visible = true;
            this.Close();
        }
    }
}
