using System.Text;

namespace Maraton13c2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maratonváltó");
            List<Eredmeny> eredmenyek=new List<Eredmeny>();

            try
            {
                eredmenyek = LoadData.LoadFromCsv("maratonvalto.csv");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            finally
            {
                Console.WriteLine($"Sorok száma:{eredmenyek.Count}");
            }

            Console.WriteLine($"6.feladat:{eredmenyek.Average(x=>x.Ido)}");

            var gyorsak = eredmenyek.FindAll(x=>x.Ido/60<=30);

            try
            {
                FileStream fajl = new FileStream("gyorsak.txt", FileMode.Create);
                using (StreamWriter writer=new StreamWriter(fajl,Encoding.UTF8))
                {
                    foreach (var i in gyorsak)
                    {
                        writer.WriteLine($"{i.Versenyzo.Fid} {i.Versenyzo.Fnev} {i.Ido}");
                    }
                }
                Console.WriteLine("Fájba írás kész!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            //Leggyorsabb csapat meghatározása
            var csapatstat = eredmenyek.ToLookup(x=>x.Versenyzo.Csapat).OrderBy(x=>x.Sum(y=>y.Ido));

            var gyoztescsapatId = csapatstat.First().Key;

            Console.WriteLine(gyoztescsapatId);

            var gyoztesCsapat = eredmenyek.FindAll(x=>x.Versenyzo.Csapat==gyoztescsapatId);

            var gyoztesCsapatIdo = gyoztesCsapat.Sum(x => x.Ido);

            //Győztes idő másodpercből => óra:perc:másodperc
            //Mindig TimeSpan-t érdemes használni!

            var gyoztesIdo = new TimeSpan(0, 0, gyoztesCsapatIdo);
            Console.WriteLine(gyoztesIdo);

            foreach (var i in gyoztesCsapat)
            {
                Console.WriteLine($"{i.Versenyzo.Fid} {i.Versenyzo.Fnev}");
            }



            //foreach (var i in csapatstat)
            //{
            //    Console.WriteLine($"{i.Key} - {i.Sum(x=>x.Ido)}");
            //}


        }
    }
}
