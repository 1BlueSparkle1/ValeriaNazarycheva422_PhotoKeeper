using PhotoKeeper.Components;
using PhotoKeeper.Components.UserControls;
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
    /// Логика взаимодействия для ListImagePage.xaml
    /// </summary>
    public partial class ListImagePage : Page
    {
        public ListImagePage()
        {
            InitializeComponent();
            IEnumerable<Photo_Pet> photos = new List<Photo_Pet>();
            if (App.thisUser.Id == 1)
            {
                photos = App.db.Photo_Pet.ToList().Where(x => x.PetId == 2);
            }
            else
            {
                photos = App.db.Photo_Pet.ToList().Where(x => x.PetId == 1);
            }
            foreach (Photo_Pet photo in photos)
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo.Photo));
            }

            IEnumerable<User> users = App.db.User.ToList();
            List<string> filter = new List<string>();
            filter.Add("Все");
            foreach (var user in users)
            {
                filter.Add(user.Login);
            }

            AuthorCb.ItemsSource = filter;

        }

        public void Refresh()
        {
            IEnumerable<Photo_Pet> photo_Pets = App.db.Photo_Pet.ToList();
            if (App.thisUser.Id == 1)
            {
                photo_Pets = App.db.Photo_Pet.ToList().Where(x => x.PetId == 2);
            }
            else
            {
                photo_Pets = App.db.Photo_Pet.ToList().Where(x => x.PetId == 1);
            }
            if (AuthorCb.SelectedIndex > 0)
            {
                photo_Pets = photo_Pets.Where(x => x.Photo.User.Login == AuthorCb.Text);
            }
            photo_Pets = photo_Pets.Where(x => x.Photo.Description.ToLower().Contains(SerchTb.Text.ToLower()));

            PhotoWp.Children.Clear();
            foreach (Photo_Pet photo in photo_Pets)
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo.Photo));
            }
        }
    }
}
