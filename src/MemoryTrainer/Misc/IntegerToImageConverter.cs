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
        private readonly string path = @"/Misc/Images/";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int recallState;
            var isInteger = Int32.TryParse(value.ToString(), out recallState);

            if (isInteger)
            {
                string uriString = null;

                if (recallState == 1)
                {
                    uriString = path + "OK.png";
                }

                if (recallState == 2)
                {
                    uriString = path + "NotOK.png";
                }

                if (uriString != null)
                {
                    var uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
                    var imageStream = Application.GetResourceStream(uri);

                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapdecoder?view=netcore-3.1
                    BitmapDecoder decoder = BitmapDecoder.Create(imageStream.Stream, BitmapCreateOptions.None, BitmapCacheOption.Default);

                    imageStream.Stream.Close();
                    return decoder.Frames[0];
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
