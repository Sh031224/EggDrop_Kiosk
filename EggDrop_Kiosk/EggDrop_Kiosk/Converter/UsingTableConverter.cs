using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EggDrop_Kiosk.Core.Table.Converter
{
    public class UsingTableConverter : IValueConverter
    {
        public const string COLOR_USING = "#FF7171";
        public const string COLOR_NOT_USING = "#ffffff";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value ? COLOR_USING : COLOR_NOT_USING);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
