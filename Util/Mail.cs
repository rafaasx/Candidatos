﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace Util
{
    public class Mail
    {
        private MailConfiguration _mailConfiguration;

        public string EmailPara { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }
        /// <summary>
        /// Configuração armazenada no Web.config
        /// <add key="MailConfiguration" value="Email=nome@email.com;Password=;Smtp=smtp.email.com;Port=587;Ssl=true" />
        /// </summary>
        public Mail()
        {
            _mailConfiguration = new MailConfiguration();
            string mailConfiguration = ConfigurationSettings.AppSettings["MailConfiguration"];
            if (!string.IsNullOrEmpty(mailConfiguration))
            {
                _mailConfiguration.Email =
                    mailConfiguration.Split(';')
                        .Where(x => x.Split('=')[0] == "Email")
                        .Select(x => x.Split('=')[1])
                        .ToList()[0];
                _mailConfiguration.Smtp =
                    mailConfiguration.Split(';')
                        .Where(x => x.Split('=')[0] == "Smtp")
                        .Select(x => x.Split('=')[1])
                        .ToList()[0];
                _mailConfiguration.Ssl = Convert.ToBoolean(
                    mailConfiguration.Split(';')
                        .Where(x => x.Split('=')[0] == "Ssl")
                        .Select(x => x.Split('=')[1])
                        .ToList()[0]);
                _mailConfiguration.Password =
                    mailConfiguration.Split(';')
                        .Where(x => x.Split('=')[0] == "Password")
                        .Select(x => x.Split('=')[1])
                        .ToList()[0];
                _mailConfiguration.Port = Convert.ToInt32(
                    mailConfiguration.Split(';')
                        .Where(x => x.Split('=')[0] == "Port")
                        .Select(x => x.Split('=')[1])
                        .ToList()[0]);
            }
            else
            {
                throw new Exception("E-mail de envio não configurado.");
            }
        }

        public void Enviar()
        {
            if (!string.IsNullOrEmpty(EmailPara) && !string.IsNullOrEmpty(Body) && !string.IsNullOrEmpty(Subject))
            {
                MailMessage mail = new MailMessage(_mailConfiguration.Email, EmailPara)
                {
                    Subject = Subject,
                    IsBodyHtml = true,
                    Body = Body
                };
                SmtpClient smtpClient = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Port = _mailConfiguration.Port,
                    EnableSsl = _mailConfiguration.Ssl,
                    Host = _mailConfiguration.Smtp,
                    Credentials = new NetworkCredential(_mailConfiguration.Email, _mailConfiguration.Password)
            };
            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }
            else
            {
                if (string.IsNullOrEmpty(EmailPara))
                    throw new Exception("Destinatário não informado.");
                if (string.IsNullOrEmpty(Body))
                    throw new Exception("Corpo do e-mail não informado.");
                if (string.IsNullOrEmpty(Subject))
                    throw new Exception("Assunto do e-mail não informado.");
    }
}
    }
}
