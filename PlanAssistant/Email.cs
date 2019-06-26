using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PlanAssistant
{
    public class Email : Entity
    {
        // отправитель - устанавливаем адрес и отображаемое в письме имя
        public MailAddress From { get; set; }
        public MailAddress To { get; set; }

        public Email()
        {
            From = new MailAddress("dinara_myrzabek@mail.ru", "Dinara");
        }

        public void SendMessage(string header, string body)
        {
            string toEmail = To.Address;

            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(From.Address, "J21Z9Z4U")
            };
            MailMessage mailMessage = new MailMessage(From.Address, toEmail, header, body)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            client.Send(mailMessage);
        }
    }
}
