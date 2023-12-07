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

namespace FitnessAcademy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Academy_fitnessEntities context = new Academy_fitnessEntities();

        public MainWindow()
        {
            InitializeComponent();
            RegistrationGrid.ItemsSource = context.CourseRegistration.ToList();
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newRegsitration = new CourseRegistration();
            context.CourseRegistration.Add(newRegsitration);
            var win = new RegistrationCourseWindow(context, newRegsitration);
            win.ShowDialog();
            RegistrationGrid.ItemsSource = context.CourseRegistration.ToList();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var row = RegistrationGrid.SelectedItems as CourseRegistration;
            if (row == null)
            {
                MessageBox.Show("Строка не выбрана");
                return;
            }

            context.CourseRegistration.Remove(row);
            context.SaveChanges();
            RegistrationGrid.ItemsSource = context.CourseRegistration.ToList();

        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button EditButton = sender as Button;
            var currentRegistration = EditButton.DataContext as CourseRegistration;
            var win = new RegistrationCourseWindow(context, currentRegistration);
            win.ShowDialog();
        }
    }
}
