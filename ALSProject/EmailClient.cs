using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    class EmailClient
    {
        SmtpClient sendClient;

        public EmailClient()
        {
            StartSMTP();
        }

        public void StartSMTP()
        {
            sendClient = new SmtpClient("smtp.gmail.com");
            sendClient.Port = 587;
            sendClient.Credentials =
            new System.Net.NetworkCredential("teameyepad", "highEyeGuy");
            sendClient.EnableSsl = true;
        }

        public void sendMessage(MailMessage mail)
        {
            sendClient.Send(mail);
            //Console.WriteLine("Sending email");
        }

        public void retrieveMail()
        {

        }

    }
}
