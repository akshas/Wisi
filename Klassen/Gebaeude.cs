using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WiSi
{
    struct GebaeudePosition
    {
        public int top;
        public int left;
    }

    abstract class Gebaeude
    {
        //public int Level { get; set; }
        //abstract public int Anzahl{get; set;}
        //abstract public int Fassungsvermoegen { get; set; }
        ImageBrush element = new ImageBrush();
        public Rectangle Bild;

        abstract public string ImagePath { get;}
        abstract public GebaeudePosition Position { get; }
        public Gebaeude()
        {
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Bild = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = element,
                Name = "Gebaeude"
            };
        }

        public Gebaeude(string name)
        {
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Bild = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = element,
                Name = name
            };
        }

        //abstract public void SetPosition();
    }
}
