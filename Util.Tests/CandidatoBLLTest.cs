using System;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Util.Tests
{
    [TestClass]
    public class CandidatoBLLTest
    {
        [TestMethod]
        public void Enviar_Email_Back_End()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "rafaeltwisted@gmail.com", Nome = "Rafael Xavier", Android = 0, Css = 0, Django = 10, Html = 0, Ios = 0, Javascript = 0, Python = 10 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsTrue(retorno.Status);
        }

        [TestMethod]
        public void Enviar_Email_Front_End()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "rafaeltwisted@gmail.com", Nome = "Rafael Xavier", Android = 0, Css = 0, Django = 0, Html = 10, Ios = 0, Javascript = 10, Python = 0 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsTrue(retorno.Status);

        }
        [TestMethod]
        public void Enviar_Email_Mobile()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "rafaeltwisted@gmail.com", Nome = "Rafael Xavier", Android = 10, Css = 0, Django = 0, Html = 0, Ios = 10, Javascript = 0, Python = 0 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsTrue(retorno.Status);
        }

        [TestMethod]
        public void Enviar_Email_Sem_Generico()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "rafaeltwisted@gmail.com", Nome = "Rafael Xavier", Android = 0, Css = 0, Django = 0, Html = 0, Ios = 0, Javascript = 0, Python = 0 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsTrue(retorno.Status);
        }

        [TestMethod]
        public void Enviar_Email_Sem_Destinatario()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "", Nome = "Rafael Xavier", Android = 0, Css = 0, Django = 10, Html = 0, Ios = 0, Javascript = 0, Python = 10 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsFalse(retorno.Status);
        }

        [TestMethod]
        public void Enviar_Email_Sem_Nome()
        {
            CandidatoInfo candidatoInfo = new CandidatoInfo { Email = "rafaeltwisted@gmail.com", Nome = "", Android = 0, Css = 0, Django = 10, Html = 0, Ios = 0, Javascript = 0, Python = 10 };
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(candidatoInfo);
            Assert.IsFalse(retorno.Status);
        }
    }
}
