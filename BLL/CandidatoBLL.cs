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
        /// <param name="pCandidatoInfo"></param>
        /// <returns></returns>
        public Retorno Enviar(CandidatoInfo pCandidatoInfo)
        {
            try
            {
                if (pCandidatoInfo != null && !string.IsNullOrEmpty(pCandidatoInfo.Nome) && !string.IsNullOrEmpty(pCandidatoInfo.Email))
                {
                    Mail mail = new Mail { EmailPara = pCandidatoInfo.Email, Subject = "Obrigado por se candidatar!" };
                    const int media = 7;
                    if (pCandidatoInfo.Html >= media || pCandidatoInfo.Css >= media ||
                        pCandidatoInfo.Javascript >= media)
                    {
                        mail.Body = Mensagem(pCandidatoInfo.Nome, "programador Front - End");
                        //mail.Body = string.Format("Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível" + 
                        //    " para programador Front - End entraremos em contato.", pCandidatoInfo.Nome);
                        mail.Enviar();
                    }
                    if (pCandidatoInfo.Python >= media || pCandidatoInfo.Django >= media)
                    {
                        mail.Body = Mensagem(pCandidatoInfo.Nome, "programador Back - End");
                        //mail.Body = string.Format("Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível" + 
                        //        " para programador Back - End entraremos em contato.", pCandidatoInfo.Nome);
                        mail.Enviar();
                    }
                    if (pCandidatoInfo.Android >= media || pCandidatoInfo.Ios >= media)
                    {
                        mail.Body = Mensagem(pCandidatoInfo.Nome, "programador Mobile");
                        //mail.Body = string.Format("Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível" +
                        //        " para programador Mobile entraremos em contato.", pCandidatoInfo.Nome);
                        mail.Enviar();
                    }
                    if (pCandidatoInfo.Html < media && pCandidatoInfo.Css < media && pCandidatoInfo.Javascript < media &&
                        pCandidatoInfo.Android < media && pCandidatoInfo.Ios < media && pCandidatoInfo.Python < media &&
                        pCandidatoInfo.Django < media)
                    {
                        mail.Body = Mensagem(pCandidatoInfo.Nome, "programador");
                        //mail.Body = string.Format("Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível" +
                        //        " para programador entraremos em contato.", pCandidatoInfo.Nome);
                        mail.Enviar();
                    }
                    return new Retorno(true, string.Format("Obrigado {0}.<br><br>Enviamos um e-mail para {1} confirmando sua candidatura.",
                        pCandidatoInfo.Nome, pCandidatoInfo.Email));
                }
                else
                {
                    throw new Exception("É obrigatório informar o nome e e-mail do candidato.");
                }
            }
            catch (Exception e)
            {
                return new Retorno(false, string.Format("Ops! Tivemos um problema com sua candidatura :( <br>Tente novamente mais tarde.<br><br>{0}", e.Message));
            }

        }

        private string Mensagem(string pNome, string pFuncao)
        {
            return string.Format("Olá {0}. <br><br>Obrigado por se candidatar, assim que tivermos uma vaga disponível" +
                            " para {1} entraremos em contato.", pNome, pFuncao);
        }
    }
}
