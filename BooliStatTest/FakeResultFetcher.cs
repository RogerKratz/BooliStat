using System.Collections.Generic;
using System.Linq;
using BooliNET;
using BooliStat;

namespace BooliStatTest
{
    public class FakeResultFetcher : IResultFetcher
    {
        private readonly IEnumerable<Sold> _totalResults;
        private int resultCounter;
        
        public FakeResultFetcher(params Sold[] totalResults)
        {
            _totalResults = totalResults;
        }

        public SoldResult Execute(string callerId, string privateKey, string area, int limit, int offset)
        {
            var currentSold = _totalResults
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / limit)
                .Select(x => x.Select(v => v.Value))
                .ToArray()[resultCounter];
            
            resultCounter++;
            return new SoldResult
            {
                totalCount = _totalResults.Count(),
                sold = currentSold.ToList(),
                count = currentSold.Count(),
                limit = limit,
                offset = offset
            };
        }
    }
}