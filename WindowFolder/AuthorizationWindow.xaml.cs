using System;
using System.Collections.Generic;
using System.IO;
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

namespace MetroApp.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            InitializeLogin();
        }
        private void InitializeLogin()
        {
            if (File.Exists(VariableClass.PATH))
            {
                using (StreamReader sr = new StreamReader(VariableClass.PATH))
                {
                    LoginTb.Text = sr.ReadLine();
                }
                RememberLoginChb.IsChecked = true;
            }
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            { }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void VisiblePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordTb.Visibility = Visibility.Visible;
            HidPasswordBtn.Visibility = Visibility.Visible;
            PasswordPb.Visibility = Visibility.Hidden;
            VisiblePasswordBtn.Visibility = Visibility.Hidden;
            PasswordTb.Text = PasswordPb.Password;
        }

        private void HidPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordTb.Visibility = Visibility.Hidden;
            HidPasswordBtn.Visibility = Visibility.Hidden;
            PasswordPb.Visibility = Visibility.Visible;
            VisiblePasswordBtn.Visibility = Visibility.Visible;
            PasswordPb.Password = PasswordTb.Text;
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
                MessageBoxClass.ErrorMessageBox("Вы не ввели логин!", LoginTb);
            else if (string.IsNullOrWhiteSpace(PasswordPb.Password) &&
                    string.IsNullOrWhiteSpace(PasswordTb.Text))
                MessageBoxClass.ErrorMessageBox("Вы не ввели пароль", PasswordPb, PasswordTb);
            else
                Authorize();

        }
        private void Authorize()
        {
            try
            {
                var user = DBEntities.GetContext().User.FirstOrDefault(u => u.Login == LoginTb.Text);
                if (user == null)
                    MessageBoxClass.ErrorMessageBox("Пользователя с таким логином не существует!", LoginTb);
                else if (user.Password != PasswordTb.Text && user.Password != PasswordPb.Password)
                    MessageBoxClass.ErrorMessageBox("Неверный пароль", PasswordTb, PasswordPb);
                else
                {
                    if (RememberLoginChb.IsChecked == true)
                        SaveLogin(user.Login);
                    else
                        DeleteFile();
                    switch (user.IdRole)
                    {
                        case 1:
                            new AdminWindowFolder.AdminMainWindow().Show();
                            Close();
                            break;
                        case 2:
                            var staff = DBEntities.GetContext().Staff.FirstOrDefault(s => s.IdUser == user.IdUser);
                            if (staff == null)
                                MessageBoxClass.ErrorMessageBox("Сотрудник не найден!");
                            else
                            {
                                VariableClass.IdDepot = staff.IdDepot;
                                VariableClass.IdStaff = staff.IdStaff;
                                new StaffWindowFolder.StaffMainWindow().Show();
                                Close();
                            }
                            break;
                        default:
                            MessageBoxClass.ErrorMessageBox("Неизвестный пользователь");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }
        private void SaveLogin(string login)
        {
            using (StreamWriter sw = new StreamWriter(VariableClass.PATH, append: false))
            {
                sw.WriteLine(login);
            }
        }
        private void DeleteFile()
        {
            if (File.Exists(VariableClass.PATH))
                File.Delete(VariableClass.PATH);
        }

    }
}
