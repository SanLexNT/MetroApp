using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MetroApp.WindowFolder;

namespace MetroApp.ClassFolder
{
    public static class MessageBoxClass
    {
        public static void ErrorMessageBox(string error, params Control[] controls)
        {
            new MessageWindow(error, MessageWindow.MessageType.Error).ShowDialog();
            foreach (var control in controls)
            {
                control.Focus();
            }
        }
        public static void ErrorMessageBox(Exception ex, params Control[] controls)
        {
            new MessageWindow(ex.Message, MessageWindow.MessageType.Error).ShowDialog();
            foreach (var control in controls)
            {
                control.Focus();
            }
        }
        public static void InfoMessageBox(string text)
        {
            new MessageWindow(text, MessageWindow.MessageType.Information).ShowDialog();
        }
        public static bool QuestionMessageBox(string question)
        {
            new MessageWindow(question, MessageWindow.MessageType.Question).ShowDialog();
            return VariableClass.IsAccepted;
        }
        public static void ExitMessageBox()
        {
            if (QuestionMessageBox("Вы действительно хотите выйти?"))
            {
                Application.Current.Shutdown();
            }
        }
    }
}
