using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Application.Services
{
    public static class RedisCache
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpiredTime = null, TimeSpan? slidingExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpiredTime ?? TimeSpan.FromMinutes(10),
                SlidingExpiration = slidingExpireTime ?? TimeSpan.FromMinutes(5),
            };

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options, default);


        }

        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache, string recordId, JsonSerializerOptions options)
        {
            var jsonData = await cache.GetStringAsync(recordId);

            if(jsonData == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(jsonData, options);
        }
    }
}
