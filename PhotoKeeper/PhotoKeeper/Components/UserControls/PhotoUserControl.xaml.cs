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

namespace PhotoKeeper.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PhotoUserControl.xaml
    /// </summary>
    public partial class PhotoUserControl : UserControl
    {
        public PhotoUserControl(Photo photo)
        {
            InitializeComponent();
            PhotoImg.DataContext = photo;
            DescriptionTb.Text = photo.Description;
            if (photo.User == null)
            {
                AuthorTb.Text = "--";
            }
            else
            {
                AuthorTb.Text = photo.User.Login;
            }
        }
    }
}
