using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace cscd349FinalProject
{
    static class HelperImages
    {
        public static ImageBrush UriStringToImageBrush(string uriString)
        {
            Uri uri = new Uri(uriString);
            Image bg = new Image();
            bg.Source = new BitmapImage(uri);
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = bg.Source;
            return myBrush;
        }

        public static ImageSource UriStringToImageSource(string uriString)
        {
            return new BitmapImage(new Uri(uriString));
        }
    }
}
