using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Util;

namespace BLL
{
    public class CandidatoBLL
    {
        /// <summary>
        /// Enviar e-mail para o candidato
        /// </summary>
        /// <param name="candidatoInfo"></param>
        /// <returns></returns>
        public string Enviar(CandidatoInfo candidatoInfo)
        {
            try
            {
                Mail mail = new Mail { EmailPara = candidatoInfo.Email, Subject = "Obrigado por se candidatar!" };
                const int media = 7;
                if (candidatoInfo.Html >= media || candidatoInfo.Css >= media || candidatoInfo.Javascript >= media)
                {
                    mail.Body = string.Format(@"Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Front - End entraremos em contato.", candidatoInfo.Nome);
                    mail.Enviar();
                }
                if (candidatoInfo.Python >= media || candidatoInfo.Django >= media)
                {
                    mail.Body = string.Format(@"Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Back - End entraremos em contato.", candidatoInfo.Nome);
                    mail.Enviar();
                }
                if (candidatoInfo.Android >= media || candidatoInfo.Ios >= media)
                {
                    mail.Body = string.Format(@"Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Mobile entraremos em contato.", candidatoInfo.Nome);
                    mail.Enviar();
                }
                if (candidatoInfo.Html < media && candidatoInfo.Css < media && candidatoInfo.Javascript < media &&
                    candidatoInfo.Android < media && candidatoInfo.Ios < media && candidatoInfo.Python < media &&
                    candidatoInfo.Django < media)
                {
                    mail.Body = string.Format(@"Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador entraremos em contato.", candidatoInfo.Nome);
                    mail.Enviar();
                }
                return mail.Body;
            }
            catch (Exception e)
            {
                return e.Message + "<br><br>" + e.StackTrace + "<br<br>" + candidatoInfo.Nome + " " + candidatoInfo.Email;
            }
            
        }
    }
}
