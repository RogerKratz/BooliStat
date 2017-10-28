using System;
using System.Collections.Generic;
using System.Linq;

namespace BooliStat.Code
{
    public class CreateMedianPrices
    {
        public const int DaysBack = 14;
        
        public IDictionary<DateTime, int> Execute(DateTime fromDate, IEnumerable<SoldApartment> soldApartments)
        {
            var orderedSold = soldApartments.OrderBy(x => x.Date);
            var lastDate = orderedSold.Last().Date;
            if (lastDate < fromDate)
            {
                lastDate = fromDate;                
            }
           
            var ret = new Dictionary<DateTime, int>();
            var currentDate = fromDate;
            while (currentDate <= lastDate)
            {
                var pricePerKvm = (from soldApartment in soldApartments 
                    where soldApartment.Date <= currentDate && soldApartment.Date >= currentDate.AddDays(-DaysBack) 
                    let price = soldApartment.Price 
                    let size = soldApartment.Area 
                    where size > 0 
                    select price / size)
                    .ToList();
                ret[currentDate] = pricePerKvm.Any() ? pricePerKvm.Sum() / pricePerKvm.Count : 0;

                currentDate = currentDate.AddDays(1);
            }
           
            return ret;
        }
    }
}