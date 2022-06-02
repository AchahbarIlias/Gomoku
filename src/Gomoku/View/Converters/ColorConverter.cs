using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace View.Converters
{
    class ColorConverter : IValueConverter

    {
        public object Normal { get; set; }
        public object Captured { get; set; }
        public object Winning { get; set; }
        


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == "Red")
            {
                 return Captured;
               
            }


            if (value == "LightBlue")
            {
                return Winning;

            }

            else
            {
                return Normal;
            }
            }

        


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
