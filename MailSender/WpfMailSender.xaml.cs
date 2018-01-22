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
using EmailSendServiceDLL;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        EmailSendService emailSender; // Экземпляр класса, отвечающего за отправку писем
        public WpfMailSender()
        {
            InitializeComponent();
            changeMenuControlSender.ItemSource = VariableClass.Senders;
            changeMenuControlSender.DisplayMemberPath = "Key";
            changeMenuControlSmtp.ItemSource = SmtpPortClass.Ports;
            changeMenuControlSmtp.DisplayMemberPath = "Key";
            DBClass db = new DBClass();
            dgEmails.ItemsSource = db.Emails;
            tscTabSwitcher.IsHideBtnPrevios = true;
        }
        
        private void ButtonSend_Click(object sender, RoutedEventArgs e) //Отправка письма из вкладки "Редактор писем"
        {
            KeyValuePair<string, string> mySelectedItem = (KeyValuePair<string, string>)changeMenuControlSender.SelectedItem;
            string strLogin = mySelectedItem.Key;
            string strPassword = mySelectedItem.Value;
            if (string.IsNullOrEmpty(strLogin) || string.IsNullOrEmpty(strPassword))
            {
                SendErrorWindow sendError = new SendErrorWindow(new Exception("Не заполнено поле Логин или Пароль"));
                return;
            }
            EmailSendService sendMail = new EmailSendService(strLogin, strPassword, AppConfigClass.smtpPort,AppConfigClass.smtpServer);
            foreach (Emails email in dgEmails.ItemsSource)
            {
                sendMail.Send(email.Email, email.Name);
            }
        }

        private void miClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            KeyValuePair<string, string> mySelectedItem = (KeyValuePair<string,string>)changeMenuControlSender.SelectedItem;
            string strLogin = mySelectedItem.Key;
            string strPassword = mySelectedItem.Value;
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
            if (string.IsNullOrEmpty(headerText.Text) || string.IsNullOrEmpty(fullText.Text))
            {
                editorOfLetters.Focus();
                SendErrorWindow error = new SendErrorWindow(new Exception("Заголовок и текст письма, не должны быть пустыми."));
                error.Owner = this;
                error.Show();
                return;
            }
            sc.SendEmails(dtSenDateTime, emailSender, (IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, string> mySelectedItem = (KeyValuePair<string, string>)changeMenuControlSender.SelectedItem;
            string strLogin = mySelectedItem.Key;
            string strPassword = mySelectedItem.Value;
            if (string.IsNullOrEmpty(strLogin) || string.IsNullOrEmpty(strPassword))
            {
                SendErrorWindow err = new SendErrorWindow(new Exception("Не задан Логин или Пароль"));
                return;
            }
            EmailSendService sendMail = new EmailSendService(strLogin, strPassword, AppConfigClass.smtpPort, AppConfigClass.smtpServer);
            sendMail.Send(headerText.Text, fullText.Text);
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 1;
        }

        private void tscTabSwitcher_btnPreviosClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
