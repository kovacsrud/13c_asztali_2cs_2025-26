using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace KonverterTeszt
{
    public class Tests
    {
        protected const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private const string Program = @"D:\rud-2\kodtarak_25-26\13c_asztali_2cs_2025-26\WpfHomersekletKonverter\WpfHomersekletKonverter\bin\Debug\net7.0-windows\WpfHomersekletKonverter.exe";

        private const string ProgramPath = @"D:\rud-2\kodtarak_25-26\13c_asztali_2cs_2025-26\WpfHomersekletKonverter\WpfHomersekletKonverter\bin\Debug\net7.0-windows\";

        protected static WindowsDriver<WindowsElement> driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            if (driver==null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", Program);
                appiumOptions.AddAdditionalCapability("devicename", "Win10");
                driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl),appiumOptions);
            }
        }

        [Test]
        [TestCase(85,29.444)]
        [TestCase(33,0.55555555)]
        public void FahrenheitToCelsiusTest(double fahrenheit,double elvart)
        {
            var homerseklet = driver.FindElementByAccessibilityId("homersekletErtek");
            homerseklet.Clear();
            driver.FindElementByAccessibilityId("celsiusKivalaszt").Click();
            homerseklet.SendKeys(fahrenheit.ToString());
            driver.FindElementByAccessibilityId("buttonKonvertalas").Click();
            var eredmeny = driver.FindElementByAccessibilityId("konvertaltHomerseklet");
            Assert.AreEqual(elvart, Convert.ToDouble(eredmeny.Text),0.001);
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}