using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GameDevJobNotifier
{
    public static class SMTP
    {
        public static string FromAddress;
        public static string FromPassword;
        public static string ToAddress;
        public static string SmtpHost;

        static SMTP()
        {
            Env.Load(".env");
            FromAddress = Environment.GetEnvironmentVariable("SMTP_USER");
            FromPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
            ToAddress = Environment.GetEnvironmentVariable("SMTP_TO_USER");
            SmtpHost = Environment.GetEnvironmentVariable("SMTP_SERVER");
        }

        public static void SendEmail(string subject, string body)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = SmtpHost;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(FromAddress, FromPassword);
                using (MailMessage message = new MailMessage(FromAddress, ToAddress))
                {
                    message.Subject = subject;
                    message.Body = body;

                    try
                    {
                        smtp.Send(message);
                        Console.WriteLine("Message have been sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something went wrong: " + ex.Message);
                    }
                }
            }
        }
    }
}
