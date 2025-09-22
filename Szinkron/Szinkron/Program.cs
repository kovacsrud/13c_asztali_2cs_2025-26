using System.Text;

namespace Szinkron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Szinkronhang> szinkronhangok = new List<Szinkronhang>();

            try
            {
                szinkronhangok = Szinkronbetolt.LoadFromJson("szinkronhangok.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.WriteLine(szinkronhangok.Count);

            //korhatáros, nem korhatáros
            var korhataros = szinkronhangok.Count(x=>x.Film.Korhataros==true);
            var nemKorhataros = szinkronhangok.Count(x => x.Film.Korhataros == false);
            Console.WriteLine($"Korhatáros:{korhataros},nem korhatáros:{nemKorhataros}");

            var stat = szinkronhangok.ToLookup(x=> new {x.Film.FilmAz,x.Film.Cim});

            try
            {
                FileStream fajl=new FileStream("szinkronstat.txt",FileMode.Create);

                using (StreamWriter writer = new StreamWriter(fajl, Encoding.UTF8)) 
                {
                    foreach (var i in stat)
                    {
                        writer.WriteLine($"{i.Key.FilmAz}-{i.Key.Cim}-{i.Count()} db");
                    }
                }
                Console.WriteLine("A fájl létrehozva!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }


            Console.Write("Adja meg a szinkronszínész nevét:");
            var szineszNev=Console.ReadLine();

            var szineszAdatok = szinkronhangok.FindAll(x => x.Magyarhang == szineszNev);

            if (szineszAdatok.Count>0)
            {
                foreach (var i in szineszAdatok)
                {
                    Console.WriteLine($"{i.Szinesz},{i.Film.Cim},{i.Szerep},{i.Film.Ev}");
                }
            } else
            {
                Console.WriteLine("Nincs ilyen szinkronszínész!");
            }


                Console.ReadKey();
        }
    }
}
