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
        private MemoryCache _cache;
        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks;
        public WaitToFinishWithPolicyMemoryCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
            _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
            Console.WriteLine("WaitPolicyConstructor ");
        }

        public async Task<TItem> GetOrCreate(object key, Func<Task<TItem>> createItem)
        {
            if (!_cache.TryGetValue(key, out TItem cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        cacheEntry = await createItem();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSize(1)
                                .SetPriority(CacheItemPriority.High)
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
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
            if (!_cache.TryGetValue(key, out List<string> cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        cacheEntry = await query();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSize(1)
                                .SetPriority(CacheItemPriority.High)
                                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

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

        public async Task<List<Dictionary<string, object>>> GetOrCreate(Func<Task<List<Dictionary<string, object>>>> query, string key)
        {
            if (!_cache.TryGetValue(key, out List<Dictionary<string, object>> cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        cacheEntry = await query();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSize(1)
                                .SetPriority(CacheItemPriority.High)
                                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

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

        public async Task<Dictionary<string, object>> GetOrCreate(Func<Task<Dictionary<string, object>>> query, string key)
        {
            if (!_cache.TryGetValue(key, out Dictionary<string, object> cacheEntry))
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        cacheEntry = await query();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSize(1)
                                .SetPriority(CacheItemPriority.High)
                                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

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

        public void cleanCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
