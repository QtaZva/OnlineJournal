using Microsoft.EntityFrameworkCore;
using OnlineJournal.Classes;
using System.Windows;

namespace OnlineJournal.Windows
{
    public partial class ChangeStudentMarksWindow : Window
    {
        ApplicationContext db;
        private int StudentId;
        public ChangeStudentMarksWindow(int studentId)
        {
            InitializeComponent();
            db = new ApplicationContext();
            var marks = db.Marks.Where(m => m.UserId == studentId).Include(m => m.Subject).ToList();
            StudentMarks.ItemsSource = marks;
            StudentId = studentId;
        }

        private void SaveChangesClick(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Изменения сохранены!");
        }

        private void AddMarkClick(object sender, RoutedEventArgs e)
        {
            AddMarkWindow addMarkWindow = new(StudentId);
            addMarkWindow.ShowDialog();
            var marks = db.Marks.Where(m => m.UserId == StudentId).Include(m => m.Subject).ToList();
            StudentMarks.ItemsSource = marks;
        }
    }
}
