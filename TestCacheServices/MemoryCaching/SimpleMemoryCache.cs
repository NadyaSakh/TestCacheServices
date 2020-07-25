using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;


namespace TestCacheServices
{
    public class SimpleMemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TItem GetOrCreate(Func<TItem> createItem, object key)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();
                // Save data in cache.
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }

        public List<string> GetOrCreate(Func<List<string>> query, string key)
        {
            List<string> cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                cacheEntry = query();
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }
}
