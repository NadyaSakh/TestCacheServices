using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestCacheServices
{
    class Program
    {
        private static WaitToFinishMemoryCache<byte[]> _waitDataCache = new WaitToFinishMemoryCache<byte[]>();
        private static SimpleMemoryCache<byte[]> _simpleDataCache = new SimpleMemoryCache<byte[]>();
        private static MemoryCacheWithPolicy<byte[]> _policyDataCache = new MemoryCacheWithPolicy<byte[]>();
        static void Main(string[] args)
        {
            /*Func<Task<List<string>>> queryGetCityListAsync = () => GetData.QueryGetCitiesAsync();
            Func<List<string>> queryGetCityList = () => GetData.QueryGetCities();

            var cities1 = _waitDataCache.GetOrCreate(queryGetCityListAsync, CacheKeys.CityList);
            var cities2 = _simpleDataCache.GetOrCreate(queryGetCityList, CacheKeys.CityList);
            var cities3 = _policyDataCache.GetOrCreate(queryGetCityList, CacheKeys.CityList);

            Func<Task<Dictionary<string, object>>> queryGetOrderInfoAsync = () => GetData.QueryGetOrderInfoAsync();
            var orderInfo = _waitDataCache.GetOrCreate(queryGetOrderInfoAsync, CacheKeys.OrderInfo);
            Dictionary<string, object> orderInfoDict = orderInfo.Result;

            foreach (KeyValuePair<string, object> keyValue in orderInfoDict)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }*/

            Func<Task<List<Dictionary<string, object>>>> queryGetOrdersInfoAsync = () => GetData.QueryGetOrdersInfoAsync();
            var ordersInfo = _waitDataCache.GetOrCreate(queryGetOrdersInfoAsync, CacheKeys.OrdersInfo);
            List<Dictionary<string, object>> ordersInfoList = ordersInfo.Result;

            foreach (Dictionary<string, object> dict in ordersInfoList)
            {
                foreach (KeyValuePair<string, object> keyValue in dict)
                {
                    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                }
                Console.WriteLine(" -------------------------------------");
            }
            //int orderId = 11077;
            /*
            List<string> res = cities1.Result;
            List<string> res1 = cities2;
            List<string> res2 = cities3;

             foreach (string item in res)
             {
                 Console.WriteLine(item);
             }*/

            Console.ReadKey();
        }
    }
}