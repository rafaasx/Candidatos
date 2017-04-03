using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace Util
{
    public class Mail
    {
        private string _emailPara;
        private MailConfiguration _mailConfiguration;

        public string EmailPara
        {
            get
            {
                return _emailPara;
            }

            set
            {
                _emailPara = value;
            }
        }

        public Mail()
        {
            _mailConfiguration.Email = "rafaeltwisted@gmail.com";
            _mailConfiguration.Smtp = "smtp.gmail.com";
            _mailConfiguration.Ssl = true;
            _mailConfiguration.Password = "";
            _mailConfiguration.Port = 465;
        }

        public void Enviar()
        {
            MailMessage mail = new MailMessage(_mailConfiguration.Email, _emailPara);
            SmtpClient client = new SmtpClient();
            client.Port = _mailConfiguration.Port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = _mailConfiguration.Ssl;
            client.Host = _mailConfiguration.Smtp;
            mail.Subject = "Assunto";
            mail.Body = "Corpo do e-mail!";
            client.Send(mail);
        }
    }
}
