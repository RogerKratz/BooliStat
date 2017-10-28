using System;
using BooliNET;

namespace BooliStatTest.FakeAndHelpers
{
    public static class SoldFactory
    {
        private static readonly Random rnd = new Random();
        
        public static Sold Create(int id)
        {
            return new Sold()
            {
                booliId = id,
                soldPrice = rnd.Next(),
                soldDate = new DateTime(1970, 1, 1).AddDays(id).ToString()
            };
        } 
    }
}