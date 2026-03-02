namespace HajoVizsgafeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hajo> hajok=new List<Hajo>();

            hajok.Add(new Vitorlas
            {
                GyartasEve = 1980,
                Hossz = 16,
                MaxSebesseg = 20,
                Nev = "V1",
                Suly = 5,
                VitorlakSzama = 6
            });

            hajok.Add(new Vitorlas
            {
                GyartasEve = 1960,
                Hossz = 19,
                MaxSebesseg = 22,
                Nev = "V2",
                Suly = 7,
                VitorlakSzama = 10
            });

            hajok.Add(new Teher {
                GyartasEve=1990,
                Hossz=30,
                MaxSebesseg=18,
                Nev="T1",
                Suly=15000,
                SzallithatoTomeg=8000
            });

            hajok.Add(new Teher
            {
                GyartasEve = 1971,
                Hossz = 35,
                MaxSebesseg = 16,
                Nev = "T2",
                Suly = 25000,
                SzallithatoTomeg = 12000
            });

            foreach (var i in hajok)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
