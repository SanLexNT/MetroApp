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
using MetroApp.WindowFolder.StaffWindowFolder;

namespace MetroApp.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для TrainListPage.xaml
    /// </summary>
    public partial class TrainListPage : Page
    {
        int currentPage = 1, countInPage = 15, maxPage;
        
        public TrainListPage()
        {
            InitializeComponent();
            RefreshData();
        }
        private void RefreshData()
        {
            var trains = DBEntities.GetContext().VanTrain.Where
                (v => v.IdDepot == VariableClass.IdDepot).ToList();
            
            maxPage = (int)Math.Ceiling(trains.Count * 1.0 / countInPage);
            trains = trains.Skip((currentPage - 1) * countInPage).Take(countInPage).ToList();
            TrainDg.ItemsSource = trains;
            if (trains.Count <= 0)
                lblNumberPage.Content = $"0/0";
            else
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
            if (currentPage == 1)
                ToFirstBtn.IsEnabled = PreviousBtn.IsEnabled = false;
            else if (currentPage == maxPage)
                ToLastBtn.IsEnabled = NextBtn.IsEnabled = false;
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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TrainDg.ItemsSource = DBEntities.GetContext().VanTrain.Where
                (v => v.SerialNumber.StartsWith(SearchTb.Text) && v.IdDepot == VariableClass.IdDepot).ToList();
        }

        private void TrainDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = Application.Current.Windows.OfType<StaffMainWindow>().SingleOrDefault(w => w.IsActive);
            VanTrain van = TrainDg.SelectedItem as VanTrain;
            if(van != null)
            {
                new EditVanWindow(van.IdVanTrain).Show();
                window.Close();
            }
        }

        private void AddVanBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<StaffMainWindow>().SingleOrDefault(w => w.IsActive);
            new AddVanWindow().Show();
            window.Close();
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
