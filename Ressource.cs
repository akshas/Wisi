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

namespace WiSi
{
    class Ressource : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int Anzahl {get; set;}
        public static Ressource Brot;
        public static Ressource Milch;
        public static Ressource Stein;
        public static Ressource Eisen;
        public static Ressource Holz;
        public static Ressource Gold;

        public static ObservableCollection<Ressource> ResList = new ObservableCollection<Ressource>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Ressource(int id)
        {
            DataTable ress = DBConnection.SelectRes();
            DataRow row = ress.Select("Id = " + id)[1];
            Id = (int)row["Id"];
            Name = (string)row["Name"];
            Anzahl = (int)row["LagerAnzahl"];
            ResList.Add(this);
        }

        public static void RessourcenErzeugen()
        {
            Brot = new Ressource(1);
            Milch = new Ressource(2);
            Stein = new Ressource(3);
            Eisen = new Ressource(4);
            Holz = new Ressource(5);
            Gold = new Ressource(6);
        }
        public void OnPropCh([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
