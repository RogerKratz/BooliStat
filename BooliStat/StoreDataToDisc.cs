using System.IO;
using System.Linq;

namespace BooliStat
{
    public class StoreDataToDisc
    {
        private readonly IResultFetcher _resultFetcher;
        public const string FileRowFormat = "{0}, {1}, {2}";

        public StoreDataToDisc(IResultFetcher resultFetcher)
        {
            _resultFetcher = resultFetcher;
        }

        public void UpdateFile(string filePath, string callerId, string privateKey, string area, int limit, int offset)
        {
            var result = _resultFetcher.Execute(callerId, privateKey, area, limit, offset);
            var newFileRows = result.sold
                .Select(sold => string.Format(FileRowFormat, sold.soldDate, sold.soldPrice, sold.booliId));
            File.WriteAllLines(filePath, newFileRows);
        }
    }
}