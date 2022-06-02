using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters
{
    class StoneConverter : IValueConverter
    {
        public object White { get; set; }
        public object Black { get; set; }
        public object Empty { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == Stone.BLACK) return Black;
            if (value == Stone.WHITE) return White;

            else return Empty;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

