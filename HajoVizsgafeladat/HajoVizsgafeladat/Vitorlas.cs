using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajoVizsgafeladat
{
    public class Vitorlas : Hajo
    {
        public int VitorlakSzama { get; set; }
        public override void Haladas()
        {
            Console.WriteLine("A vitorlás a szél segítségével siklik a vízen.");
        }

        public override void Leiras()
        {
            Console.WriteLine("Könnyű vitorlás hajó, tengeri kalandokhoz.");
        }

        public override string ToString()
        {
            return base.ToString()+$" Vitorlák száma:{VitorlakSzama}";
        }
    }
}
