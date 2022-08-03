using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetroApp.DataFolder
{
    public partial class VanTrain
    {
        public SolidColorBrush StatusColor
        {
            get
            {
                if (Status.NameStatus == "Списан" || Status.NameStatus == "Порезан")
                    return Brushes.Red;
                else
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2196F3"));
            }
        }
    }
}
