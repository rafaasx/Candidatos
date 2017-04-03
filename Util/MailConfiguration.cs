using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class MailConfiguration
    {
        public string Email { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public string Smtp { get; set; }

        public bool Ssl { get; set; }
    }
}
