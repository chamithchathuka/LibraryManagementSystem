using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Library_Management_System.Util
{
    class Convertor
    {
        public static  BitmapImage ToImage(byte[] array)
        {
            var image = new BitmapImage();
            using (var ms = new System.IO.MemoryStream(array))
            {

                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();

            }
            return image;
        }

        public static byte[] imageToByteArray(BitmapImage imageIn)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return data = ms.ToArray();
            }
        }
    }
}
