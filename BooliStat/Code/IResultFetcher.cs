using BooliNET;

namespace BooliStat.Code
{
    public interface IResultFetcher
    {
        SoldResult Execute(int offset);
    }
}