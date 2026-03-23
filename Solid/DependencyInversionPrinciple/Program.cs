namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dependency Inversion Principle");

            //A magas szintű modulok ne függjenek az alacsony szintű moduloktól. Mindkettő absztrakcióktól függjön.

            //Fixen "bedrótozott" adatbázis
            var rosszUserService=new RosszUserService();

            //Nincs fix adatbázis, bármi átadható, ami az IDatabase-t megvalósítja
            var userService = new JoUserService(new OracleDB());
            userService.UserMentes("Béla");


        }
    }
}
