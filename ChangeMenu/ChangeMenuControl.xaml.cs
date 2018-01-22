using System;
using System.Collections;
using System.Collections.Generic;
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

namespace ChangeMenu
{
    /// <summary>
    /// Меню для выбора и редактирования отправителя и сервера
    /// </summary>
    public partial class ChangeMenuControl : UserControl
    {
        public event RoutedEventHandler BtnAddSenderClick;
        public event RoutedEventHandler BtnEditSenderClick;
        public event RoutedEventHandler BtnDeleteSenderClick;

        public string MenuName { get => iSender.Content.ToString(); set => iSender.Content = value; }
        public IEnumerable ItemSource { get => cbSenderSelect.ItemsSource; set => cbSenderSelect.ItemsSource = value; }
        public string DisplayMemberPath { get => cbSenderSelect.DisplayMemberPath.ToString(); set => cbSenderSelect.DisplayMemberPath = value; }
        public string SelectedValue { get => cbSenderSelect.SelectedValue.ToString(); set => cbSenderSelect.SelectedValue = value; }

        public ChangeMenuControl()
        {
            InitializeComponent();
        }

        private void btnAddSender_Click(object sender, RoutedEventArgs e)
        {
            BtnAddSenderClick?.Invoke(sender, e);
        }

        private void btnEditSender_Click(object sender, RoutedEventArgs e)
        {
            BtnEditSenderClick?.Invoke(sender, e);
        }

        private void btnDeleteSender_Click(object sender, RoutedEventArgs e)
        {
            BtnDeleteSenderClick?.Invoke(sender, e);
        }
    }
}
