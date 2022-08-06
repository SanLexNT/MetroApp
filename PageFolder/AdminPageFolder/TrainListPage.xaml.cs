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
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace MetroApp.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для TrainListPage.xaml
    /// </summary>
    public partial class TrainListPage : System.Windows.Controls.Page
    {
        public TrainListPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            TrainDg.ItemsSource = DBEntities.GetContext().VanTrain.ToList();
        }

        private void AddTypeTrain_Click(object sender, RoutedEventArgs e)
        {
            var window = System.Windows.Application.Current.Windows.OfType<AdminMainWindow>().SingleOrDefault(w => w.IsActive);
            new AddTypeTrain().Show();
            window.Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TrainDg.ItemsSource = DBEntities.GetContext().VanTrain.Where
                (v => v.TypeTrain.NumberTypeTrain.StartsWith(SearchTb.Text) ||
                v.Depot.NameDepot.StartsWith(SearchTb.Text)).ToList();
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
                    TrainDg.SelectAllCells();
                    TrainDg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, TrainDg);
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
    }
}
