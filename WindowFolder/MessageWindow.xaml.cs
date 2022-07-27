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

namespace MetroApp.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public enum MessageType
        {
            Error,
            Information,
            Question
        }
        MessageType type;
        public MessageWindow(string message, MessageType messageType)
        {
            InitializeComponent();
            lblTextMessage.Content = message;
            type = messageType;
            InitializeMessageBox();
        }
        public void InitializeMessageBox()
        {
            switch (type)
            {
                case MessageType.Error:
                    txtTitle.Text = "Ошибка";
                    CardHeader.Background = new SolidColorBrush(Colors.Red);
                    btnOk.Visibility = Visibility.Visible;
                    spOkCancel.Visibility = Visibility.Hidden;
                    break;
                case MessageType.Information:
                    txtTitle.Text = "Информация";
                    CardHeader.Background = new SolidColorBrush(Colors.Green);
                    btnOk.Visibility = Visibility.Visible;
                    spOkCancel.Visibility = Visibility.Hidden;
                    break;
                case MessageType.Question:
                    txtTitle.Text = "Вопрос";
                    btnOk.Visibility = Visibility.Hidden;
                    spOkCancel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IsAccepted = false;
            Close();
        }

        //Обработка кнопки ОК для ошибки и информации
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Обработка кнопки ОК для вопроса
        private void btnOk1_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IsAccepted = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            VariableClass.IsAccepted = false;
            Close();
        }
    }
}
