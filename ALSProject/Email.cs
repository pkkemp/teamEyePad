using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    public partial class Email : Form
    {
        EmailClient client;

        public delegate void MainMenuClick(object sender, EventArgs args);
        public event MainMenuClick MainMenu_Click;

        public Email()
        {
            InitializeComponent();

            client = new EmailClient();
            this.CreateLayout(new System.ComponentModel.ComponentResourceManager(typeof(Email)));
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Hide();
            if (MainMenu_Click != null)
                MainMenu_Click(this, e);
        }
        
        private void btnTest_Click(object sender, EventArgs e)
        {
            client.sendMessage(new MailMessage("teameyepad@gmail.com", "allison.chilton@outlook.com", "Test Email", "This is the body of the test."));
        }
    }
}
