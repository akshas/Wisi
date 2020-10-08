using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WiSi.Klassen
{
    class Rathaus : Gebaeude
    {
        string _img = @"pack://application:,,,/images/townHall.png";
        int left = 450;
        int top = 150;
        public string Name { get; private set; } = "Rathaus";
        public override string ImagePath { get => _img;}


        private GebaeudePosition _position;
        public override GebaeudePosition Position 
        {
            get => _position;
            set
            {

            }
        }

        public Rathaus(string name)
        {
            _position.left = left; 
            _position.top = top; 
        }

        public void ShowStatistic()
        {
            MessageBox.Show("Statistik");
        }
    }
}
