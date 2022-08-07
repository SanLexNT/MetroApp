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
using MetroApp.DataFolder;
using MetroApp.ClassFolder;
using MetroApp.WindowFolder.StaffWindowFolder;

namespace MetroApp.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ReportListPage.xaml
    /// </summary>
    public partial class ReportListPage : Page
    {
        int currentPage = 1, countInPage = 15, maxPage;
        public ReportListPage()
        {
            InitializeComponent();
            RefreshData();
        }
        private void RefreshData()
        {
            var reports = DBEntities.GetContext().Report.Where
                (r => r.IdStaff == VariableClass.IdStaff).ToList();
            maxPage = (int)Math.Ceiling(reports.Count * 1.0 / countInPage);
            reports = reports.Skip((currentPage - 1) * countInPage).Take(countInPage).ToList();
            ReportDg.ItemsSource = reports;

            lblNumberPage.Content = $"{currentPage}/{maxPage}";
            ManageButton();
        }
        private void ManageButton()
        {
            if (currentPage <= 1 && maxPage <= 1)
            {
                ToFirstBtn.IsEnabled = PreviousBtn.IsEnabled = false;
                ToLastBtn.IsEnabled = NextBtn.IsEnabled = false;
            }
            else if (currentPage == 1)
                ToFirstBtn.IsEnabled = PreviousBtn.IsEnabled = false;
            else if (currentPage == maxPage)
                ToLastBtn.IsEnabled = NextBtn.IsEnabled = false;
        }

        private void AddReportBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<StaffMainWindow>().SingleOrDefault(w => w.IsActive);
            new AddReportWindow().Show();
            window.Close();
        }

        private void ToFirstBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            RefreshData();
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            RefreshData();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            RefreshData();
        }

        private void ToLastBtn_Click(object sender, RoutedEventArgs e)
        {
            currentPage = maxPage;
            RefreshData();
        }
    }
}
