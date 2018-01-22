using System;
using System.Net;
using System.Net.Mail;

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
            //Тесты на правильность заполнения значений
            if (string.IsNullOrEmpty(login)) throw new ArgumentNullException(nameof(login));
            if (string.IsNullOrEmpty(pass)) throw new ArgumentNullException(nameof(pass));
            //Заполняем поля
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
            //Тесты на правильность заданного значения mail
            if(string.IsNullOrEmpty(mail)) throw new ArgumentNullException(nameof(mail));
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
                        return ex.Message;
                    }
                }
            }
        }
    }
}
