using KRHash;
namespace HashTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("valami", "249d6c99eff6d0ef6c470e4254629323")]
        public void Md5Test(string szoveg,string elvarthash)
        {
            CreateHash createHash = new CreateHash();
            var createdHash=createHash.MakeHash(HashType.MD5, szoveg);

            Assert.AreEqual(elvarthash, createdHash);

            
        }
    }
}