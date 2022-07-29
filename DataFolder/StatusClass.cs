using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetroApp.DataFolder
{
    public partial class Status
    {
        public SolidColorBrush StatusColor
        {
            get
            {
                if (NameStatus == "Списан")
                    return Brushes.LightCyan;
                else if (NameStatus == "Порезан")
                    return Brushes.Red;
                else
                    return Brushes.Transparent;
            }
        }
    }
}
