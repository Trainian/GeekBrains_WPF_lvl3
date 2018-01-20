using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodePasswordDLL;

namespace MailSender
{
    public static class VariableClass
    {
        public static Dictionary<string, string>Senders
        {
            get { return dicSenders; }
        }
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            {"79257443993@yandex.ru", CodePassword.getPassword("1234l;i")},
            {"sok74@yandex.ru", CodePassword.getPassword(";liq34tjk") }
        };
    }
}
