using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class UI : Form
    {

        // main UI for our application
        // maximize and quit buttons are temporary

        /*
        I had to look up the difference between the constructor and Form_Load. Superficially they seem to do the same thing. The constructor
        is immediately called on creation regardless of whether the form is displayed or not. The _Load method is called when the form becomes
        visible to the user. I am moving the code to the _Load section because that allows all forms within our program to be created before
        any of the elements are loaded. This isn't necessarily helpful now but may be useful in the future.
*/




        public Form self { get; set; }

        public UI()
        {
            InitializeComponent();
            this.self = this;


        }

        private void User_Interface_Load(object sender, EventArgs e)
        {
            drawButtons(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void drawButtons(object sender, EventArgs e)
        {
            /*
            ALSButton[] buttons = new ALSButton[8];

            for (int i = 0; i < 8; i++)
            {
                buttons[i] = new ALSButton();
                buttons[i].Visible = true;
                buttons[i].Location = new System.Drawing.Point(i * 128 + 1, 1);
                buttons[i].Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right); // well this kinda works...
                //buttons[i].Dock = (DockStyle.Left | DockStyle.Right);
                Controls.Add(buttons[i]);
            }


            buttons[2].Height = 64;
            buttons[2].Width = 64;
            buttons[3].Height = 228;
            ALSButton quitBut = new ALSButton();
            quitBut.Visible = true;
            quitBut.Location = new System.Drawing.Point(128 * 7, 768 -112);
            quitBut.Height = 112;
            Controls.Add(quitBut);

            //Properties.Resources
            ResourceManager rm = Properties.Resources.ResourceManager;

            buttons[0].BackgroundImage = (Image)rm.GetObject("chatbubbles");
            buttons[0].BackgroundImageLayout = ImageLayout.Stretch;

            quitBut.BackgroundImage = (Image)rm.GetObject("power");
            quitBut.BackgroundImageLayout = ImageLayout.Stretch;
            quitBut.Name = "quit";

    */
        }



        private void alsButton4_Click(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Maximized;

        }

        private void quitBut_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Form quitScreen = new QuitForm(this);
            quitScreen.ShowDialog(); 
            
           

        }

        private void setBut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SETtings");
            this.self.WindowState = System.Windows.Forms.FormWindowState.Maximized;//this doesn't work with dwell timing and I don't know why
            Debug.WriteLine("btnSet called.");
            //this.Size = new System.Drawing.Size(1000, 1000);
            /* this.Invalidate();
             this.Update();
             this.Refresh();
             Application.DoEvents();*/

        }

        private void setBut_MouseEnter(object sender, EventArgs e)
        {
            //this.button1.PerformClick();
            //this.setBut.PerformClick();
        }
    }
}
