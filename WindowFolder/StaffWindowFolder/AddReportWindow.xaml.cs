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
    /// Логика взаимодействия для AddReportWindow.xaml
    /// </summary>
    public partial class AddReportWindow : Window
    {
        public AddReportWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch {}
        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            new StaffMainWindow().Show();
            Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReportTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите текст отчета", ReportTb);
            else
            {
                AddReport();
                MessageBoxClass.InfoMessageBox("Отчет отправлен");
                new StaffMainWindow().Show();
                Close();
            }
        }
        private void AddReport()
        {
            var newReport = new Report()
            {
                TextReport = ReportTb.Text,
                DateOfReport = DateTime.Now,
                IdStaff = VariableClass.IdStaff
            };
            DBEntities.GetContext().Report.Add(newReport);
            DBEntities.GetContext().SaveChanges();
        }
    }
}
