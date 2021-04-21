using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TTracker
{
    public static class EmailLogic
    {
        public static void SendEmail( string to,string subject , string body)
        {
            string fromAddress = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"];
            //System.Configuration.ConfigurationManager.AppSettings["DisplaySender"]
            MailAddress fromMailAddress = new MailAddress();

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.From = fromMailAddress;
            SmtpClient Client = new SmtpClient();
            Client.Credentials = new System.Net.NetworkCredential( "","");
            Client.Host = "smtp.gmail.com";
            Client.Send(message);
        }
    }
}
