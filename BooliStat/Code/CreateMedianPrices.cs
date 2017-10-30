using System;
using System.Collections.Generic;
using System.Linq;

namespace BooliStat.Code
{
    public class CreateMedianPrices
    {
        public IDictionary<DateTime, int> Execute(DateTime fromDate, IEnumerable<SoldApartment> soldApartments)
        {
            if(!soldApartments.Any())
                return new Dictionary<DateTime, int>();
            
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
                    where soldApartment.Date == currentDate
                    let price = soldApartment.Price 
                    let size = soldApartment.Area 
                    where size > 0 
                    select price / size)
                    .ToList();
                if (pricePerKvm.Any())
                {
                    ret[currentDate] = (int) pricePerKvm.Average();    
                }

                currentDate = currentDate.AddDays(1);
            }
           
            return ret;
        }
    }
}