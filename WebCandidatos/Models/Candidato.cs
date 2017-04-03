using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCandidatos.Models
{
    public class Candidato
    {
        public string nome { get; set; }
        public string email { get; set; }
        public int html { get; set; }
        public int css { get; set; }
        public int javascript { get; set; }
        public int python { get; set; }
        public int django { get; set; }
        public int ios { get; set; }
        public int android { get; set; }
    }
}