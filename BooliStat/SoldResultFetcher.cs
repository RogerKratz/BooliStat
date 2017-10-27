using BooliNET;

namespace BooliStat
{
	public class ResultFetcher : IResultFetcher
	{
		public SoldResult Execute(string callerId, string privateKey, string area, int limit, int offset)
		{
			var booli = new Booli(callerId, privateKey);
			var sc = new BooliSearchCondition
			{
				Q = area,
				Limit = limit,
				Offset = offset
			};
			var scSold = new ExtendedSearchConditionSold();
		   	return booli.GetResultSold(sc, scSold);
		}
	}
}