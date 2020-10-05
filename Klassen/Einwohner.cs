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
    class Einwohner : INotifyPropertyChanged
    {
        public string Position { get; set; }
        public int Gesundheit { get; set; }
        public int Geschwindigkeit { get; set; }

        public Rectangle Form { get; set; }
        public int Id { get; set; }
        public int RessourceId { get; set; } = 0;

        public static int Anzahl { get; set; } = 0;

        int Arbeitsgeschwindigkeit = 5;
        int BrotProTick = 1;
        double MilchProTick = 0.5;
        private static int StartAnzahl = 3;

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
                Width = 50,
                Height = 50,
                Fill = Brushes.Aqua,
                Name = "Einwohner_" + Id
            };
            
            EinwohnerList.Add(this);
            Anzahl++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Gehen()
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
