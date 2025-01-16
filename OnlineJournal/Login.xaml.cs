using OnlineJournal.Classes;
using OnlineJournal.Models;
using System.Windows;

namespace OnlineJournal
{
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

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            var loginCheck = db.Users.Where(u => u.Login == RegUserLogin.Text).FirstOrDefault();
            if (loginCheck != null)
            {
                MessageBox.Show("Данный логин уже занят!");
                return;
            }
            User newUser = new User()
            {
                Login = RegUserLogin.Text,
                Password = RegUserPassword.Password,
                Name = RegUserName.Text,
                Surname = RegUserSurname.Text,
                Patronymic = RegUserPatronymic.Text,
                AccessId = 1
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались!");
        }
    }
}
