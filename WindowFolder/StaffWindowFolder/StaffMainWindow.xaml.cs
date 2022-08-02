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
using MetroApp.DataFolder;

namespace MetroApp.WindowFolder.StaffWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffMainWindow.xaml
    /// </summary>
    public partial class StaffMainWindow : Window
    {
        public StaffMainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageFolder.StaffPageFolder.TrainListPage();
        }

        private void TrainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFolder.StaffPageFolder.TrainListPage();
        }

        private void MyReportBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFolder.StaffPageFolder.ReportListPage();
        }

        private void ProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageFolder.StaffPageFolder.ProfilPage();
        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {}
        }
    }
}
