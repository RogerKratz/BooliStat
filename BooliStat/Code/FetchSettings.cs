namespace BooliStat.Code
{
    public class FetchSettings
    {
        public FetchSettings(string callerId, string privateKey, string area, int limit)
        {
            CallerId = callerId;
            PrivateKey = privateKey;
            Area = area;
            Limit = limit;
        }
        
        public string CallerId { get; }
        public string PrivateKey { get; }
        public string Area { get; }
        public int Limit { get; }
    }
}