using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class DBClass
    {
        private EmailsDataContext _emails = new EmailsDataContext();
        public IQueryable<Emails> Emails
        {
            get
            {
                return from c in _emails.Emails select c;
            }
        }
    }
}
