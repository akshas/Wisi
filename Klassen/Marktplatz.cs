using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace WiSi
{
        struct MarktPosition
        {
            public int top;
            public int left;
        }
    class Marktplatz
    {

        public MarktPosition Position;
        string ImagePath = "pack://application:,,,/images/Markt.png";
        ImageBrush  element = new ImageBrush();
        public Rectangle Bild;
        public Marktplatz()
        {
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Bild = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = element,
                Name = "Marktplatzzzz"
            };
            Position = new MarktPosition();
            Position.left = 300;
            Position.top = 300;
        }
        public void Kaufen(Ressource res)
        {

        }

        public void Verkaufen(Ressource res)
        {

        }
    }
}
