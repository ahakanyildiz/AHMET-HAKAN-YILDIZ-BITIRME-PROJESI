using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAccess.Redis
{
    public class RedisHelper : IRedisHelper
    {
        public async Task<string> GetKeyAsync(string Key)
        {
            var database = await GetRedisDatabase();
            return database.StringGetAsync(Key).ToString();
        }

        public async Task<bool> SetKeyAsync(string Key, string Value)
        {
            var database = await GetRedisDatabase();
            return await database.StringSetAsync(Key, Value);
            
        }

        public async Task<Array> GetListAsync(string Key)
        {
            var database = await GetRedisDatabase();
            int a = (int)database.ListLength(Key);
            var value = database.ListRange(Key, 0, -1);
            return value;
        }

        public async Task<long> SetListAsync(string key, string value)
        {
            var database = await GetRedisDatabase();
            return await  database.ListRightPushAsync(key, value);
        }



        private async Task<IDatabase> GetRedisDatabase()
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { "localhost" },
                Ssl = false,
                AbortOnConnectFail = false,
            };
            ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(config);
            return redis.GetDatabase(0);
        }
    }
}
