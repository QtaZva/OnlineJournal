using Microsoft.EntityFrameworkCore;
using OnlineJournal.Classes;
using OnlineJournal.Models;
using OnlineJournal.Windows;
using System.Windows;
using System.Windows.Controls;

namespace OnlineJournal
{
    public partial class MainPage : Window
    {
        ApplicationContext db;
        User User;
        public MainPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            WelcomeLabel.Content = $"Добро пожаловать {user.Name}!";
            db = new ApplicationContext();
            switch (user.AccessId)
            {
                case 1:
                    Journal.Visibility = Visibility.Visible;
                    Journal.ItemsSource = db.Marks
                        .Where(m => m.UserId == user.Id)
                        .Include(m => m.Subject)
                        .ToList();
                    break;

                case 2:
                    Journal.Visibility = Visibility.Hidden;
                    StudentsList.ItemsSource = db.Users.Where(u => u.AccessId == 1).ToList();
                    break;

                case 3:
                    Journal.Visibility = Visibility.Hidden;
                    StudentsList.ItemsSource = db.Users.Where(u => u.AccessId == 1).ToList();
                    break;

                default:
                    Journal.Visibility = Visibility.Hidden;
                    break;
            }
            User = user;
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void ChangeAccountDataClick(object sender, RoutedEventArgs e)
        {
            User.Name = NameTextBox.Text;
            User.Surname = SurnameTextBox.Text;
            User.Patronymic = PatronymicTextBox.Text;
            db.Users.Update(User);
            db.SaveChanges();
            WelcomeLabel.Content = $"Добро пожаловать {User.Name}!";
            MessageBox.Show("Данные изменены успешно");
        }

        private void StudentMarksButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is int studentId)
            {
                ChangeStudentMarksWindow changeStudentMarksWindow = new(studentId);
                changeStudentMarksWindow.Show();
            }
        }
    }
}
