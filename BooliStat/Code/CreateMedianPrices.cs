using System;
using System.Collections.Generic;
using System.Linq;

namespace BooliStat.Code
{
    public class CreateMedianPrices
    {
        public const int DaysBack = 30;
        
        public IDictionary<DateTime, int> Execute(IEnumerable<SoldApartment> soldApartments)
        {
            var orderedSold = soldApartments.OrderBy(x => x.Date);
            var firstDate = orderedSold.First().Date;
            var lastDate = orderedSold.Last().Date;
           
            var ret = new Dictionary<DateTime, int>();
            var currentDate = firstDate;
            while (currentDate <= lastDate)
            {
                var pricePerKvm = (from soldApartment in soldApartments 
                    where soldApartment.Date <= currentDate && soldApartment.Date >= currentDate.AddDays(-DaysBack) 
                    let price = soldApartment.Price 
                    let size = soldApartment.Area 
                    select price / size)
                    .ToList();
                ret[currentDate] = pricePerKvm.Sum() / pricePerKvm.Count();
                
                currentDate = currentDate.AddDays(1);
            }
           
            return ret;
        }
    }
}