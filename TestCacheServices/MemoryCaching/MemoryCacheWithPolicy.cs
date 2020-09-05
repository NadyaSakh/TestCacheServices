using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestCacheServices
{
    public class MemoryCacheWithPolicy<TItem>
    {
        private readonly MemoryCache _cache;
        public MemoryCacheWithPolicy()
        {
            _cache = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
            Console.WriteLine("MemoryCacheWithPolicy ");
        }


        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            if (!_cache.TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(1)
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(1));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public async Task<List<string>> GetOrCreate(Func<Task<List<string>>> query, string key)
        {
            if (!_cache.TryGetValue(key, out List<string> cacheEntry))
            {
                Console.WriteLine(" NOT_IN_CACHE GET_VALUE_1");
                cacheEntry = await query();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(1)//Size amount
                           //Priority on removing when reaching size limit (memory pressure)
                   .SetPriority(CacheItemPriority.High)
                   // Keep in cache for this time, reset time if accessed.
                   .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                   // Remove from cache after this time, regardless of sliding expiration
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            Console.WriteLine(" END FUNCTI");
            return cacheEntry;
        }

        public async Task<List<Dictionary<string, object>>> GetOrCreate(Func<Task<List<Dictionary<string, object>>>> query, string key)
        {
            if (!_cache.TryGetValue(key, out List<Dictionary<string, object>> cacheEntry))
            {
                cacheEntry = await query();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
               .SetSize(1)
                  .SetPriority(CacheItemPriority.High)
                  .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                  .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public async Task<Dictionary<string, object>> GetOrCreate(Func<Task<Dictionary<string, object>>> query, string key)
        {
            if (!_cache.TryGetValue(key, out Dictionary<string, object> cacheEntry))
            {
                cacheEntry = await query();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
               .SetSize(1)
                  .SetPriority(CacheItemPriority.High)
                  .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                  .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public void cleanCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
