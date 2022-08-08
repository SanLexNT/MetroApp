using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetroApp.ClassFolder;
using MetroApp.DataFolder;

namespace MetroApp.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        Staff staff;
        public ProfilPage()
        {
            InitializeComponent();
            staff = DBEntities.GetContext().Staff.FirstOrDefault(s => s.IdStaff == VariableClass.IdStaff);
            DateOfBirthDp.SelectedDate = staff.DateOfBirth;
            DataContext = staff;
        }

        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }
        private void AddPhoto()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "";
            op.Filter = "All suported graphics |*.jpg;*.jpeg;*.png";
            if(op.ShowDialog() == DialogResult.OK)
            {
                VariableClass.SelectedFileName = op.FileName;
                staff.Photo = ClassImage.ConvertImageToByteArray(VariableClass.SelectedFileName);
                PhotoIm.Source = ClassImage.ConvertByteArrayToImage(staff.Photo);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(VariableClass.SelectedFileName == "")
            {
                DBEntities.GetContext().SaveChanges();
            }
            else
            {
                EditStaff();
            }
            MessageBoxClass.InfoMessageBox("Данные обновлены");
        }
        private void EditStaff()
        {
            staff.User.Login = LoginTb.Text;
            staff.User.Password = PasswordTb.Text;
            staff.Surname = SurnameTb.Text;
            staff.NameStaff = NameTb.Text;
            staff.Patronymic = PatronymicTb.Text;
            staff.DateOfBirth = (DateTime)DateOfBirthDp.SelectedDate;
            DBEntities.GetContext().SaveChanges();
        }

    }
}
