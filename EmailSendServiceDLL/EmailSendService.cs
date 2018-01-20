using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSendServiceDLL
{
    public class EmailSendService
    {
        private string Login { get; set; }
        private string Password { get; set; }
        private string HeaderText { get; set; }
        private string FullText { get; set; }
        private int SmtpPort { get; set; }
        private string SmtpServer { get; set; }

        public EmailSendService(string login, string pass, int smtpPort,
            string smtpServer) // Wind - зависимость от главного окна
        {
            Login = login;
            Password = pass;
            SmtpPort = smtpPort;
            SmtpServer = smtpServer;
        }

        /// <summary>
        /// Отправка письма, возвращает string с описанием что всё прошло успешно или подрбной ошибкой.
        /// </summary>
        /// <param name="mail">Почтоый адресс получателя</param>
        /// <param name="name">Почтовый адресс отправителя</param>
        /// <returns></returns>
        public string Send(string mail, string name) // Отправка письма
        {
            using (MailMessage mm = new MailMessage(Login, mail))
            {
                mm.Subject = HeaderText;
                mm.Body = FullText;
                mm.IsBodyHtml = false;
                using (SmtpClient sc = new SmtpClient(SmtpServer, SmtpPort))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(Login, Password);
                    try
                    {
                        sc.Send(mm);
                        return "Все прошло успешно!";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message.ToString();
                    }
                }
            }
        }
    }
}
