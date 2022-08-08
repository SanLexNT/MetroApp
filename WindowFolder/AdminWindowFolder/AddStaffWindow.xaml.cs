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
using Microsoft.Win32;

namespace MetroApp.WindowFolder.AdminWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        Staff staff = new Staff();
        User user = new User();
        public AddStaffWindow()
        {
            InitializeComponent();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            DepotCb.ItemsSource = DBEntities.GetContext().Depot.ToList();
            RoleCb.ItemsSource = DBEntities.GetContext().Role.ToList();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (InvalidOperationException)
            { }
        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
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
            if (op.ShowDialog() == true)
            {
                VariableClass.SelectedFileName = op.FileName;
                staff.Photo = ClassImage.ConvertImageToByteArray(VariableClass.SelectedFileName);
                PhotoIm.Source = ClassImage.ConvertByteArrayToImage(staff.Photo);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите фамилию", SurnameTb);
            else if (string.IsNullOrWhiteSpace(NameTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите имя", NameTb);
            else if (DatePfBirthDp.SelectedDate == null)
                MessageBoxClass.ErrorMessageBox("Выберите дату рождения", DatePfBirthDp);
            else if (DateTime.Now.Year - DatePfBirthDp.SelectedDate.Value.Year < 18)
                MessageBoxClass.ErrorMessageBox("Сотрудник должен быть старше 18 лет", DatePfBirthDp);
            else if (DepotCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите депо", DepotCb);
            else if (RoleCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите должность", RoleCb);
            else if (string.IsNullOrWhiteSpace(LoginTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите логин", LoginTb);
            else if (string.IsNullOrWhiteSpace(PasswordTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите пароль", PasswordTb);
            else
            {
                var user = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == LoginTb.Text);
                if (user != null)
                    MessageBoxClass.ErrorMessageBox("Логин уже занят", LoginTb);
                else
                {
                    AddUser();
                    AddStaff();
                    MessageBoxClass.InfoMessageBox("Сотрудник добавлен!");
                    CloseWindow();
                }
            }
        }
        private void AddUser()
        {
            try
            {
                var newUser = new User()
                {
                    Login = LoginTb.Text,
                    Password = PasswordTb.Text,
                    IdRole = int.Parse(RoleCb.SelectedValue.ToString())
                };
                DBEntities.GetContext().User.Add(newUser);
                DBEntities.GetContext().SaveChanges();
                user = newUser;
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }

        }
        private void AddStaff()
        {
            try
            {
                staff.Surname = SurnameTb.Text;
                staff.NameStaff = NameTb.Text;
                staff.Patronymic = PatronymicTb.Text;
                staff.DateOfBirth = (DateTime)DatePfBirthDp.SelectedDate;
                staff.IdDepot = int.Parse(DepotCb.SelectedValue.ToString());
                staff.IdUser = user.IdUser;

                DBEntities.GetContext().Staff.Add(staff);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
        private void CloseWindow()
        {
            new AdminMainWindow().Show();
            Close();
        }
    }
}
