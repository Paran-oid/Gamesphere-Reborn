using Microsoft.VisualStudio.Services.Users;
using System.Net.Mail;

namespace GameSphereAPI.Models.Viewmodels.User_Informations___Other
{
    public class EmailSender
    {
        public static bool SendMail(
            string FromEmail,
            string FromEmailPassword,
            string FromEmailDisplayName,
            string ToEmail,
            string Username,
            string body,
            string subject)
        {
            bool res = false;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(FromEmail, FromEmailPassword);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            MailMessage mail = new MailMessage(new MailAddress(FromEmail, FromEmailDisplayName),
            new MailAddress(ToEmail, Username));

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtpClient.Send(mail);

            res = true;

            return res;
        }
    }
}