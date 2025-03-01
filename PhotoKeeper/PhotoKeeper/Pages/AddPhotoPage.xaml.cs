using Microsoft.Win32;
using PhotoKeeper.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPhotoPage.xaml
    /// </summary>
    public partial class AddPhotoPage : Page
    {
        private Photo photo;
        public AddPhotoPage()
        {
            InitializeComponent();
            photo = new Photo();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            photo.UserId = App.thisUser.Id;
            photo.Description = DescriptionTb.Text;
            App.db.Photo.Add(photo);
            App.db.SaveChanges();
            if (PetCb.SelectedIndex == 0)
            {
                Photo_Pet photo_Pet = new Photo_Pet();
                photo_Pet.PhotoId = App.db.Photo.ToList().Last().Id;
                photo_Pet.PetId = 2;
                App.db.Photo_Pet.Add(photo_Pet);
                App.db.SaveChanges();
            }
            else if (PetCb.SelectedIndex == 1)
            {
                Photo_Pet photo_Pet = new Photo_Pet();
                photo_Pet.PhotoId = App.db.Photo.ToList().Last().Id;
                photo_Pet.PetId = 1;
                App.db.Photo_Pet.Add(photo_Pet);
                App.db.SaveChanges();
            }
            else
            {
                Photo_Pet photo_Pet = new Photo_Pet();
                photo_Pet.PhotoId = App.db.Photo.ToList().Last().Id;
                photo_Pet.PetId = 1;
                App.db.Photo_Pet.Add(photo_Pet);
                App.db.SaveChanges();
                Photo_Pet photo_Pet2 = new Photo_Pet();
                photo_Pet2.PhotoId = App.db.Photo.ToList().Last().Id;
                photo_Pet2.PetId = 2;
                App.db.Photo_Pet.Add(photo_Pet2);
                App.db.SaveChanges();
            }
            MessageBox.Show("Сохранено!");
            Navigations.valuePage(new ListImagePage());
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                photo.ImageBite = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
