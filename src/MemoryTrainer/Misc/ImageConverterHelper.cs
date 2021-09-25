using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MemoryTrainer.Misc
{
    internal class ImageConverterHelper
    {
        private readonly string path = @"/Misc/Images/";

        internal static string Passed = "OK.png";
        internal static string Failed = "NotOK.png";

        internal ImageConverterHelper()
        {

        }

        /// <summary>
        /// Decodes the file 
        /// </summary>
        /// <param name="file">the filename of the image </param>
        /// <param name="isAbsolutePath">true if the path is absolute</param>
        /// <returns>a bitmap</returns>
        internal BitmapFrame Decode(string file, bool isAbsolutePath)
        {
            // If the file is null, return no image. 
            if (file == null)
            {
                return null;
            }

            string uriString;
            if (!isAbsolutePath)
            {
                uriString = path + file;
            }
            else
            {
                uriString = file;
            }

            var uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
            var imageStream = Application.GetResourceStream(uri);

            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapdecoder?view=netcore-3.1
            BitmapDecoder decoder = BitmapDecoder.Create(imageStream.Stream, BitmapCreateOptions.None, BitmapCacheOption.Default);

            imageStream.Stream.Close();
            return decoder.Frames[0];
        }

        /// <summary>
        /// Decodes the file with a relative path
        /// </summary>
        /// <param name="file">the filename of the image</param>
        /// <returns>a bitmap</returns>
        internal BitmapFrame Decode(string file)
        {
            return Decode(file, false);
        }
    }
}
