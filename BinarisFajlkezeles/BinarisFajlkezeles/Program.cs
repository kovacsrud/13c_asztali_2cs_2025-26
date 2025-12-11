using System.Text;

namespace BinarisFajlkezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fájlkezelés binárisan");

            var szovegFajl = File.ReadAllBytes("szinek.txt");

            foreach (var bajt in szovegFajl) {

                //Console.Write(bajt+" ");
                //Console.Write(Convert.ToString(bajt,2).PadLeft(8,'0')+" ");

            }
            //Szöveget ad vissza
            //Console.WriteLine(Encoding.UTF8.GetString(szovegFajl));

            //Hexa formában
            //Console.WriteLine(BitConverter.ToString(szovegFajl));

            var zipFajl = File.ReadAllBytes("MonthyHallGame.zip");

            foreach (var bajt in zipFajl) {

                //Console.Write(bajt + " ");

            }

            //Console.WriteLine(Encoding.UTF8.GetString(zipFajl));

            using (MemoryStream ms=new MemoryStream(zipFajl))
            {
                using (BinaryReader br=new BinaryReader(ms))
                {
                    var signature = br.ReadBytes(4);
                    Console.WriteLine($"Signature:{BitConverter.ToString(signature)}");
                    var version = br.ReadBytes(2);
                    Console.WriteLine($"Version:{BitConverter.ToInt16(version)}");
                    var flags=br.ReadBytes(2);
                    Console.WriteLine($"Flags:{BitConverter.ToInt16(flags)}");

                }
            }

        }
    }
}
