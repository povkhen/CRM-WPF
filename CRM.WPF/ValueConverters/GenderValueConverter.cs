using CRM.CORE;
using System;
using System.Diagnostics;
using System.Globalization;

namespace CRM.WPF
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/>  to an actual view/page
    /// </summary>
    public class GenderValueConverter : BaseValueConverter<GenderValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            return ((string)parameter == (string)value);
        }
        

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value? parameter : null;
        }
    }
}
