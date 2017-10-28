using System;
using System.Collections.Generic;
using System.Linq;
using BooliNET;

namespace BooliStat.Code
{
    public class FetchSoldApartments
    {
        private readonly IResultFetcher _resultFetcher;

        public FetchSoldApartments(IResultFetcher resultFetcher)
        {
            _resultFetcher = resultFetcher;
        }

        public IEnumerable<SoldApartment> Execute()
        {
            var ret = new List<SoldApartment>();
            var firstResult = _resultFetcher.Execute(0);
            ret.AddRange(soldResultToSoldApartment(firstResult));
            var totalCount = firstResult.totalCount;
            while (ret.Count < totalCount)
            {
                var nextResult = _resultFetcher.Execute(ret.Count);
                ret.AddRange(soldResultToSoldApartment(nextResult));
            }
            return ret;
        }

        private static IEnumerable<SoldApartment> soldResultToSoldApartment(SoldResult soldResult)
        {
            return soldResult.sold
                .Select(sold => 
                    new SoldApartment((int) sold.soldPrice, DateTime.Parse(sold.soldDate), (int) sold.livingArea));
        }
    }
}