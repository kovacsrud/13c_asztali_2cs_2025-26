using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace HajoVizsgafeladat
{
    //Az absztrakt osztály nem példányosítható, csak öröklési célokat szolgál
    public abstract class Hajo
    {
        public string Nev { get; set; }
        public int Hossz { get; set; }
        public int Suly { get; set; }
        public int MaxSebesseg { get; set; }
        public int GyartasEve { get; set; }

        public abstract void Haladas();
        public abstract void Leiras();

        public double MegteszTavolsag(double tavolsag)
        {
            return tavolsag / MaxSebesseg;
        }

        public override string ToString()
        {
            return $"Név:{Nev},Hossz:{Hossz},Suly:{Suly},Max.sebesség:{MaxSebesseg},Gyártás éve:{GyartasEve}";
        }
    }
}
