using TesztIsmetles;

namespace AlapmuveletProba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alapműveletek");
            AlapMuvelet alapMuvelet = new AlapMuvelet();

            Console.WriteLine(alapMuvelet.Osszead(10,10));
            Console.WriteLine(alapMuvelet.Kivon(10, 10));
            Console.WriteLine(alapMuvelet.Szoroz(10, 10));
            Console.WriteLine(alapMuvelet.Oszt(10, 10));
        }
    }
}
