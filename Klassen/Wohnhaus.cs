using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiSi.Interfaces;

namespace WiSi.Klassen
{
    class Wohnhaus : Gebaeude, IBaubar 
    {
        public string _img = "pack://application:,,,/images/house.png";
        public override string ImagePath { get => _img;}
        
        private int _bildWidth = 60;
        private int _bildHeight = 60;

        private int _holzKosten = 60;
        private int _eisenKosten = 40;
        private int _steinKosten = 70;

        private GebaeudePosition _position;
        private Kosten _kosten;

        public Kosten kosten { get => _kosten; }
        public int Id { get; set; }
        public static int Anzahl = 0;
        public static List<Wohnhaus> Wohnhaeuser = new List<Wohnhaus>();
        public override GebaeudePosition Position
        {
            get => _position;
            set
            {
                _position = value;
                
            }
        }

        public Wohnhaus()
        {
            Anzahl++;
            Id = Anzahl;
            Wohnhaeuser.Add(this);
            _kosten.HolzKosten = _holzKosten;
            _kosten.EisenKosten = _eisenKosten;
            _kosten.SteinKosten = _steinKosten;

            Bild.Width = _bildWidth;
            Bild.Height = _bildHeight;

        }

        public Wohnhaus(int left, int top)
        {
            Anzahl++;
            _position.left = left;
            _position.top = top;
            Id = Anzahl;
            Wohnhaeuser.Add(this);
        }
        public void Bauen(List<Ressource> res) 
        {
            Ressource.Stein.Anzahl -= kosten.SteinKosten;
            Ressource.Eisen.Anzahl -= kosten.EisenKosten;
            Ressource.Holz.Anzahl -= kosten.HolzKosten;

            foreach (Ressource r in res)
            {
                r.OnPropCh(nameof(Anzahl));
            }
        }
    }
}
