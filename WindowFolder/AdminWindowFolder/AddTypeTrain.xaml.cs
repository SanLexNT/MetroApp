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

namespace MetroApp.WindowFolder.AdminWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddTypeTrain.xaml
    /// </summary>
    public partial class AddTypeTrain : Window
    {
        public AddTypeTrain()
        {
            InitializeComponent();
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

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NumberTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите номер типа", NumberTb);
            else if (!NumberTb.Text.All(char.IsDigit))
                MessageBoxClass.ErrorMessageBox("Номер типа должен состоять из цифр", NumberTb);
            else if (NumberTb.Text.Length != 5)
                MessageBoxClass.ErrorMessageBox("Номер типа должен состоять из 5 цифр", NumberTb);
            else if (string.IsNullOrWhiteSpace(NameTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите название типа", NameTb);
            else
            {
                string numberType = string.Format
                       ("{0}-{1}", NumberTb.Text.Substring(0, 2), NumberTb.Text.Substring(2));
                var type = DBEntities.GetContext().TypeTrain.FirstOrDefault
                    (t => t.NumberTypeTrain == numberType);
                if (type != null)
                    MessageBoxClass.ErrorMessageBox("Номер типа уже существует", NumberTb);
                else 
                {
                    AddType(numberType);
                    MessageBoxClass.InfoMessageBox("Тип добавлен");
                    CloseWindow();
                }
            }
        }
        private void AddType(string numberType)
        {
            try
            {
                var newType = new TypeTrain()
                {
                    NumberTypeTrain = numberType,
                    NameTypeTrain = NameTb.Text
                };
                DBEntities.GetContext().TypeTrain.Add(newType);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }
    }
}
