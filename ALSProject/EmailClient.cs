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
    public class EmailClient
    {
        SmtpClient sendClient;
        List<EmailMessage> MailList = new List<EmailMessage>();
        

        /*string hostname = "imap.gmail.com",
            username = "teamEyePad@gmail.com", password = "highEyeGuy";
            string smtpHost = "smtp.gmail.com";*/

        string imapHost; string username; string password; string smtpHost;
        


        public EmailClient(string imapHost, string smtpHost, string username, string password)
        {
            this.setLogin(imapHost, smtpHost, username, password);

        }

        public void setLogin(string imapHost, string smtpHost, string username, string password)
        {
            this.imapHost = imapHost;
            this.smtpHost = smtpHost;
            this.username = username;
            this.password = password;
        }

        private void StartSMTP()
        {
            sendClient = new SmtpClient(smtpHost);
            sendClient.Port = 587;

            sendClient.Credentials = new System.Net.NetworkCredential("teameyepad", "highEyeGuy");
            sendClient.EnableSsl = true;
        }

        public void sendMessage(EmailMessage mail)
        {
            MailMessage message = new MailMessage(mail.sourceAddress, mail.destinationAddress, mail.subject, mail.body);
            sendClient.Send(message);
        }

        public void sendMessage(string sourceAddress, string destinationAddress, string subject, string body)
        {
            MailMessage message = new MailMessage(sourceAddress,destinationAddress,subject,body);
            sendClient.Send(message);
        }

        public void sendReply(EmailMessage emailBeingRespondedTo, string body)
        {
            string subjectWithRe;
            string bodyWithHistory = body + "\n\n\n" + emailBeingRespondedTo.body;
            if(!emailBeingRespondedTo.subject.Substring(0,3).Equals("RE:"))
                subjectWithRe = "RE: " + emailBeingRespondedTo.subject;
            else
                subjectWithRe = emailBeingRespondedTo.subject;



            MailMessage message = new MailMessage(username, emailBeingRespondedTo.sourceAddress, subjectWithRe, bodyWithHistory);
            sendClient.Send(message);
        }

        public void sendForward(EmailMessage forwardedEmail, string destinationAddress, string newBody)
        {
            string originalMessage = "Original: \n From: "+ forwardedEmail.sourceAddress + "\nTo: "+forwardedEmail.destinationAddress
                + "\n Subject: "+forwardedEmail.subject+"\n"+forwardedEmail.body;

            string combinedBody = newBody + "\n\n\n" + originalMessage;
            string subject = "Fwd: " + forwardedEmail.subject;

            MailMessage message = new MailMessage(username, destinationAddress, subject, combinedBody);
            sendClient.Send(message);
        }

        public void retrieveMail()
        {
            if (imapHost.Equals(null) || imapHost.Equals(null) || password.Equals(null))
            {
                throw new Exception("Not logged in");
            }
           
            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(imapHost, 993, username, password, AuthMethod.Login, true))
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
                        messageList.Current.To[0].Address, messageList.Current.From.Address, DateTime.Now); //this datetime needs to look for the date the email was sent
                    int hash = temp.GetHashCode();

                    bool contains = false;

                    foreach (EmailMessage m in MailList)
                    {
                        if (m.GetHashCode().Equals(hash))
                            contains = true;
                    }

                    if (!contains)
                    {
                        bool added = false;
                        int index = 0;
                        if (MailList.Count == 0)
                        {
                            MailList.Add(temp);
                        }
                        else
                        {

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
                            if (!added)
                                MailList.Add(temp);
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



