using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class SmtpPortClass
    {
        public static Dictionary<string, int> Ports
        {
            get { return smtpPorts; }
        }
        private static Dictionary<string, int> smtpPorts = new Dictionary<string, int>()
        {
            {"SMTP-port - 25", 25 },
            {"SMTP-port - 80", 80 }
        };
    }
}
