using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiSi.Interfaces
{
    struct Kosten
    {
        public int HolzKosten { get; set; }
        public int SteinKosten { get; set; }
        public int EisenKosten { get; set; }
    }
    interface IBaubar
    {
        Kosten kosten { get; }

        void Bauen();
    }
}
