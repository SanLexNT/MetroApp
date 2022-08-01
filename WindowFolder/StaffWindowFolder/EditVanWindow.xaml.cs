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
    /// Логика взаимодействия для EditVanWindow.xaml
    /// </summary>
    public partial class EditVanWindow : Window
    {
        int idVanTrain;
        public EditVanWindow(int idVan)
        {
            InitializeComponent();
            LoadComboBox();
            DataContext = DBEntities.GetContext().VanTrain.First(v => v.IdVanTrain == idVan);
            idVanTrain = idVan;
        }

        private void LoadComboBox()
        {
            StatusCb.ItemsSource = DBEntities.GetContext().Status.ToList();
            DepotCb.ItemsSource = DBEntities.GetContext().Depot.ToList();
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SerialNumberTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите серийный номер вагона", SerialNumberTb);

            else if (DateOfReleaseDp.SelectedDate == null)
                MessageBoxClass.ErrorMessageBox("Выберите дату выпуска", DateOfReleaseDp);
            else if (DateOfReleaseDp.SelectedDate > DateTime.Now)
                MessageBoxClass.ErrorMessageBox("Выбранная дата еще не наступила", DateOfReleaseDp);
            else if (StatusCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите статус вагона", StatusCb);
            else if (DepotCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите тип вагона", DepotCb);
            else
            {
                var van = DBEntities.GetContext().VanTrain.FirstOrDefault
                    (v => v.SerialNumber == SerialNumberTb.Text && v.IdVanTrain != v.IdVanTrain);
                if (van != null)
                    MessageBoxClass.ErrorMessageBox("Вагон с таким серийным номером уже есть", SerialNumberTb);
                else
                {
                    UpdateData();
                    MessageBoxClass.InfoMessageBox("Данные обновлены");
                    new StaffMainWindow().Show();
                    Close();
                }

            }
        }
        private void UpdateData()
        {
            try
            {
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
