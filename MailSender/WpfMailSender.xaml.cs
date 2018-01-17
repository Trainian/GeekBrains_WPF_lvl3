using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariableClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValue = "Value";
            cbSmtpPostSelect.ItemsSource = SmtpPortClass.Ports;
            cbSmtpPostSelect.DisplayMemberPath = "Key";
            cbSmtpPostSelect.SelectedValue = "Value";
            DBClass db = new DBClass();
            dgEmails.ItemsSource = db.Emails;
        }
        
        private void ButtonSend_Click(object sender, RoutedEventArgs e) //Отправка письма из вкладки "Редактор писем"
        {
            string Login = cbSenderSelect.Text;
            string Password = cbSenderSelect.SelectedValue.ToString();
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                SendErrorWindow sendError = new SendErrorWindow(new Exception("Не заполнено поле Логин или Пароль"));
                return;
            }
            EmailSendServiceClass sendMail = new EmailSendServiceClass(Login,Password, this);
            sendMail.SendMails((IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan()) // Проверка на то что поле не равно 00:00:00
            {
                SendErrorWindow error = new SendErrorWindow(new Exception("Не корректный формат даты"));
                error.Owner = this;
                error.Show();
                return;
            }
            DateTime dtSenDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime); // Объединяем выбранную дату и время
            if (dtSenDateTime < DateTime.Now) // Проверяем что выбранная дата и время не меньше текущей
            {
                SendErrorWindow error = new SendErrorWindow(new Exception("Дата и время отправки писем не могут быть раньше, чем настоящее время"));
                error.Owner = this;
                error.Show();
                return;
            }
            if (string.IsNullOrEmpty(HeaderText.Text) || string.IsNullOrEmpty(FullText.Text))
            {
                EditorOfLetters.Focus();
                SendErrorWindow error = new SendErrorWindow(new Exception("Заголовок и текст письма, не должны быть пустыми."));
                error.Owner = this;
                error.Show();
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword, this);
            sc.SendEmails(dtSenDateTime, emailSender, (IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strLogin) || string.IsNullOrEmpty(strPassword))
            {
                SendErrorWindow err = new SendErrorWindow(new Exception("Не задан Логин или Пароль"));
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin,strPassword,this);
            emailSender.Send(HeaderText.Text, FullText.Text);
        }

        private void btnGoToScheduler_Click(object sender, RoutedEventArgs e)
        {
            schedular.Focus();
        }
    }
}
