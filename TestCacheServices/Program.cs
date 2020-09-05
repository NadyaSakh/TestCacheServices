using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCacheServices.DistributeCaching;

namespace TestCacheServices
{
    class Program
    {
        //memoryCache
      /*  private static WaitToFinishMemoryCache<byte[]> _waitDataCache = new WaitToFinishMemoryCache<byte[]>();
        private static SimpleMemoryCache<byte[]> _simpleDataCache = new SimpleMemoryCache<byte[]>();
        private static MemoryCacheWithPolicy<byte[]> _policyDataCache = new MemoryCacheWithPolicy<byte[]>();
*/
        static void Main(string[] args)
        {

            /*// проверка кеша в памяти, вызывается список городов заказа
            Func<Task<List<string>>> queryGetCityListAsync = () => GetData.QueryGetCitiesAsync();
            Func<List<string>> queryGetCityList = () => GetData.QueryGetCities();

            var cities1 = _waitDataCache.GetOrCreate(queryGetCityListAsync, CacheKeys.CityList);
            var cities2 = _simpleDataCache.GetOrCreate(queryGetCityList, CacheKeys.CityList);
            var cities3 = _policyDataCache.GetOrCreate(queryGetCityList, CacheKeys.CityList);

            // проверка кеша в памяти, вызывается одна запись из табоицы заказы
            Func<Task<Dictionary<string, object>>> queryGetOrderInfoAsync = () => GetData.QueryGetOrderInfoAsync();
            var orderInfo = _waitDataCache.GetOrCreate(queryGetOrderInfoAsync, CacheKeys.OrderInfo);
            Dictionary<string, object> orderInfoDict = orderInfo.Result;

            foreach (KeyValuePair<string, object> keyValue in orderInfoDict)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            // проверка кеша в памяти, вызывается несколько записей из таблицы заказов
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
            }*/

            TestProductivity test = new TestProductivity();
            // замер времени извлечения из бд
            /*   test.measureGetCitiesFromDatabaseTime();
               test.measureGetOrderFromDatabaseTime();
               test.measureGetOrdersFromDatabaseTime();
   */
            // замер времени memoryCache для извлечения разных данных и стратегий 
            test.measureGetCityListTime();
            /*test.measureGetOrdersInfoTime();*/
            /*test.measureGetOrderInfoTime();*/

            /*  test.measureTest();*/
            Console.ReadKey();
        }
    }
}


