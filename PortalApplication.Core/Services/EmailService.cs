using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace PortalApplication.Core
{
    public class EmailService
    {
        public readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        
        public void Send(string Id, string Email, string FirstName)
        {
            var Host = _config.GetSection("Smtp:Host").Value;
            var Port = _config.GetSection("Smtp:Port").Value;
            var Username = _config.GetSection("Smtp:Username").Value;
            var Password = _config.GetSection("Smtp:Password").Value;
            // var smtpClient = new SmtpClient("smtp.gmail.com")
            var smtpClient = new SmtpClient(Host)
            {
                Port= int.Parse(Port),
                Credentials = new NetworkCredential(Username, Password),
                // Credentials = new NetworkCredential("jimaxsolution360@gmail.com", "olaideolaide"),
                EnableSsl = true
            };
            
            
            var mailMessage = new MailMessage
            {
                From = new MailAddress(Username),
                Subject = "Sidmach - Confirm your account",
                Body = $"<div><h3>Hello {@FirstName}</h3><p>Kindly click <a href='https://localhost:5001/api/Auth/verify-user/{@Id}'>here</a> to verify your account.</p><br/><p>Thanks</p></div>",
                IsBodyHtml = true,
            };
            
            mailMessage.To.Add(Email);
            
            smtpClient.Send(mailMessage);
        }
    }
}