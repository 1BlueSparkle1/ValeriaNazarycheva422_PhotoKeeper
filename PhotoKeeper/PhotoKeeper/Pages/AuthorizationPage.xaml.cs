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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<User> users = App.db.User.ToList();
            User thisUser = new User();
            foreach (User user in users)
            {
                if (user.Login == LoginTb.Text)
                {
                    if (user.Password == PasswordPb.Password)
                    {
                        thisUser = user;
                    }
                }
            }
            if (thisUser.Id == 0)
            {
                MessageBox.Show("Пользователь не найден!");
            }
            else
            {
                MessageBox.Show("Вы вошли!");
                Navigations.mainPage(new NonePage());
            }

        }
    }
}
