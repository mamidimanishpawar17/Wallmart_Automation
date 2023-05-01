using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Wallmart_Automation
{
    public class Email
    {
        public void SendEmail(string body)
        {
            var configData = ConfigurationManager.AppSettings;
            var fromEmail = configData.Get("FromEmail");
            var validateEmail = configData.Get("ValidateEmail");
            var toEmail = configData.Get("ToEmail");
            var smtp = configData.Get("SmtpServer");
            var password = configData.Get("Password");
            string subject = "WalMart Reports (WalMart Automation) -" + DateTime.Now.ToString("dd/MMM/yyyy");

            try
            {
                MailMessage message = new MailMessage();
                foreach (var address in toEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(address);
                }
                message.From = new MailAddress(fromEmail);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                SmtpClient client = new SmtpClient(smtp, 25);
                System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential(fromEmail, password);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential;
                client.Send(message);
                Console.WriteLine( "Email Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured! Error in sending an Email");
                Console.ReadKey();
            }
        }
    }
}
