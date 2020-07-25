using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace TestCacheServices
{
    public class HomeController : Controller
    {
        private static IMemoryCache _cache;

        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public static IMemoryCache getCache()
        {
            return _cache;
        }

    }
}

