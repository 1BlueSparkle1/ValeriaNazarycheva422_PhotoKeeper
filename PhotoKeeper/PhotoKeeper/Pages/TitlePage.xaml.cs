﻿using PhotoKeeper.Components;
using System;
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

namespace PhotoKeeper.Pages
{
    /// <summary>
    /// Логика взаимодействия для TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        public TitlePage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.valuePage(new AddPhotoPage());
        }
    }
}
