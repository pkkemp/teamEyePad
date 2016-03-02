using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{

    public class EmailMessage
    {
        private uint UID;

        public EmailMessage(String subject, String body, String destinationAddress, String sourceAddress, DateTime date, uint UID)
        {
            this.subject = subject;
            this.body = body;
            this.destinationAddress = destinationAddress;
            this.sourceAddress = sourceAddress;
            this.date = date;
            this.UID = UID;

        }

        public EmailMessage(String subject, String body, String destinationAddress, String sourceAddress, DateTime date)
        {
            this.subject = subject;
            this.body = body;
            this.destinationAddress = destinationAddress;
            this.sourceAddress = sourceAddress;
            this.date = date;

        }

        DateTime date { get; }

        public String subject
        {
            get; 
        }
        public String body
        {
            get; 
        }
        public String destinationAddress
        {
            get; 
        }
        public String sourceAddress
        {
            get;
        }

        public bool Equals(EmailMessage email)
        {
            if (email.GetHashCode().Equals(this.GetHashCode()))
                return true;
            else
                return false;
        }

        public int CompareTo(EmailMessage email)
        {
           
            switch(email.date.CompareTo(this.date))
            {
                case -1:
                    return -1;
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    Console.WriteLine("Invalid comparison");
                    return -99;
            }
        }

        public override int GetHashCode()
        {
            return (body.GetHashCode() ^ subject.GetHashCode() ^ destinationAddress.GetHashCode() ^ 
                sourceAddress.GetHashCode() ^ date.ToShortDateString().GetHashCode());
        }

        public uint getUID()
        {
            return UID;
        }
    }
}
