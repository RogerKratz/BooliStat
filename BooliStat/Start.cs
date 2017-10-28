using System;
using System.IO;
using System.Linq;
using BooliStat.Code;

namespace BooliStat
{
    public static class Start
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var callerId = args[0];
            var privateKey = args[1];
            var file = args[2];

            var fetchSoldApartments =
                new FetchSoldApartments(new ResultFetcher(new FetchSettings(callerId, privateKey, "stockholms+innerstad", 500)));
            var createMedianPrices = new CreateMedianPrices();
            var result = createMedianPrices.Execute(fetchSoldApartments.Execute());

            var output = result.Select(item => $"{item.Key:d}, {item.Value}");
            File.WriteAllLines(file, output);
        }
    }
}