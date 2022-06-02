using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace View.Converters
{
    class StringConverter : IValueConverter
    {
        public object White { get; set; }
        public object Black { get; set; }
        public object Empty { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == Stone.BLACK) return "Black won!!";
            if (value == Stone.WHITE) return "White won!!";
           
            else return "its a tie!!";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
