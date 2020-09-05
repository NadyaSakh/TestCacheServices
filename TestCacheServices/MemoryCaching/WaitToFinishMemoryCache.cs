using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestCacheServices
{
    public class WaitToFinishMemoryCache<TItem>
    {
        private MemoryCache _cache;
        private ConcurrentDictionary<object, SemaphoreSlim> _locks;
        public WaitToFinishMemoryCache()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
            _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
            Console.WriteLine("Wait constructor ");
        }
        public async Task<TItem> GetOrCreate(object key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = await createItem();
                        _cache.Set(key, cacheEntry);
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
                Console.WriteLine(" NOT_IN_CACHE GET_VALUE_1");
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        Console.WriteLine(" NOT_IN_CACHE GET_VALUE_2");
                        // Key not in cache, so get data.
                        cacheEntry = await query();
                        _cache.Set(key, cacheEntry);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            Console.WriteLine(" END FUNCTION");
            return cacheEntry;
        }

        public async Task<Dictionary<string, object>> GetOrCreate(Func<Task<Dictionary<string, object>>> query, string key)
        {
            Dictionary<string, object> cacheEntry;

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
                        _cache.Set(key, cacheEntry);
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
            List<Dictionary<string, object>> cacheEntry;

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
                        _cache.Set(key, cacheEntry);
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
