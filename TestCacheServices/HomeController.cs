using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace TestCacheServices
{
    public class HomeController : Controller
    {
        private static IMemoryCache _memoryCache;
        private static IDistributedCache _distributedCache;
        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public static IMemoryCache GetMemoryCache()
        {
            return _memoryCache;
        }

        
        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public static IDistributedCache GetDistributedCache()
        {
            return _distributedCache;
        }

    }
}

