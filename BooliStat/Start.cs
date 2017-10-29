using System;
using System.IO;
using System.Linq;
using System.Web;
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
            var area = args[3];
            var areatouse = area == "soder" ? "södermalm" : "stockholms+innerstad";
            var fetchSoldApartments =
                new FetchSoldApartments(new ResultFetcher(new FetchSettings(callerId, privateKey, areatouse, 500)));
            var createMedianPrices = new CreateMedianPrices();
            var result = createMedianPrices.Execute(new DateTime(2013,1,1), fetchSoldApartments.Execute());

            var output = result.Select(item => $"{item.Key:d}, {item.Value}");
            File.WriteAllLines(file, output);
        }
    }
}