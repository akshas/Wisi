using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WiSi
{
    class Ressource : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int Anzahl {get; set;}
        public double Verkaufspreis { get; set; }
        public double Einkaufspreis { get; set; }
        public int AnzahlZumVerkaufen { get; set; }
        public int AnzahlZumKaufen { get; set; }


        public static Ressource Brot;
        public static Ressource Milch;
        public static Ressource Stein;
        public static Ressource Eisen;
        public static Ressource Holz;
        public static Ressource Gold;

        public static DataTable ress;

        public static ObservableCollection<Ressource> ResList = new ObservableCollection<Ressource>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Ressource(int id)
        {
            DataRow row = ress.Select("Id = " + id)[1];
            Id = (int)row["Id"];
            Name = (string)row["Name"];
            Anzahl = (int)row["LagerAnzahl"];
            ResList.Add(this);
            //MessageBox.Show(this.Einkaufspreis.ToString()); 
        }

        public static void RessourcenErzeugen()
        {
            ress = DBConnection.SelectRes();

            Brot = new Ressource(1) { Einkaufspreis = 20, Verkaufspreis = 15};
            Milch = new Ressource(2){ Einkaufspreis = 30, Verkaufspreis = 24};
            Stein = new Ressource(3){ Einkaufspreis = 50, Verkaufspreis = 45};
            Eisen = new Ressource(4){ Einkaufspreis = 70, Verkaufspreis = 65};
            Holz = new Ressource(5){ Einkaufspreis = 40, Verkaufspreis = 35};
            Gold = new Ressource(6){ Einkaufspreis = 60, Verkaufspreis = 55};
        }
        public void OnPropCh([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
