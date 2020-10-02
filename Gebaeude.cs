using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiSi
{


    abstract class Gebaeude
    {
        public string Position { get; set; }
        public int Level { get; set; }

        abstract public int Anzahl{get; set;}
        abstract public int Fassungsvermoegen { get; set; }


        
    }
}
