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
        Form parent;
        EmailClient client;


        public Email(Form parent)
        {
            InitializeComponent();

            client = new EmailClient();
            this.CreateLayout(new System.ComponentModel.ComponentResourceManager(typeof(Email)));
            this.parent = parent;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Hide();

        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            client.sendMessage(new MailMessage("teameyepad@gmail.com", "allison.chilton@outlook.com", "Test Email", "This is the body of the test."));

        }

    }
}
