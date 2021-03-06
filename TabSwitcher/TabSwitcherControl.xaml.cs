﻿using System;
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

namespace TabSwitcher
{
    /// <summary>
    /// Логика взаимодействия для TabSwitcherControl.xaml
    /// </summary>
    public partial class TabSwitcherControl : UserControl
    {
        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviosClick;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }
        private void btnPrevios_Click(object sender, RoutedEventArgs e)
        {
            btnPreviosClick?.Invoke(sender, e);
        }

        private bool bHideBtnPrevios = false; // Поле соответствующее будет ли скрыта кнопка Предыдущий
        private bool bHideBtnNext = false; // Поле соответствующее будет ли скрыта кнопка Следующий
        /// <summary>
        /// Свойство соответсвующее будет ли скрыта кнопка Предыдущий
        /// </summary>
        public bool IsHideBtnPrevios
        {
            get { return bHideBtnPrevios; }
            set
            {
                bHideBtnPrevios = value;
                SetButtons(); // Метод, который отвечает за отрисовку кнопок
            }
        }
        /// <summary>
        /// Свойство соответсвующее будет ли скрыта кнопка Следующий
        /// </summary>
        public bool IsHideBtnNext
        {
            get { return bHideBtnNext; }
            set
            {
                bHideBtnNext = value;
                SetButtons(); // Метод, который отвечает за отрисовку кнопок
            }
        }

        private void BtnNextTrueBtnPreviosFalse()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrevios.Visibility = Visibility.Visible;
            btnPrevios.Width = 180;
            btnNext.Width = 0;
            btnPrevios.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void BtnPreviosTrueBtnNextFalse()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 180;
            btnPrevios.Width = 0;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void BtnPreviosFalseBtnNextFalse()
        {
            btnNext.Visibility = Visibility.Visible;
            btnPrevios.Visibility = Visibility.Visible;
            btnNext.Width = 90;
            btnPrevios.Width = 90;
        }

        private void BtnPreviosTrueBtnNextTrue()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод, который отвечает за отрисовку кнопок.
        /// Есть четыре варианта, когда обе кнопке доступны. Доступна одна и не доступна вторая. И обе кнопки не доступны.
        /// </summary>
        private void SetButtons()
        {
            if (bHideBtnPrevios && bHideBtnNext) BtnPreviosTrueBtnNextTrue();
            else if (!bHideBtnNext && !bHideBtnPrevios) BtnPreviosFalseBtnNextFalse();
            else if (bHideBtnNext && !bHideBtnPrevios) BtnNextTrueBtnPreviosFalse();
            else if (!bHideBtnNext && bHideBtnPrevios) BtnPreviosTrueBtnNextFalse();
        }
        public TabSwitcherControl()
        {
            InitializeComponent();
        }
    }
}
