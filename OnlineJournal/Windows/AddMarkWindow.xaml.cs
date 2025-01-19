using OnlineJournal.Classes;
using OnlineJournal.Models;
using System.Linq;
using System.Windows;

namespace OnlineJournal.Windows
{
    public partial class AddMarkWindow : Window
    {
        ApplicationContext db;
        private int StudentId;
        public AddMarkWindow(int studentId)
        {
            InitializeComponent();
            db = new ApplicationContext();
            SubjectsComboBox.ItemsSource = db.Subjects.ToList();
            StudentId = studentId;
        }

        private void ButtonMarkClick(object sender, RoutedEventArgs e)
        {
            if (MarkDate.SelectedDate != null)
            {
                Marks newMark = new Marks()
                {
                    UserId = StudentId,
                    SubjectId = SubjectsComboBox.SelectedIndex + 1,
                    date = MarkDate.SelectedDate.Value.Date.ToString(),
                    Mark = MarkComboBox.SelectedIndex + 2
                };
                db.Marks.Add(newMark);
                db.SaveChanges();
                MessageBox.Show("Оценка поставленна");
                this.Close();
            }
            else 
            {
                MessageBox.Show("Выберите дату");
            }
        }
    }
}
