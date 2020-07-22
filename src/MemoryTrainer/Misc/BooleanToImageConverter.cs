using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MemoryTrainer.Misc
{
    public class BooleanToImageConverter : IValueConverter
    {
        private readonly string path = @"/Misc/Images/";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = value as Nullable<bool>;
            if (boolean.HasValue)
            {
                string uriString;
                if (boolean.Value)
                {
                    uriString = path + "OK.png";
                }
                else
                {
                    uriString = path + "NotOK.png";
                }

                var uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
                var image = Application.GetResourceStream(uri);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = image.Stream;
                bitmapImage.EndInit();

                return bitmapImage;
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
