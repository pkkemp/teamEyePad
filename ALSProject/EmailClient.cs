using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALSProject
{
    class EmailClient
    {
        SmtpClient sendClient;
        IMAPClient imapclient;

        public EmailClient()
        {
            StartSMTP();
            imapclient = new IMAPClient();
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


            imapclient.RunClient();

        }

        public List<String> getMailHistory()
        {
            return imapclient.getHistory();   
        }

        private class IMAPClient
        {

            static System.IO.StreamWriter sw = null;
            static System.Net.Sockets.TcpClient tcpc = null;
            static System.Net.Security.SslStream ssl = null;
            static string username, password;
            static string path;
            static int bytes = -1;
            static byte[] buffer;
            static StringBuilder sb = new StringBuilder();
            static byte[] dummy;
            string responseText;
            List<String> history;

            public IMAPClient()
            {
                history = new List<String>();
            }

            public List<String> getHistory()
            {
                return history;
            }

            //this part retrieves all the mail using imap
            public void RunClient()
            {
                try
                {
                    path = Environment.CurrentDirectory + "\\emailresponse.txt";

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    sw = new System.IO.StreamWriter(System.IO.File.Create(path));
                    // there should be no gap between the imap command and the \r\n       
                    // ssl.read() -- while ssl.readbyte!= eof does not work because there is no eof from server 
                    // cannot check for \r\n because in case of larger response from server ex:read email message 
                    // there are lot of lines so \r \n appears at the end of each line 
                    //ssl.timeout sets the underlying tcp connections timeout if the read or write 
                    //time out exceeds then the undelying connection is closed 
                    tcpc = new System.Net.Sockets.TcpClient("imap.gmail.com", 993);

                    ssl = new System.Net.Security.SslStream(tcpc.GetStream());
                    ssl.AuthenticateAsClient("imap.gmail.com");
                    responseText = receiveResponse("");
                    history.Add(responseText);

                    username = "teamEyePad@gmail.com";
                    password = "highEyeGuy";

                    responseText = receiveResponse("$ LOGIN " + username + " " + password + "  \r\n");
                    history.Add(responseText);

                    responseText = receiveResponse("$ LIST " + "\"\"" + " \"*\"" + "\r\n");



                    history.Add(responseText);

                    responseText = receiveResponse("$ SELECT INBOX\r\n");

                    history.Add(responseText);

                    responseText = receiveResponse("$ STATUS INBOX (MESSAGES)\r\n");

                    history.Add(responseText);


                    //Console.WriteLine("enter the email number to fetch :");
                    int number = 1; //int.Parse(Console.ReadLine());

                    //receiveResponse("$ FETCH " + number + " body[header]\r\n", ref responseText);

                    //history.Add(responseText);

                    responseText = receiveResponse("$ FETCH " + number + " body[text]\r\n");



                    history.Add("THIS IS DA BODY: " + responseText);




                    responseText = receiveResponse("$ LOGOUT\r\n");

                    history.Add(responseText);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                        sw.Dispose();
                    }
                    if (ssl != null)
                    {
                        ssl.Close();
                        ssl.Dispose();
                    }
                    if (tcpc != null)
                    {
                        tcpc.Close();
                    }
                }


                //Console.ReadKey();
            }

            static string receiveResponse(string command)
            {
                try
                {
                    if (command != "")
                    {
                        if (tcpc.Connected)
                        {
                            dummy = Encoding.ASCII.GetBytes(command);
                            ssl.Write(dummy, 0, dummy.Length);
                        }
                        else
                        {
                            throw new ApplicationException("TCP CONNECTION DISCONNECTED");
                        }
                    }
                    ssl.Flush();

                    //reads bytes into a buffer
                    //puts bytes into a string

                    buffer = new byte[2048];
                    bytes = ssl.Read(buffer, 0, 2048);
                    sb.Append(Encoding.ASCII.GetString(buffer));
                   

                    //returns the buffered data from the server as a string

                    String response = sb.ToString();
                    sw.WriteLine(sb.ToString());
                    sb = new StringBuilder();
                    return response;

                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }

        }


    }
}



