using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Util;
using Newtonsoft.Json;
using WebCandidatos.Models;

namespace WebCandidatos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public string Enviar(Candidato candidato)
        {
            Mail mail = new Mail {EmailPara = candidato.email, Subject = "Obrigado por se candidatar!"};
            const int media = 7;
            if (candidato.html >= media || candidato.css >= media || candidato.javascript >= media)
            {
                mail.Body = @"Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Front - End entraremos em contato.";
                mail.Enviar();
            }
            if (candidato.python >= media || candidato.django >= media)
            {
                mail.Body = @"Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Back - End entraremos em contato.";
                mail.Enviar();
            }
            if (candidato.android >= media || candidato.ios >= media)
            {
                mail.Body = @"Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador Mobile entraremos em contato.";
                mail.Enviar();
            }
            if (candidato.html < media && candidato.css < media && candidato.javascript < media &&
                candidato.android < media && candidato.ios < media && candidato.python < media &&
                candidato.django < media)
            {
                mail.Body = @"Obrigado por se candidatar, assim que tivermos uma vaga disponível
                            para programador entraremos em contato.";
                mail.Enviar();
            }

            return JsonConvert.SerializeObject(mail.Body);

        }
    }
}