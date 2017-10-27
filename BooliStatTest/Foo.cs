using System.Configuration;
using NUnit.Framework;
using BooliStat;

namespace BooliStatTest
{
    public class Foo
    {
        [Test]
        public void Testet()
        {
            var fetchdata = new ResultFetcher();
            fetchdata.Execute(ConfigurationManager.AppSettings["callerId"], 
                ConfigurationManager.AppSettings["privateKey"],
                "stockholms+innerstad",
                3,
                3);
            
        }
        
    }
}