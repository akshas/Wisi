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
        private Koordinaten _koordinaten;
        public string Position { get; set; }
        public Koordinaten koordinaten { get => _koordinaten; private set => _koordinaten = value; }
        public Pfad pfad { get; private set;}

        public Rectangle Form { get; set; }
        public int Id { get; set; }

        public static int Anzahl { get; set; } = 0;

        int Arbeitsgeschwindigkeit = 5;
        int BrotProTick = 1;
        double MilchProTick = 0.5;
        private static int StartAnzahl = 5;

        public static List<Einwohner> EinwohnerList = new List<Einwohner>();

        public Einwohner()
        {
            EinwohnerList.Add(this);
            Anzahl++;
        }
        public Einwohner(int index)
        {
            //_koordinaten.x = 3;
            //_koordinaten.y = 5;

            Gehen(pfad.start, pfad.ziel);

            Id = index;
            Form = new Rectangle
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.Aqua,
                Name = "Einwohner_" + Id
            };

            EinwohnerList.Add(this);
            Anzahl++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Gehen(Koordinaten start, Koordinaten ziel)
        {
            start.x = 20;
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


        /// <summary>
        ///   3 erste Einwohner beim Spielstart erzeugen
        /// </summary>
        public static void StartEinwohnerErzeugen()
        {
            for (int i = 1; i <= StartAnzahl; i++)
            {
                new Einwohner(i);
            }
        }
    }
}
