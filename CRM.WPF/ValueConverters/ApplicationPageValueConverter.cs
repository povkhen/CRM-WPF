﻿using CRM.CORE;
using System;
using System.Diagnostics;
using System.Globalization;

namespace CRM.WPF
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/>  to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Register:
                    return new RegisterPage();


                case ApplicationPage.Home:
                    return new HomePage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
