using BooliNET;

namespace BooliStat
{
    public interface IResultFetcher
    {
        SoldResult Execute(string callerId, string privateKey, string area, int limit, int offset);
    }
}