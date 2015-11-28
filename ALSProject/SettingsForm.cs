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

        //TODO: make a setting for keyboard button speed vs all ALSButton speed

        public SettingsForm(Form pForm)
        {
            InitializeComponent();
            parentForm = pForm;
            update();
        }

        private void alsButton1_Click(object sender, EventArgs e)
        {
            slider1.UpdatePos(Slider.direction.LEFT);
            update();
        }

        private void alsButton2_Click(object sender, EventArgs e)
        {
            slider1.UpdatePos(Slider.direction.RIGHT);
            update();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void update()
        {
            label2.Text = "" + slider1.value;
            ALSButton.setTimerSpeed(slider1.value, ALSButton.ButtonType.normal);
        }

        private void SettingsForm_Resize(object sender, EventArgs e)
        {
            label1.Location = new Point(Width / 2 - label1.Width / 2, label1.Top);
            label2.Location = new Point(Width / 2 - label2.Width / 2, label2.Top);
        }
    }
}
