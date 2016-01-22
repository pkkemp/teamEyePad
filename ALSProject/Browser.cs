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
        private MouseRectangle mouseBox;
        private string tempHomepage = "http://www.facebook.com";
        private Timer timer;

        public Browser(Form parent)
        {
            parentForm = parent;
            InitializeComponent();
            initBrowser();

            timer = new Timer();
            timer.Tick += new System.EventHandler(timerEvent);
            timer.Interval = 100;
            timer.Enabled = true;

            mouseBox = new MouseRectangle(this);
            keyboard.HideTextBox();
            keyboardTextBox = keyboard.GetTextBox();
            keyboardTextBox.TextChanged += new System.EventHandler(this.pressKey);
            winBrowse.Navigate(tempHomepage);


        }

        private void timerEvent(object sender, EventArgs e)
        {
            mouseBox.setClickmode(winBrowse.getMouseOver());
        }

        private void pressKey(object sender, EventArgs e)
        {
            if (keyboardTextBox != null && keyboardTextBox.Text != "")
                System.Windows.Forms.SendKeys.Send(keyboardTextBox.Text[keyboardTextBox.TextLength - 1] + "");
        }

        private void alsAlarm1_Click(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            winBrowse.GoBack();
        }

        private ALSBrowserCntrl winBrowse;
        private void initBrowser()
        {
            winBrowse = new ALSBrowserCntrl(this);
            this.winBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.winBrowse.Location = new System.Drawing.Point(129, 12);
            this.winBrowse.MinimumSize = new System.Drawing.Size(20, 20);
            this.winBrowse.Name = "winBrowse";
            this.winBrowse.ScrollBarsEnabled = false;
            this.winBrowse.Size = new System.Drawing.Size(867, 330);
            this.winBrowse.TabIndex = 5;
            this.Controls.Add(this.winBrowse);
        }

        public void makeKeyboard(bool isQwerty)
        {
            Controls.Remove(keyboard);
            if (isQwerty) //this variable is declared in the designer code so it might be automatically changed and break
                keyboard = new KeyboardControl3(this); 
            else
                keyboard = new KeyboardControl2(this);
            keyboard.Location = new Point(winBrowse.Location.X, winBrowse.Location.Y + winBrowse.Size.Height);
            keyboard.Size = new Size(winBrowse.Width, this.Height - (winBrowse.Location.Y + winBrowse.Size.Height));
            //TextToSpeech_Resize(this, null);
            keyboard.HideTextBox();
            //keyboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Bottom;
            Invalidate();
        }

        private void Browser_Resize(object sender, EventArgs e)
        {
            keyboard.Location = new Point(winBrowse.Location.X, winBrowse.Location.Y + winBrowse.Size.Height);
            keyboard.Size = new Size(winBrowse.Width, this.Height - (winBrowse.Location.Y + winBrowse.Size.Height));
            this.btnMenu.setFontSize();
            this.btnBack.setFontSize();
            this.btnScrollDown.setFontSize();
            this.btnScrollUp.setFontSize();
            this.btnGo.setFontSize();
            this.btnMenu.Text = "Main\nMenu";
        }
    }
}
