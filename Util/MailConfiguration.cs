using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class MailConfiguration
    {
        private string _email;
        private int _port;
        private string _password;
        private string _smtp;
        private bool _ssl;

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Smtp
        {
            get
            {
                return _smtp;
            }

            set
            {
                _smtp = value;
            }
        }

        public bool Ssl
        {
            get
            {
                return _ssl;
            }

            set
            {
                _ssl = value;
            }
        }
    }
}
