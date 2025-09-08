using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDronok.Model
{
    public class DronLista
    {
        public List<Dron> Dronok { get; set; } = new List<Dron>();

        public DronLista(string fajl,char hatarolo,int start=1)
        {
            var sorok=File.ReadAllLines(fajl,Encoding.Default);

            for(int i = start; i < sorok.Length; i++)
            {
                Dronok.Add(new Dron(sorok[i], hatarolo));
            }
            
        }
    }
}
