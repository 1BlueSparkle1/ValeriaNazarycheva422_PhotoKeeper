using PhotoKeeper.Components;
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
    /// Логика взаимодействия для LeftProfilePage.xaml
    /// </summary>
    public partial class LeftProfilePage : Page
    {
        public LeftProfilePage()
        {
            InitializeComponent();
            NameTb.Text = App.thisUser.Login;
            if (App.thisUser.RoleId == 1)
            {
                LogoImg.Source = new BitmapImage(new Uri("/Resources/photo_2025-03-01_02-51-01.jpg", UriKind.Relative));
                PetTb.Text = App.thisUser.Role.Title + " " + App.db.Pet.Where(x => x.Id == 1).First().Moniker;
            }
            else
            {
                LogoImg.Source = new BitmapImage(new Uri("/Resources/photo_2025-03-01_02-51-05.jpg", UriKind.Relative));
                PetTb.Text = App.thisUser.Role.Title + " " + App.db.Pet.Where(x => x.Id == 2).First().Moniker;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            App.thisUser = new User();
            Navigations.mainPage(new AuthorizationPage());
            Navigations.leftPage(new NonePage());
            Navigations.topPage(new NonePage());
            Navigations.valuePage(new NonePage());
        }
    }
}
