using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    public static class EmailFactory
    {
        private static ComposeEmail ComposeEmail;
        private static EmailClient EmailClient;

        //this is obviously just temporary and should contain the login info from GUI
        public static string hostname = "imap.gmail.com";
        public static string smtpHost = "smtp.gmail.com";
        public static string username = "teamEyePad@gmail.com";
        public static string password = "highEyeGuy";

        

        public static ComposeEmail GetComposeEmail()
        {
            if (ComposeEmail == null)
                ComposeEmail = new ComposeEmail(true);      //Change this
            return ComposeEmail;
        }

        public static EmailClient GetEmailClient()//a design decision needs to be made here. This could have parameters, or the parameters could be retrieved. I think retrieving would be best.
        {
            if (EmailClient == null)
            {
                EmailClient = new EmailClient(hostname, smtpHost, username, password);         //for instance new EmailClient(Email.getHost(), Email.getSMTP()... etc
            }
            return EmailClient;
        }
    }
}
