using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Library_Management_System.Util
{
    class Convertor
    {
        public BitmapImage ToImage(byte[] array)
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
    }
}
