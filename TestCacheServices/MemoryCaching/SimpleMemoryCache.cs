using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestCacheServices
{
    public class SimpleMemoryCache<TItem>
    {
        private MemoryCache _cache;
        public SimpleMemoryCache()
        {
             _cache = new MemoryCache(new MemoryCacheOptions());
            Console.WriteLine("SimpleConstructor ");
        }
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
                Console.WriteLine(" NOT_IN_CACHE GET_VALUE_1");
                cacheEntry = query();
                _cache.Set(key, cacheEntry);
            }
            Console.WriteLine(" END FUNC");
            return cacheEntry;
        }

        public async Task<List<string>> GetOrCreate(Func<Task<List<string>>> query, string key)
        {
            List<string> cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                Console.WriteLine(" NOT_IN_CACHE GET_VALUE_1");
                cacheEntry = await query();
                _cache.Set(key, cacheEntry);
            }
            Console.WriteLine(" END FUNC");
            return cacheEntry;
        }

        public async Task<List<Dictionary<string, object>>> GetOrCreate(Func<Task<List<Dictionary<string, object>>>> query, string key)
        {
            List<Dictionary<string, object>> cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {          
                 cacheEntry = await query();
                 _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }

        public async Task<Dictionary<string, object>> GetOrCreate(Func<Task<Dictionary<string, object>>> query, string key)
        {
            Dictionary<string, object> cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                cacheEntry = await query();
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }

        public void cleanCache(string key)
        {
            _cache.Remove(key);
        }
    }
}
