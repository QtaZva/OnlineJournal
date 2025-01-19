using System.Windows;
using OnlineJournal.Classes;

namespace OnlineJournal.Windows
{
    public partial class ChangeAccessLevelWindow : Window
    {
        ApplicationContext db;
        private int UserId;
        public ChangeAccessLevelWindow(int userId)
        {
            InitializeComponent();
            db = new ApplicationContext();
            UserId = userId;
            AccessLevelComboBox.ItemsSource = db.AccessLevels.ToList();
        }

        private void SetAccessLevelClick(object sender, RoutedEventArgs e)
        {
            var user = db.Users.Where(u => u.Id == UserId).FirstOrDefault();
            if (user != null)
            {
                user.AccessId = AccessLevelComboBox.SelectedIndex + 1;
                db.Users.Update(user);
                db.SaveChanges();
                MessageBox.Show("Уровень доступа успешно изменен!");
                this.Close();
            }
        }
    }
}
