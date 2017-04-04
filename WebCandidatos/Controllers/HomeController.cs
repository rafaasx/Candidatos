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
        
        [HttpPost]
        public string Enviar(CandidatoInfo pCandidatoInfo)
        {
            CandidatoBLL candidatoBLL = new CandidatoBLL();
            Retorno retorno = candidatoBLL.Enviar(pCandidatoInfo);
            return JsonConvert.SerializeObject(retorno);
        }
    }
}