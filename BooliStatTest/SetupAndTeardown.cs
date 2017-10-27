using System.Configuration;
using System.IO;
using NUnit.Framework;

namespace BooliStatTest
{
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            deleteFile();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            deleteFile();
        }

        private static void deleteFile()
        {
            File.Delete(ConfigurationManager.AppSettings["filePath"]);
        }
    }
}