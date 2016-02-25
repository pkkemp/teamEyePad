using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22.Imap;

namespace ALSProject
{
    class EmailClient
    {
        SmtpClient sendClient;
        List<EmailMessage> MailList = new List<EmailMessage>();
        

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
        }

        public void retrieveMail()
        {

            string hostname = "imap.gmail.com",
             username = "teamEyePad@gmail.com", password = "highEyeGuy";
            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            {
                Console.WriteLine("We are connected!");
                // Returns a collection of identifiers of all mails matching the specified search criteria.
                IEnumerable<uint> uids = client.Search(SearchCondition.All());
                // Download mail messages from the default mailbox.
                IEnumerable<MailMessage> messages = client.GetMessages(uids.ToArray());
                IEnumerator<MailMessage> messageList = messages.GetEnumerator();
                while (messageList.MoveNext())
                {
                    

                    EmailMessage temp = new EmailMessage(messageList.Current.Subject, messageList.Current.Body,
                        messageList.Current.To[0].Address, messageList.Current.From.Address, DateTime.Now); //temp datetime

                    bool contains = false;

                    foreach (EmailMessage m in MailList)
                    {
                        if (m.GetHashCode().Equals(temp.GetHashCode()))
                            contains = true;
                    }

                    if (!contains)
                    {
                        bool added = false;
                        int index = 0;
                        while (!added && index < MailList.Count)
                        {
                            switch (MailList[index].CompareTo(temp))
                            {
                                case -1:
                                    MailList.Insert(index, temp);
                                    added = true;
                                    break;
                                case 0:
                                    MailList.Insert(index, temp);
                                    added = true;
                                    break;
                                case 1:
                                    index++;
                                    break;
                                case -99: //error code
                                    break;
                            }
                        }

                      }

                    }
                
            }

        }

        public List<EmailMessage> getMailHistory()
        {
            return MailList;
        }


    }
}



