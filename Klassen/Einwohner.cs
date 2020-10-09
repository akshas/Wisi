using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WiSi
{
    struct Koordinaten
    {
        public int x;
        public int y;
    }
    struct Pfad
    {
        public Koordinaten start;
        public Koordinaten ziel;

        public Pfad(Koordinaten sta, Koordinaten zi)
        {
            start = sta; 
            ziel = zi; 
        }
    }

    class Einwohner : INotifyPropertyChanged
    {
        public Koordinaten Position = new Koordinaten();
        public Pfad ziel { get; set;}



        public Rectangle Form { get; set; }
        public int Id { get; set; }
        public static int Geschwindigkeit { get; set; } = 8;

        public static int Anzahl { get; set; } = 0;
        public static int variable = 0;

        int Arbeitsgeschwindigkeit = 5;
        int BrotProTick = 1;
        double MilchProTick = 0.5;
        public static int StartAnzahl { get; private set; } =  3;

        public static List<Einwohner> EinwohnerList = new List<Einwohner>();

        public Einwohner()
        {
            EinwohnerList.Add(this);
            Anzahl++;
        }
        public Einwohner(int index)
        {

            Id = index;
            Form = new Rectangle
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.Aqua,
                Name = "Einwohner_" + Id
            };

            Position.x = 400 + variable;
            Position.y = 300;
            EinwohnerList.Add(this);
            Anzahl++;
            variable += 50;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    
        public void Gehen(Koordinaten start, Koordinaten ziel)
        {

        }

        public void Arbeiten()
        {

        }


        public void Essen (Ressource res)
        {
            //DBConnection.updateResElement();
            if (res.Name == "Brot" || res.Name == "Milch")
            {
                res.Anzahl--;
                res.OnPropCh(nameof(res.Anzahl));
            }
        }
        public void OnPropCh([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
