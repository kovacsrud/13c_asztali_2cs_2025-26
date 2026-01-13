using System.Security.Cryptography;
using System.Text;

namespace FajlTitkosito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Titkosító program");

            string fajlnev = "titkos.txt";
            string kulcs = "Titok_12";
            string titkositando = "Szigorúan titkos titok!";

            //Visszafejtéshez szükséges információk
            //Kulcs, tartalom hash, tartalom, eredeti fájlnév

            //Titkosító algoritmus
            Aes aes=Aes.Create();

            //Inicializációs vektor, ezt el kell tárolni!
            aes.GenerateIV();

            //Hash
            SHA256 sha256 = SHA256.Create();

            byte[] binKulcs = sha256.ComputeHash(Encoding.UTF8.GetBytes(kulcs));
            byte[] tartalomHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(titkositando));
            byte[] fajlnevBin=Encoding.UTF8.GetBytes(fajlnev);
            byte[] titkositandoBin = Encoding.UTF8.GetBytes(titkositando);
            int fajlnevHossz=fajlnevBin.Length;
            aes.Key = binKulcs;

            ICryptoTransform titkosito = aes.CreateEncryptor(binKulcs, aes.IV);
            byte[] titkositott = titkosito.TransformFinalBlock(titkositandoBin,0,titkositandoBin.Length);
            int titkosTartalomHossz=titkositott.Length;

            
            string kodoltSzoveg=Encoding.UTF8.GetString(titkositott);
            Console.WriteLine(kodoltSzoveg);

            //Fájl formátum
            //IV - 16 byte//fájlnév hossza - 4 byte//fájlnév - változó//tartalom hash - 32 byte//titkos tartalom hossza - 4 byte//titkositott tartalom - változó

            var kodoltAdatok = new byte[aes.IV.Length+fajlnevHossz+fajlnevBin.Length+tartalomHash.Length+titkosTartalomHossz+titkositott.Length];

            using (MemoryStream ms=new MemoryStream(kodoltAdatok))
            {
                using (BinaryWriter writer=new BinaryWriter(ms))
                {
                    writer.Write(aes.IV);
                    writer.Write(fajlnevHossz);
                    writer.Write(fajlnevBin);
                    writer.Write(tartalomHash);
                    writer.Write(titkosTartalomHossz);
                    writer.Write(titkositott);
                }
                File.WriteAllBytes("titkositott.bin",kodoltAdatok);
                Console.WriteLine("Fájl kiírva!");
            }

            //Visszafejtés?
            byte[] fajl = File.ReadAllBytes("titkositott.bin");
            int fajlLength=fajl.Length;
            byte[] initVektor;
            byte[] visszaFajlnev;
            byte[] visszaTartalomHash;
            byte[] visszaTartalom;
            string jelszo = "Titok_12";
            byte[] visszaKulcs=sha256.ComputeHash(Encoding.UTF8.GetBytes(jelszo));

            using (MemoryStream ms=new MemoryStream(fajl))
            {
                using (BinaryReader reader=new BinaryReader(ms))
                {
                    initVektor = reader.ReadBytes(16);
                    int fajlnevMeret = BitConverter.ToInt32(reader.ReadBytes(4));
                    visszaFajlnev = reader.ReadBytes(fajlnevMeret);
                    visszaTartalomHash = reader.ReadBytes(32);
                    int visszaTartalomHossz=BitConverter.ToInt32(reader.ReadBytes(4));
                    visszaTartalom = reader.ReadBytes(visszaTartalomHossz);
                }
            }


        }
    }
}
