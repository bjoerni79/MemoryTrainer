using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MemoryTrainer.Misc
{
    public class NumberCompareStateConverter : IValueConverter
    {
        public NumberCompareStateConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int state;
            var isInteger = Int32.TryParse(value.ToString(), out state);

            if (isInteger)
            {
                var helper = new ImageConverterHelper();
                string uriString;

                switch (state)
                {
                    // Passed
                    case 1:
                        uriString = ImageConverterHelper.Passed;
                        break;
                    // Failed
                    case 2:
                        uriString = ImageConverterHelper.Failed;
                        break;
                    // Default
                    default:
                        uriString = null;
                        break;
                }

                return helper.Decode(uriString);
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
