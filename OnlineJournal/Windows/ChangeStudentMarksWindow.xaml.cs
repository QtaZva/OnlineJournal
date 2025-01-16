using Microsoft.EntityFrameworkCore;
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

namespace OnlineJournal.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeStudentMarksWindow.xaml
    /// </summary>
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
        }
    }
}
