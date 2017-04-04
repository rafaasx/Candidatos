using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Retorno
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }

        public Retorno(bool pStatus, string pMensagem)
        {
            Status = pStatus;
            Mensagem = pMensagem;
        }
    }
}
