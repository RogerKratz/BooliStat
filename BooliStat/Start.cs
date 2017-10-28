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
            var area = args[2];
            var file = args[3];

            var fetchSoldApartments =
                new FetchSoldApartments(new ResultFetcher(new FetchSettings(callerId, privateKey, area, 500)));
            var createMedianPrices = new CreateMedianPrices();
            var result = createMedianPrices.Execute(fetchSoldApartments.Execute());

            var output = result.Select(item => $"{item.Key:d}, {item.Value}");
            File.WriteAllLines(file, output);
        }
    }
}