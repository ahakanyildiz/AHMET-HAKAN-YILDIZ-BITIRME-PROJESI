using StackExchange.Redis;


namespace Movies.DataAccess.Redis
{
    public interface IRedisHelper
    {
        Task<bool> SetKeyAsync(string Key, string Value);
        Task<string> GetKeyAsync(string Key);
        Task<long> SetListAsync(string Key, string Value);
        Task<Array> GetListAsync(string Key);
    }


}
