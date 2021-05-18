using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using System.Threading.Tasks;
using System;

namespace TrackAnalyser.Utilities.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public async Task<bool> SendEmailAsync(string email, string password)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse("trackanalyser21@gmail.com"));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = "Track Analyser Password";
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = "Thank you for registering, here's your password: " +
                    password
                };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("trackanalyser21@gmail.com", "AAxwyz*hH");
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception e) 
            { 
                return false; 
            }
            return true;
        }
    }
}
