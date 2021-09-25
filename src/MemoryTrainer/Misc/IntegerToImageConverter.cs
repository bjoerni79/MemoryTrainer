using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MemoryTrainer.Misc
{
    public class IntegerToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int recallState;
            var isInteger = Int32.TryParse(value.ToString(), out recallState);

            if (isInteger)
            {
                string uriString = null;

                if (recallState == 1)
                {
                    uriString = ImageConverterHelper.Passed;
                }

                if (recallState == 2)
                {
                    uriString = ImageConverterHelper.Failed;
                }

                if (uriString != null)
                {
                    var helper = new ImageConverterHelper();
                    return helper.Decode(uriString);
                }

                return null;
            }
            else
            {
                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
