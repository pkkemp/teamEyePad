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
        private int scrollPoint = 0;
        private const int SCROLL_INCREMENT = 100;
        private MouseRectangle mouseBox;
        private string tempHomepage = "http://www.facebook.com";
        private Timer timer;
        private bool isFullScreen;
        private ALSBrowserCntrl winBrowse;
        private Keyboard keyboard;

        public delegate void MainMenuClick(object sender, EventArgs args);
        public event MainMenuClick MainMenu_Click;

        public Browser()
        {
            InitializeComponent();
            initBrowser();

            timer = new Timer();
            timer.Tick += new System.EventHandler(timerEvent);
            timer.Interval = 100;
            timer.Enabled = true;

            mouseBox = new MouseRectangle(this);
            isFullScreen = false;
            makeKeyboard(false);

            winBrowse.Navigate(tempHomepage);
        }

        private void timerEvent(object sender, EventArgs e)
        {
            mouseBox.setClickmode(winBrowse.getMouseOver());
        }

        private void Press_Key(object sender, EventArgs e)
        {
            SendKeys.Send(keyboard.GetMostRecentEntry());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (MainMenu_Click != null)
                MainMenu_Click(this, e);
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

        private void initBrowser()
        {
            winBrowse = new ALSBrowserCntrl(this);
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


            //this.keyboard.BackColor = System.Drawing.Color.Black;
           

            keyboard.OnPressed += Press_Key;
            keyboard.Location = new Point(winBrowse.Location.X, winBrowse.Location.Y + winBrowse.Size.Height);
            keyboard.Size = new Size(winBrowse.Width, this.Height - (winBrowse.Location.Y + winBrowse.Size.Height));
            keyboard.HideTextBox();
            this.Controls.Add(this.keyboard);
        }

        private void Browser_Resize(object sender, EventArgs e)
        {
            setBrowserSize();
            keyboard.Location = new Point(winBrowse.Left, winBrowse.Bottom + MainMenu.GAP);
            keyboard.Size = new Size(winBrowse.Width, Height - keyboard.Top - MainMenu.GAP);   
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            isFullScreen = !isFullScreen;
            setBrowserSize();
            if (isFullScreen)
            {
                keyboard.Visible = false;
                btnKeyboard.Text = "Show\nKeyboard";
            }
            else
            {
                keyboard.Visible = true;
                btnKeyboard.Text = "Fullscreen";
            }
        }

        private void setBrowserSize()
        {
            if(isFullScreen)
            {
                winBrowse.Size = new Size(Width - winBrowse.Left - MainMenu.GAP, this.Height - MainMenu.GAP * 2);
            }
            else
            {
                winBrowse.Size = new Size(Width - winBrowse.Left - MainMenu.GAP, this.Height / 2 - MainMenu.GAP);
            }
        }
    }
}
