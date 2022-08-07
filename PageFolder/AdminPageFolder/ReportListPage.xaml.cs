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
using MetroApp.ClassFolder;
using MetroApp.DataFolder;
using MetroApp.WindowFolder.AdminWindowFolder;

namespace MetroApp.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ReportListPage.xaml
    /// </summary>
    public partial class ReportListPage : Page
    {
        public ReportListPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            ReportDg.ItemsSource = DBEntities.GetContext().Report.OrderByDescending
                (r => r.DateOfReport).ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReportDg.ItemsSource = DBEntities.GetContext().Report.Where(r => r.Staff.Surname.StartsWith
            (SearchTb.Text) || r.Staff.NameStaff.StartsWith(SearchTb.Text) ||
            r.Staff.Patronymic.StartsWith(SearchTb.Text)).ToList();
        }

        private void ReportDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ReportDg.SelectedItem is Report report)
            {
                var window = Application.Current.Windows.OfType<AdminMainWindow>().SingleOrDefault(w => w.IsActive);
                new ReportWindow(report.IdReport).Show();
                window.Close();
            }
        }
    }
}
