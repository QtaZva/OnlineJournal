using OnlineJournal.Classes;
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
using System.Windows.Shapes;

namespace OnlineJournal
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ApplicationContext db;
        public Login()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e)
        {
            var user = db.Users.FirstOrDefault(u => u.Password == UserPassword.Password && u.Login == UserLogin.Text);

            if (user != null)
            {
                var accessLevel = db.AccessLevels.FirstOrDefault(a => a.Id == user.AccessId);

                if (accessLevel != null)
                {
                    MainPage mainPage = new MainPage(user);
                    mainPage.Show();
                    this.Close();
                }
                return;
            }

            MessageBox.Show("Логин или пароль введены неверно");

        }
    }
}
