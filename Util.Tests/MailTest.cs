using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests
{
    [TestClass]
    public class MailTest
    {
        [TestMethod]
        public void Enviar_Email_Correto()
        {
            Mail mail = new Mail
            {
                EmailPara = "rafaeltwisted@gmail.com",
                Body = "<h1>E-mail de teste!</h1>",
                Subject = "Assunto E-mail de Teste"
            };
            mail.Enviar();
        }

        [TestMethod]
        public void Enviar_Email_Sem_Destinatario()
        {
            Mail mail = new Mail
            {
                Body = "<h1>E-mail de teste!</h1>",
                Subject = "Assunto E-mail de Teste"
            };
            mail.Enviar();
            
        }
        [TestMethod]
        public void Enviar_Email_Sem_Body()
        {
            Mail mail = new Mail
            {
                EmailPara = "rafaeltwisted@gmail.com",
                Subject = "Assunto E-mail de Teste"
            };
            mail.Enviar();
        }

        [TestMethod]
        public void Enviar_Email_Sem_Subject()
        {
            Mail mail = new Mail
            {
                EmailPara = "rafaeltwisted@gmail.com",
                Body = "<h1>E-mail de teste!</h1>"
            };
            mail.Enviar();
        }

        [TestMethod]
        public void Enviar_Email_Vazio()
        {
            Mail mail = new Mail();
            mail.Enviar();
        }
    }
}
