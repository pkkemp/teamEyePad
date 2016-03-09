using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using S22.Imap;
using System.Text.RegularExpressions;
using System.Threading;

namespace ALSProject

    
{
    public class EmailClient
    {

        String currentMailBox = "INBOX";
        SmtpClient sendClient;
        List<EmailMessage> MailList = new List<EmailMessage>();
        

        /*string hostname = "imap.gmail.com",
            username = "teamEyePad@gmail.com", password = "highEyeGuy";
            string smtpHost = "smtp.gmail.com";*/

        string imapHost; string username; string password; string smtpHost;
        
        public EmailClient(string imapHost, string smtpHost, string username, string password)
        {
            this.setLogin(imapHost, smtpHost, username, password);
            StartSMTP();
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
            try {
                MailMessage message = new MailMessage(mail.destinationAddress, mail.destinationAddress, mail.subject, mail.body);
                sendClient.Send(message);
            }
            catch(FormatException e)
            {
                ALSMessageBox mb = new ALSMessageBox("Invalid email format");
                mb.Show();
            }

                
            
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

        public void retrieveMail(String mailbox = "INBOX")
        {
            currentMailBox = mailbox;
            MailList.Clear();

            if (imapHost.Equals(null) || imapHost.Equals(null) || password.Equals(null))
            {
                throw new Exception("Not logged in");
            }

            
           
            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(imapHost, 993, username, password, AuthMethod.Login, true))
            {
                folders = client.ListMailboxes();
                Console.WriteLine("We are connected!");
                // Returns a collection of identifiers of all mails matching the specified search criteria.
                IEnumerable<uint> uids = null;
                uids = client.Search(SearchCondition.All(), mailbox);
                // Download mail messages from the default mailbox.
                IEnumerable<MailMessage> messages = client.GetMessages(uids.ToArray(), true , mailbox);
                IEnumerator<MailMessage> messageList = messages.GetEnumerator();
                IEnumerator<uint> uidList = uids.GetEnumerator();

                while (messageList.MoveNext())
                {
                    uidList.MoveNext();

                    EmailMessage temp = new EmailMessage(messageList.Current.Subject, messageList.Current.Body,
                        messageList.Current.To[0].Address, messageList.Current.From.Address, EmailClient.Date(messageList.Current),
                        uidList.Current); 

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

            MailList.Reverse();

        }

        String[] folders;

        public string[] ListFolders()
        {
            if (folders == null)
            {
                using (ImapClient client = new ImapClient(imapHost, 993, username, password, AuthMethod.Login, true))
                {
                    folders = client.ListMailboxes();
                }
            }

            return folders;
        }

        

        public void DeleteMessage(EmailMessage email)
        {
            using (ImapClient client = new ImapClient(imapHost, 993, username, password, AuthMethod.Login, true))
            {

                try { client.MoveMessage(email.getUID(), "[Gmail]/Trash"); }
                catch(BadServerResponseException e)
                {
                    //be really sad
                }

            }
        }

        public List<EmailMessage> getMailHistory()
        {
            return MailList;
        }

        public static DateTime Date(MailMessage message)
        {
            string date = message.Headers["Date"];
            if (String.IsNullOrEmpty(date))
                throw new Exception("Date is null");
            // Dates are sometimes suffixed with comments indicating the timezone, for example:
            // Tue, 29 Mar 2005 15:11:45 -0800 (PST).
            date = Regex.Replace(date, @"\([^\)]+\)", String.Empty);
            try
            {
                return DateTime.Parse(date);
            }
            catch (FormatException)
            {
                throw new Exception("Date cannot be parsed");
            }
        }

        public string getCurrentFolder()
        {
            return currentMailBox;
        }
    }

    
}



