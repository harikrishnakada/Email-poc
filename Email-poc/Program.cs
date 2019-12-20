using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Email_poc
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var defaultLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fiilePath = Path.Combine(defaultLocation, @"Template.txt");

            string messagebody = string.Empty;

            if (File.Exists(fiilePath))
            {
                var str = File.ReadAllText(fiilePath);
                messagebody = string.Format(str, "Prasad", "Scholar", "Gold", "100");
            }

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("Enter From Email Address");
                message.To.Add(new MailAddress("Enter To Email Address"));
                message.Subject = "Recognition & Rewards";
                message.IsBodyHtml = true; //to make message body as html
                message.Body = messagebody;
                message.CC.Add(new MailAddress("Enter CC Email Address"));
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("hariktouchcoresystems@gmail.com", "*****");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) { }
        }
    }
}