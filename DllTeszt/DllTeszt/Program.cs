
using KRHash;

namespace DllTeszt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dll használata");

            CreateHash createHash = new CreateHash();
            Console.WriteLine(createHash.MakeHash(HashType.MD5,"valami"));
            Console.WriteLine(createHash.MakeHash(HashType.MD5, "valami"));
            Console.WriteLine(createHash.MakeHash(HashType.MD5, "valami"));

            Console.WriteLine(createHash.MakeHash(HashType.SHA1, "valami"));
            Console.WriteLine(createHash.MakeHash(HashType.SHA1, "valami")); 
            Console.WriteLine(createHash.MakeHash(HashType.SHA1, "valami"));
        }
    }
}
