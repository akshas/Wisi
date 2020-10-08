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

        private GebaeudePosition _position;
        public int Id { get; set; }
        public static int Anzahl = 0;
        public static List<Wohnhaus> Wohnhaeuser = new List<Wohnhaus>();
        public override GebaeudePosition Position
        {
            get => _position;
            set
            {
                _position.left = Position.left;
                _position.top = Position.top;
            }
        }

        public Wohnhaus()
        {
            Anzahl++;
            Id = Anzahl;
            Wohnhaeuser.Add(this);
        }

        public Wohnhaus(int left, int top)
        {
            Anzahl++;
            _position.left = left;
            _position.top = top;
            Id = Anzahl;
            Wohnhaeuser.Add(this);
        }
        public void Bauen() 
        { 
             
        }
    }
}
