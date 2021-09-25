using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MemoryTrainer.Misc
{
    /// <summary>
    /// Converts a boolean to a passed or failed image
    /// </summary>
    public class BooleanToImageConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = value as Nullable<bool>;
            if (boolean.HasValue)
            {
                // If the nullable type has a value prepare the image
                string uriString;
                if (boolean.Value)
                {
                    uriString = ImageConverterHelper.Passed;
                }
                else
                {
                    uriString = ImageConverterHelper.Failed;
                }

                var helper = new ImageConverterHelper();
                return helper.Decode(uriString);
            }
            else
            {
                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
