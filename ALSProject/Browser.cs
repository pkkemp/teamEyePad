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
    public partial class Browser : Form
    {
        private Form parentForm;
        private int scrollPoint = 0;
        private const int SCROLL_INCREMENT = 100;
        private TextBox keyboardTextBox;

        public Browser(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
            keyboard.hideTextBox();
            keyboardTextBox = keyboard.getTextBox();
            keyboardTextBox.TextChanged += new System.EventHandler(this.pressKey);
            

        }

       

        private void pressKey(object sender, EventArgs e)
        {

            System.Windows.Forms.SendKeys.Send(keyboardTextBox.Text[keyboardTextBox.TextLength - 1] + "");
        }

        private void alsAlarm1_Click(object sender, EventArgs e)
        {

        }

        private void alsButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void alsButton1_Click(object sender, EventArgs e)
        {
            winBrowse.Navigate(txtUrl.Text);
            scrollPoint = 0;
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            
            winBrowse.Document.Window.ScrollTo(new Point(0, scrollPoint - SCROLL_INCREMENT));
            scrollPoint -= SCROLL_INCREMENT;
        }

        private void btnScrollDown_Click(object sender, EventArgs e)
        {
            winBrowse.Document.Window.ScrollTo(new Point(0, scrollPoint + SCROLL_INCREMENT));
            scrollPoint += SCROLL_INCREMENT;
        }

        
    }
}
