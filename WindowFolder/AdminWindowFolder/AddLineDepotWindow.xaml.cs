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
    /// Логика взаимодействия для AddLineDepotWindow.xaml
    /// </summary>
    public partial class AddLineDepotWindow : Window
    {
        MetroLine line = new MetroLine();
        public AddLineDepotWindow()
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


        private void DepotBtn_Click(object sender, RoutedEventArgs e)
        {
            DepotGrid.Visibility = Visibility.Visible;
            LineGrid.Visibility = Visibility.Hidden;
        }

        private void LineBtn_Click(object sender, RoutedEventArgs e)
        {
            DepotGrid.Visibility = Visibility.Hidden;
            LineGrid.Visibility = Visibility.Visible;
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            DepotCb.ItemsSource = DBEntities.GetContext().Depot.ToList();
        }

        private void AddDepotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameDepotTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите название депо", NameDepotTb);
            else
            {
                var depot = DBEntities.GetContext().Depot.FirstOrDefault
                    (d => d.NameDepot == NameDepotTb.Text);
                if (depot != null)
                    MessageBoxClass.ErrorMessageBox("Депо с таким названием уже существует", NameDepotTb);
                else
                {
                    AddDepot();
                    MessageBoxClass.InfoMessageBox("Депо добавлено");
                    new AdminMainWindow().Show();
                    Close();
                }
            }
        }
        private void AddDepot()
        {
            var newDepot = new Depot()
            {
                NameDepot = NameDepotTb.Text,
            };
            DBEntities.GetContext().Depot.Add(newDepot);
            DBEntities.GetContext().SaveChanges();
        }

        private void AddLineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameLineTb.Text))
                MessageBoxClass.ErrorMessageBox("Введите название линии", NameLineTb);
            else if (DepotCb.SelectedItem == null)
                MessageBoxClass.ErrorMessageBox("Выберите обслуживаемое депо", DepotCb);
            else
            {
                var line = DBEntities.GetContext().MetroLine.FirstOrDefault
                    (d => d.NameMetroLine == NameLineTb.Text);
                if (line != null)
                    MessageBoxClass.ErrorMessageBox("Линия с таким названием уже существует", NameLineTb);
                else
                {
                    AddLine();
                    AddConnectionLineDepot();
                    MessageBoxClass.InfoMessageBox("Линия добавлена");
                    new AdminMainWindow().Show();
                    Close();
                }
            }
        }
        private void AddLine()
        {
            try
            {
                var newLine = new MetroLine()
                {
                    NameMetroLine = NameLineTb.Text,
                };
                DBEntities.GetContext().MetroLine.Add(newLine);
                DBEntities.GetContext().SaveChanges();
                line = newLine;
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }
        private void AddConnectionLineDepot()
        {
            try
            {
                var lineDepot = new MetroLineDepot()
                {
                    IdMetroLine = line.IdMetroLine,
                    IdDepot = int.Parse(DepotCb.SelectedValue.ToString())
                };
                DBEntities.GetContext().MetroLineDepot.Add(lineDepot);
                DBEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
            
        }
    }
}
