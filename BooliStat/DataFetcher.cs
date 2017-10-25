using System;
using System.Collections.Generic;
using BooliNET;

namespace BooliStat
{
    public class DataFetcher
    {
        public IEnumerable<Apartment> Execute(string callerId, string privateKey)
        {
            var booli = new Booli(callerId, privateKey);
            var sc = new BooliSearchCondition();
            sc.Q = "stockholms+innerstad";
            var result = booli.GetResult(sc);
            
            Console.WriteLine(result);
            return null;
        }
    }
    
    public class Apartment{}
}