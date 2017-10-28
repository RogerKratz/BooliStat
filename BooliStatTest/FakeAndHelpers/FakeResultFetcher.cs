using System.Collections.Generic;
using System.Linq;
using BooliNET;
using BooliStat.Code;

namespace BooliStatTest.FakeAndHelpers
{
    public class FakeResultFetcher : IResultFetcher
    {
        private readonly IEnumerable<Sold> _totalResults;
        private readonly int _limit;

        public FakeResultFetcher(int limit, params Sold[] totalResults)
        {
            _totalResults = totalResults;
            _limit = limit;
        }

        public SoldResult Execute(int offset)
        {
            var ret = _totalResults.Skip(offset).Take(_limit);
            
            return new SoldResult
            {
                totalCount = _totalResults.Count(),
                sold = ret.ToList(),
                count = ret.Count(),
                limit = _limit,
                offset = offset
            };
        }
    }
}