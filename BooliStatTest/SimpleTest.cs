using System.Configuration;
using System.IO;
using System.Linq;
using BooliStat;
using NUnit.Framework;

namespace BooliStatTest
{
    public class SimpleTest
    {
        [Test]
        public void ShouldAddNewFile()
        {
            var sold = SoldFactory.CreateRandom();
            var resultFetcher = new FakeResultFetcher(sold);
            var target = new StoreDataToDisc(resultFetcher);

            target.UpdateFile(ConfigurationManager.AppSettings["filePath"], null, null, null, 1, 1);
            
            Assert.That(File.ReadAllLines(ConfigurationManager.AppSettings["filePath"]).Single(), 
                Is.EqualTo(string.Format(StoreDataToDisc.FileRowFormat, sold.soldDate, sold.soldPrice, sold.booliId)));
        }
    }
}