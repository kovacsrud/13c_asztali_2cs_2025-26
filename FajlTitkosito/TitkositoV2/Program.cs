namespace TitkositoV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Titkosító osztály");
            Titkosito.Kodolas("proba.txt", "proba.bin", "Titok_12");
            Console.WriteLine(Titkosito.Message);
        }
    }
}
