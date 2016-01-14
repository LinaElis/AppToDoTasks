using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppToDoTasks.Helpers
{
    public class DateTimeConverter : IValueConverter
    {
        public DateTimeConverter()
        {}

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTime) value;
            return time.ToString("M/d/yyyy h:mm tt");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
