using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;
using EmailSendServiceDLL;

namespace MailSender
{
    /// <summary>
    /// Класс планировщик, который создает расписание, следит за его выполнением и напоминает о событиях.
    /// Так же помогает автоматизировать рассылку писем в соответствии с расписанием.
    /// </summary>
    class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer(); // Таймер
        EmailSendService emailSender; // Экземпляр класса, отвечающего за отправку писем
        DateTime dtSend; // дата и время отправки
        IQueryable<Emails> emails; // коллекция email адрессов

        /// <summary>
        /// Метод, который строку из текстбокса tbTimerPicker в TimeSpan
        /// </summary>
        /// <param name="strSendTime"></param>
        /// <returns></returns>
        public TimeSpan GetSendTime (string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return tsSendTime;
        }
        /// <summary>
        /// Непосредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails(DateTime dtSend, EmailSendService emailSender, IQueryable<Emails> emails)
        {
            this.emailSender = emailSender;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                foreach (Emails email in emails)
                {
                    emailSender.Send(email.Email, email.Name);
                }
                timer.Stop();
                SendEndWindow endWindow = new SendEndWindow();
                endWindow.Show();
            }
        }
    }
}
