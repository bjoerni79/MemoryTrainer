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
        private readonly string path = @"/Misc/Images/";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = value as Nullable<bool>;
            if (boolean.HasValue)
            {
                // If the nullable type has a value prepare the image
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
                var imageStream = Application.GetResourceStream(uri);

                // https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapdecoder?view=netcore-3.1
                BitmapDecoder decoder = BitmapDecoder.Create(imageStream.Stream, BitmapCreateOptions.None, BitmapCacheOption.Default);

                imageStream.Stream.Close();
                return decoder.Frames[0];
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
