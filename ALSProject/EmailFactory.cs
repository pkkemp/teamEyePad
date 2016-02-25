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

        public static ComposeEmail GetComposeEmail()
        {
            if (ComposeEmail == null)
                ComposeEmail = new ComposeEmail(true);      //Change this
            return ComposeEmail;
        }

        public static EmailClient GetEmailClient()
        {
            if (EmailClient == null)
            {
                EmailClient = new EmailClient();
            }
            return EmailClient;
        }
    }
}
