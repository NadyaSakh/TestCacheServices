using System;
using System.Threading.Tasks;
using TestCacheServices.SqlConn;

namespace TestCacheServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var _waitDataCache = new WaitToFinishMemoryCache<byte[]>();
            var _simpleDataCache = new SimpleMemoryCache<byte[]>();
            var _policyDataCache = new MemoryCacheWithPolicy<byte[]>();

            //InsertData.Insert();

            int orderId = 11077;
            string shipCity = GetData.queryCity(orderId);
            Console.WriteLine("shipCity:" + shipCity);


            Func<int, string> query = orderId => GetData.queryCity(orderId);

            // TODO Сделать передачу параметра в GetOrCreate
            var city1 = _waitDataCache.GetOrCreate(orderId, new Task<byte[]>(() => query());
            //  var city2 = _simpleDataCache.GetOrCreate(orderId, () => GetData.queryCity(orderId));
             // var city3 = _policyDataCache.GetOrCreate(orderId, () => GetData.queryCity(orderId));

            Console.ReadKey();
        }
    }
}