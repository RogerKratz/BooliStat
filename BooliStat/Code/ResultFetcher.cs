using BooliNET;

namespace BooliStat.Code
{
	public class ResultFetcher : IResultFetcher
	{
		private readonly FetchSettings _fetchSettings;

		public ResultFetcher(FetchSettings fetchSettings)
		{
			_fetchSettings = fetchSettings;
		}
		
		public SoldResult Execute(int offset)
		{
			var booli = new Booli(_fetchSettings.CallerId, _fetchSettings.PrivateKey);
			var sc = new BooliSearchCondition
			{
				Q = _fetchSettings.Area,
				Limit = _fetchSettings.Limit,
				Offset = offset
			};
			if (_fetchSettings.Rooms > 0)
			{
				sc.MaxRooms = _fetchSettings.Rooms;
				sc.MinRooms = _fetchSettings.Rooms;
			}
			var scSold = new ExtendedSearchConditionSold();
		   	return booli.GetResultSold(sc, scSold);
		}
	}
}