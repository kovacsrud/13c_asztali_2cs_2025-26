using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class RosszFeketeNyomtato : IMultiPrinter
    {
        public void FeketeFeherNyomtatas()
        {
            Console.WriteLine("Fekete-fehér nyomtatás");
        }

        public void SzinesNyomtatas()
        {
            throw new NotImplementedException();
        }

        public void Szkenneles()
        {
            throw new NotImplementedException();
        }
    }
}
