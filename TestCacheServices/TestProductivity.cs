using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TestCacheServices
{
    class TestProductivity
    {
        private static WaitToFinishMemoryCache<byte[]> _waitDataCache;
        private static SimpleMemoryCache<byte[]> _simpleDataCache;
        private static MemoryCacheWithPolicy<byte[]> _policyDataCache;
        private static WaitToFinishWithPolicyMemoryCache<byte[]> _waitAndPolicyCache;
        
        public TestProductivity()
        {
            _waitDataCache = new WaitToFinishMemoryCache<byte[]>();
            _simpleDataCache = new SimpleMemoryCache<byte[]>();
            _policyDataCache = new MemoryCacheWithPolicy<byte[]>();
            _waitAndPolicyCache = new WaitToFinishWithPolicyMemoryCache<byte[]>();
        }
        public void measureGetCityListTime()
        {
            Func<Task<List<string>>> queryAsync = () => GetData.QueryGetCitiesAsync();
            Func<List<string>> query = () => GetData.QueryGetCities();

            Stopwatch stopWatch;
            /* stopWatch = Stopwatch.StartNew();
             var cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.CityListWait);
             stopWatch.Stop();
             TimeSpan ts1 = stopWatch.Elapsed;

             Console.WriteLine(" measureGetCityListTime");
             Console.WriteLine("_waitDataCache ");
             Utils.showEllapsedTime(ts1);

             System.Threading.Thread.Sleep(3000);

             stopWatch = Stopwatch.StartNew();
             cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.CityListWait);
             stopWatch.Stop();
             TimeSpan ts11 = stopWatch.Elapsed;

             Console.WriteLine("_waitDataCache 2");
             Utils.showEllapsedTime(ts11);*/
            //
            stopWatch = Stopwatch.StartNew();
            var cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.CityList);
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;

            Console.WriteLine("_simpleDataCache ");
            Utils.showEllapsedTime(ts2);
            System.Threading.Thread.Sleep(3000);

            stopWatch = Stopwatch.StartNew();
            cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.CityList);
            stopWatch.Stop();
            TimeSpan ts22 = stopWatch.Elapsed;

            Console.WriteLine("_simpleDataCache 2");
            Utils.showEllapsedTime(ts22);
            //
            /*            stopWatch = Stopwatch.StartNew();
                        var cities3 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.CityListPolicy);
                        stopWatch.Stop();
                        TimeSpan ts3 = stopWatch.Elapsed;

                        Console.WriteLine("_policyDataCache ");
                        Utils.showEllapsedTime(ts3);

                        System.Threading.Thread.Sleep(3000);

                        stopWatch = Stopwatch.StartNew();
                        var cities33 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.CityListPolicy);
                        stopWatch.Stop();
                        TimeSpan ts33 = stopWatch.Elapsed;

                        Console.WriteLine("_policyDataCache 2");
                        Utils.showEllapsedTime(ts33);*/
            //
            /* stopWatch = Stopwatch.StartNew();
             var cities4 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.CityListWaitAndPolicy);
             stopWatch.Stop();
             TimeSpan ts4 = stopWatch.Elapsed;

             Console.WriteLine("_waitAndPolicyCache ");
             Utils.showEllapsedTime(ts4);

             System.Threading.Thread.Sleep(3000);

             stopWatch = Stopwatch.StartNew();
             cities4 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.CityListWaitAndPolicy);
             stopWatch.Stop();
             TimeSpan ts44 = stopWatch.Elapsed;

             Console.WriteLine("_waitAndPolicyCache 2");
             Utils.showEllapsedTime(ts44);*/
        }

        public void measureGetOrdersInfoTime()
        {
            static Task<List<Dictionary<string, object>>> queryAsync() => GetData.QueryGetOrdersInfoAsync();

             Stopwatch stopWatch;
/*            stopWatch = Stopwatch.StartNew();
            var cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoWait);
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;
        
            System.Threading.Thread.Sleep(5000);
            stopWatch = Stopwatch.StartNew();
            cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoWait);
            stopWatch.Stop();
            TimeSpan ts11 = stopWatch.Elapsed;*/
            //

            /*  System.Threading.Thread.Sleep(5000);
              stopWatch = Stopwatch.StartNew();
              var cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfo);
              stopWatch.Stop();
              TimeSpan ts2 = stopWatch.Elapsed;

              System.Threading.Thread.Sleep(5000);
              stopWatch = Stopwatch.StartNew();
              cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfo);
              stopWatch.Stop();
            TimeSpan ts22 = stopWatch.Elapsed;*/
            //
            /* System.Threading.Thread.Sleep(5000);
             stopWatch = Stopwatch.StartNew();
             var cities3 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoPolicy);
             stopWatch.Stop();
             TimeSpan ts3 = stopWatch.Elapsed;

             System.Threading.Thread.Sleep(5000);
             stopWatch = Stopwatch.StartNew();
             cities3 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoPolicy);
             stopWatch.Stop();
             TimeSpan ts33 = stopWatch.Elapsed;*/
            //

            System.Threading.Thread.Sleep(5000);
            stopWatch = Stopwatch.StartNew();
            var cities4 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoWaitAndPolicy);
            stopWatch.Stop();
            TimeSpan ts4 = stopWatch.Elapsed;

            System.Threading.Thread.Sleep(5000);
            stopWatch = Stopwatch.StartNew();
            var cities44 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoWaitAndPolicy);
            stopWatch.Stop();
            TimeSpan ts44 = stopWatch.Elapsed;

            System.Threading.Thread.Sleep(5000);
            stopWatch = Stopwatch.StartNew();
            var cities444 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.OrdersInfoWaitAndPolicy);
            stopWatch.Stop();
            TimeSpan ts444 = stopWatch.Elapsed;

            /* Console.WriteLine(" measureGetOrdersInfoTime");
             Console.WriteLine("_waitDataCache ");
             Utils.showEllapsedTime(ts1);
             Utils.showEllapsedTime(ts11);*/

            /*   Console.WriteLine("_simpleDataCache ");
               Utils.showEllapsedTime(ts2);
               Utils.showEllapsedTime(ts22);*/

            /*  Console.WriteLine("_policyDataCache ");
              Utils.showEllapsedTime(ts3);
              Utils.showEllapsedTime(ts33);*/

            Console.WriteLine("_waitAndPolicyCache ");
            Utils.showEllapsedTime(ts4);
            Utils.showEllapsedTime(ts44);
            Utils.showEllapsedTime(ts444);
        }

        public void measureGetOrderInfoTime()
        {
            static Task<Dictionary< string, object>> queryAsync() => GetData.QueryGetOrderInfoAsync();

            Stopwatch stopWatch;
            /* stopWatch = Stopwatch.StartNew();
             var cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoWait);
             stopWatch.Stop();
             TimeSpan ts1 = stopWatch.Elapsed;

             Console.WriteLine("measureGetOrderInfoTime ");
             Console.WriteLine("_waitDataCache ");
             Utils.showEllapsedTime(ts1);

             System.Threading.Thread.Sleep(3000);
             stopWatch = Stopwatch.StartNew();
             cities1 = _waitDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoWait);
             stopWatch.Stop();
             TimeSpan ts11 = stopWatch.Elapsed;

             Console.WriteLine("measureGetOrderInfoTime ");
             Console.WriteLine("_waitDataCache 2");
             Utils.showEllapsedTime(ts11);*/
            //
            /*  System.Threading.Thread.Sleep(3000);
              stopWatch = Stopwatch.StartNew();
              var cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfo);
              stopWatch.Stop();
              TimeSpan ts2 = stopWatch.Elapsed;

              Console.WriteLine("_simpleDataCache ");
              Utils.showEllapsedTime(ts2);

              System.Threading.Thread.Sleep(3000);
              stopWatch = Stopwatch.StartNew();
              cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfo);
              stopWatch.Stop();
              TimeSpan ts22 = stopWatch.Elapsed;

              Console.WriteLine("_simpleDataCache 2");
              Utils.showEllapsedTime(ts22);*/
            //
            /* System.Threading.Thread.Sleep(3000);
             stopWatch = Stopwatch.StartNew();
             var cities3 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoPolicy);
             stopWatch.Stop();
             TimeSpan ts3 = stopWatch.Elapsed;

             Console.WriteLine("_policyDataCache ");
             Utils.showEllapsedTime(ts3);

             System.Threading.Thread.Sleep(3000);

             stopWatch = Stopwatch.StartNew();
             cities3 = _policyDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoPolicy);
             stopWatch.Stop();
             TimeSpan ts33 = stopWatch.Elapsed;

             Console.WriteLine("_policyDataCache ");
             Utils.showEllapsedTime(ts33);*/
            //
            System.Threading.Thread.Sleep(3000);
            stopWatch = Stopwatch.StartNew();
            var cities4 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoWaitAndPolicy);
            stopWatch.Stop();
            TimeSpan ts4 = stopWatch.Elapsed;

            Console.WriteLine("_waitAndPolicyCache ");
            Utils.showEllapsedTime(ts4);

            System.Threading.Thread.Sleep(3000);

            stopWatch = Stopwatch.StartNew();
            cities4 = _waitAndPolicyCache.GetOrCreate(queryAsync, CacheKeys.OrderInfoWaitAndPolicy);
            stopWatch.Stop();
            TimeSpan ts44 = stopWatch.Elapsed;

            Console.WriteLine("_waitAndPolicyCache ");
            Utils.showEllapsedTime(ts44);
        }
        public async void measureGetCitiesFromDatabaseTime()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            await GetData.QueryGetCitiesAsync();
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;

            Console.WriteLine("measureGetCitiesFromDatabaseTime ");
            Utils.showEllapsedTime(ts1);
        }

        public async void measureGetOrdersFromDatabaseTime()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            await GetData.QueryGetOrdersInfoAsync();
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;

            Console.WriteLine("measureGetOrdersFromDatabaseTime ");
            Utils.showEllapsedTime(ts1);
        }

        public async void measureGetOrderFromDatabaseTime()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            await GetData.QueryGetOrderInfoAsync();
            stopWatch.Stop();
            TimeSpan ts1 = stopWatch.Elapsed;

            Console.WriteLine("measureGetOrderFromDatabaseTime ");
            Utils.showEllapsedTime(ts1);
        }

        public void measureTest()
        {
            static Task<Dictionary<string, object>> queryAsync() => GetData.QueryGetOrderInfoAsync();

            Stopwatch stopWatch = Stopwatch.StartNew();
            var cities2 = _simpleDataCache.GetOrCreate(queryAsync, CacheKeys.OrderInfo);
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;

            Console.WriteLine("measureTest ");
            Console.WriteLine("_policyDataCache ");
            Utils.showEllapsedTime(ts2);
        }
    }
}
