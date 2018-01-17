using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
    class EmailSendServiceClass
    {
        private string Login { get; set; }
        private string Password { get; set; }
        private string Smtp { get; set; }
        private string SmtpPort { get; set; }
        private string HeaderText { get; set; }
        private string FullText { get; set; }
        private Window Wind { get; set; }
        public EmailSendServiceClass(string login, string pass, Window wind) // Wind - зависимость от главного окна
        {
            Login = login;
            Password = pass;
            Wind = wind;
        }

        public void Send(string mail, string name) // Отправка письма
        {
            using (MailMessage mm = new MailMessage(Login, mail))
            {
                mm.Subject = HeaderText;
                mm.Body = FullText;
                mm.IsBodyHtml = false;
                using (SmtpClient sc = new SmtpClient(AppConfigClass.smtpServer, AppConfigClass.smtpPort))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(Login, Password);
                    try
                    {
                        sc.Send(mm);
                        SendEndWindow end = new SendEndWindow();
                        end.Owner = Wind;
                        end.Show();
                    }
                    catch (Exception ex)
                    {
                        SendErrorWindow error = new SendErrorWindow(ex);
                        error.Owner = Wind;
                        error.Show();
                    }
                }
            }
        }
        public void SendMails(IQueryable<Emails> emails) // Отправка нескольких писем
        {
            foreach (Emails email in emails)
            {
                Send(email.Email, email.Name);
            }
        }
    }
}
