using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для DepotListPage.xaml
    /// </summary>
    public partial class DepotListPage : Page
    {
        public DepotListPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DepotDg.ItemsSource = DBEntities.GetContext().MetroLineDepot.ToList();
        }

        private void AddDepot_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.Windows.OfType<AdminMainWindow>().SingleOrDefault(w => w.IsActive);
            new AddLineDepotWindow().Show();
            window.Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepotDg.ItemsSource = DBEntities.GetContext().MetroLineDepot.Where
                (l => l.Depot.NameDepot.StartsWith(SearchTb.Text) ||
                l.MetroLine.NameMetroLine.StartsWith(SearchTb.Text));
        }
    }
}
