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

namespace MetroApp.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        Staff staff;
        public StaffPage(int idStaff)
        {
            InitializeComponent();
            staff = DBEntities.GetContext().Staff.FirstOrDefault(s => s.IdStaff == idStaff);
            DataContext = staff;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBoxClass.QuestionMessageBox("Хотите удалить сотрудника?"))
            {
                
                RemoveData();
                MessageBoxClass.InfoMessageBox("Сотрудник удален");
                NavigationService.GoBack();
            }
        }
        private void RemoveData()
        {
            var user = staff.User;
            var reports = DBEntities.GetContext().Report.Where(r => r.IdStaff == staff.IdStaff).ToList();
            foreach (var report in reports)
            {
                DBEntities.GetContext().Report.Remove(report);
            }
            DBEntities.GetContext().User.Remove(user);
            DBEntities.GetContext().Staff.Remove(staff);
            DBEntities.GetContext().SaveChanges();
        }
    }
}
