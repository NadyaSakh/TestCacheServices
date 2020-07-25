using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;


namespace TestCacheServices
{
    public class MemoryCacheWithPolicy<TItem>
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 1024
        });

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            if (!_cache.TryGetValue(key, out TItem cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    //Size amount
                    .SetSize(1)
                    //Priority on removing when reaching size limit (memory pressure)
                    .SetPriority(CacheItemPriority.Normal)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    // Remove from cache after this time, regardless of sliding expiration
                    .SetAbsoluteExpiration(DateTime.Now.AddHours(6)); //TimeSpan.FromSeconds(10)

                // Save data in cache.
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }

        public List<string> GetOrCreate(Func<List<string>> query, string key)
        {
            if (!_cache.TryGetValue(key, out List<string> cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = query();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(1)//Size amount
                           //Priority on removing when reaching size limit (memory pressure)
                   .SetPriority(CacheItemPriority.High)
                   // Keep in cache for this time, reset time if accessed.
                   .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                   // Remove from cache after this time, regardless of sliding expiration
                   .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
    }
}
