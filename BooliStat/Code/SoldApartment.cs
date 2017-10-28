using System;

namespace BooliStat.Code
{
    public class SoldApartment
    {
        public SoldApartment(int price, DateTime date, int area)
        {
            Price = price;
            Date = date;
            Area = area;
        }
        
        public int Price { get; }
        public DateTime Date { get; }
        public int Area { get; }
    }
}