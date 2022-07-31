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
    /// Логика взаимодействия для AddVanWindow.xaml
    /// </summary>
    public partial class AddVanWindow : Window
    {
        public AddVanWindow()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            StatusCb.ItemsSource = DBEntities.GetContext().Status.ToList();
            TypeTrainCb.ItemsSource = DBEntities.GetContext().TypeTrain.ToList();
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

        private void MinimizedBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxClass.ExitMessageBox();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SerialNumberTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите серийный номер вагона", SerialNumberTb);
            
            else if (DateOfReleaseDp.SelectedDate == null)
                MessageBoxClass.ErrorMessageBox("Выберите дату выпуска", DateOfReleaseDp);
            else if (DateOfReleaseDp.SelectedDate > DateTime.Now)
                MessageBoxClass.ErrorMessageBox("Выбранная дата еще не наступила", DateOfReleaseDp);
            else if (StatusCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите статус вагона", StatusCb);
            else if(TypeTrainCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите тип вагона", TypeTrainCb);
            else
            {
                var van = DBEntities.GetContext().VanTrain.FirstOrDefault
                    (v=>v.SerialNumber == SerialNumberTb.Text);
                if (van != null)
                    MessageBoxClass.ErrorMessageBox("Вагон с таким серийным номером уже есть", SerialNumberTb);
                else
                {
                    AddVan();
                    MessageBoxClass.InfoMessageBox("Вагон добавлен в систему");
                    new StaffMainWindow().Show();
                    Close();
                }
                
            }
        }
        private void AddVan()
        {
            try
            {
                var newVan = new VanTrain()
                {
                    SerialNumber = SerialNumberTb.Text,
                    IdDepot = VariableClass.IdDepot,
                    YearOfRelease = (DateTime)DateOfReleaseDp.SelectedDate,
                    IdStatus = int.Parse(StatusCb.SelectedValue.ToString()),
                    IdTypeTrain = int.Parse(TypeTrainCb.SelectedValue.ToString())
                };
                DBEntities.GetContext().VanTrain.Add(newVan);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new StaffMainWindow().Show();
            Close();
        }
    }
}
