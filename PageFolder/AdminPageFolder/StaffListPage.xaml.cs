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
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using MetroApp.WindowFolder.AdminWindowFolder;

namespace MetroApp.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffListPage.xaml
    /// </summary>
    public partial class StaffListPage : System.Windows.Controls.Page
    {
        public StaffListPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            StaffDg.ItemsSource = DBEntities.GetContext().Staff.ToList();
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Current.Windows.OfType<AdminMainWindow>().SingleOrDefault(w => w.IsActive);
            new AddStaffWindow().Show();
            window.Close();
        }

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            ImportData();
            MessageBoxClass.InfoMessageBox("Данные импортированы в Excel");
        }
        private void ImportData()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = null;
                Workbook wb = null;
                Worksheet ws = null;
                var process = Process.GetProcessesByName("EXCEL");

                SaveFileDialog openDlg = new SaveFileDialog();
                openDlg.FileName = Title;
                openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
                openDlg.FilterIndex = 2;
                openDlg.RestoreDirectory = true;
                string path = openDlg.FileName;

                if (openDlg.ShowDialog() == true)
                {
                    app = new Microsoft.Office.Interop.Excel.Application();
                    app.Visible = true;
                    app.DisplayAlerts = false;
                    wb = app.Workbooks.Add();
                    ws = wb.ActiveSheet;
                    StaffDg.SelectAllCells();
                    StaffDg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, StaffDg);
                    ws.Paste();
                    ws.Range["A1", "E1"].Font.Bold = true;
                    int number1 = ws.UsedRange.Rows.Count;
                    Range myRange = ws.Range["A1", "E" + number1];
                    myRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    myRange.WrapText = false;
                    ws.Columns.EntireColumn.AutoFit();
                    wb.SaveAs(path);

                }
            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaffDg.ItemsSource = DBEntities.GetContext().Staff.Where
                (s => s.Surname.StartsWith(SearchTb.Text) ||
                s.NameStaff.StartsWith(SearchTb.Text) ||
                s.Depot.NameDepot.StartsWith(SearchTb.Text)).ToList();
        }

        private void StaffDg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StaffDg.SelectedItem is Staff staff)
                NavigationService.Navigate(new StaffPage(staff.IdStaff));
            LoadData();
        }
    }
}
