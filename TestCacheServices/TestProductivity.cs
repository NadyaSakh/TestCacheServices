using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TestCacheServices
{
    class TestProductivity
    {
        private static WaitToFinishMemoryCache<byte[]> _waitDataCache = new WaitToFinishMemoryCache<byte[]>();
        private static SimpleMemoryCache<byte[]> _simpleDataCache = new SimpleMemoryCache<byte[]>();
        private static MemoryCacheWithPolicy<byte[]> _policyDataCache = new MemoryCacheWithPolicy<byte[]>();
        public static void getTime()
        {
            Func<Task<List<string>>> queryAsync = () => GetData.QueryGetCitiesAsync();
            Func<List<string>> query = () => GetData.QueryGetCities();
            
            // измеряется время выполнение метода
            Stopwatch stopWatch = Stopwatch.StartNew();
            var cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.CityList);
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;

            stopWatch = Stopwatch.StartNew();
            var cities2 = _simpleDataCache.GetOrCreate(query, CacheKeys.CityList);
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;

            stopWatch = Stopwatch.StartNew();
            var cities3 = _policyDataCache.GetOrCreate(query, CacheKeys.CityList);
            stopWatch.Stop();
            TimeSpan ts3 = stopWatch.Elapsed;

            Utils.showEllapsedTime(ts1);
            Utils.showEllapsedTime(ts2);
            Utils.showEllapsedTime(ts3);

        }
    }
}
