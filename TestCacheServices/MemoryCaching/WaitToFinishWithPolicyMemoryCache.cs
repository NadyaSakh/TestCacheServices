using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestCacheServices
{
    public class WaitToFinishWithPolicyMemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 1024
        });
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public async Task<TItem> GetOrCreate(object key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    //if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = await createItem();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                //Size amount 
                                .SetSize(1)
                                //Priority on removing when reaching size limit (memory pressure)
                                .SetPriority(CacheItemPriority.High)
                                // Keep in cache for this time, reset time if accessed.
                                .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                                // Remove from cache after this time, regardless of sliding expiration
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                        _cache.Set(key, cacheEntry, cacheEntryOptions);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }

        public async Task<List<string>> GetOrCreate(Func<Task<List<string>>> query, string key)
        {
            List<string> cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = await query();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                //Size amount 
                                .SetSize(1)
                                //Priority on removing when reaching size limit (memory pressure)
                                .SetPriority(CacheItemPriority.High)
                                // Keep in cache for this time, reset time if accessed.
                                .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                                // Remove from cache after this time, regardless of sliding expiration
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                        _cache.Set(CacheKeys.CityList, cacheEntry, cacheEntryOptions);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }
    }

}
