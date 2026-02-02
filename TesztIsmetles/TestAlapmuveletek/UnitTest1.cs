using TesztIsmetles;

namespace TestAlapmuveletek
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(10,10,20)]
        [TestCase(10, 30, 40)]
        [TestCase(100, 100, 200)]
        [TestCase(15, 14, 29)]
        [TestCase(1000, 1, 1001)]
        public void OsszeadTest(double a,double b,double elvart)
        {
            //AAA -- Arrange, Act, Assert
            var alapmuveletek = new AlapMuvelet();
            var eredmeny = alapmuveletek.Osszead(a, b);
            Assert.AreEqual(elvart, eredmeny);
        }

        [Test]
        [TestCaseSource("GetOsztasAdatok")]
        public void OsztasTeszt(double a, double b, double elvart) {
            var alapmuveletek = new AlapMuvelet();
            var eredmeny = alapmuveletek.Oszt(a, b);
            Assert.AreEqual(elvart, eredmeny,0.000001);
        }

        //Tesztesetek betöltése fájlból
        public static IEnumerable<double[]> GetOsztasAdatok()
        {
            var sorok = File.ReadAllLines("tesztesetek_osztas.csv");
            for (int i = 0; i < sorok.Length; i++)
            {
                var adatok = sorok[i].Split(';');
                double a = Convert.ToDouble(adatok[0]);
                double b = Convert.ToDouble(adatok[1]);
                double elvart= Convert.ToDouble(adatok[2]);

                yield return new[] { a, b, elvart }; 
            }
        }

    }
}