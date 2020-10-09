using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows;

namespace WiSi
{
    struct MarktPosition
    {
        public int top;
        public int left;
    }

    class Marktplatz
    {
        //Preise
        public double SteinEinkaufsPreis { get; private set; } = 50;
        public double EisenEinkaufsPreis { get; private set; } = 70;
        public double HolzEinkaufsPreis  { get; private set; } = 60;
        public double BrotEinkaufsPreis  { get; private set; } = 20;
        public double MilchEinkaufsPreis { get; private set; } = 30;

        public MarktPosition Position;
        string ImagePath = "pack://application:,,,/images/Markt3.png";
        ImageBrush  element = new ImageBrush();
        public Rectangle Bild;

        public  Dictionary<Ressource, int> DingeZumKaufen = new Dictionary<Ressource, int>();
        public  Dictionary<Ressource, int> DingeZumVerkaufen = new Dictionary<Ressource, int>();
        public Marktplatz()
        {
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Bild = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = element,
                Name = "Marktplatz"
            };

            Position = new MarktPosition();
            Position.left = 600;
            Position.top = 400;
        }

        public void Kaufen(Dictionary<Ressource, int> zumKaufen)
        {
            foreach (var item in zumKaufen)
            {
                if (item.Key != Ressource.Gold)
                {
                    item.Key.Anzahl += item.Value;
                    item.Key.OnPropCh(nameof(item.Key.Anzahl));
                }
                else
                {
                    item.Key.Anzahl -= item.Value;
                    item.Key.OnPropCh(nameof(item.Key.Anzahl));
                }
            }
        }

        public void Verkaufen(Dictionary<Ressource, int> zumVerkaufen)
        {
            foreach (var item in zumVerkaufen)
            {
                if (item.Key != Ressource.Gold)
                {
                    item.Key.Anzahl -= item.Value;
                    item.Key.OnPropCh(nameof(item.Key.Anzahl));
                }
                else
                {
                    item.Key.Anzahl += item.Value;
                    item.Key.OnPropCh(nameof(item.Key.Anzahl));
                }
            }
        }
    }
}
