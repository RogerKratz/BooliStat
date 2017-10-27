using System;
using BooliNET;

namespace BooliStatTest
{
    public static class SoldFactory
    {
        public static Sold CreateRandom()
        {
            return new Sold()
            {
                booliId = new Random().Next(),
                soldPrice = new Random().Next(),
                soldDate = new DateTime(1970, 1, 1).AddDays(new Random().Next(10000)).ToString()
            };
        } 
    }
}