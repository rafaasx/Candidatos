using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Microsoft.Ajax.Utilities;
using Model;
using Util;
using Newtonsoft.Json;

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
        public string Enviar(CandidatoInfo candidato)
        {
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            string retorno = candidatoBLL.Enviar(candidato);
            return JsonConvert.SerializeObject(retorno);

        }
    }
}