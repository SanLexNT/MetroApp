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
using MetroApp.ClassFolder;

namespace MetroApp.WindowFolder.AdminWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageFolder.AdminPageFolder.DepotListPage();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (InvalidOperationException)
            {}
        }

        private void DepotBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFolder.AdminPageFolder.DepotListPage();
        }

        private void TrainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFolder.AdminPageFolder.TrainListPage();
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }
    }
}
