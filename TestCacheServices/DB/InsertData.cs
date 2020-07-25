using System;
using System.Data;
using System.Data.SqlClient;

namespace TestCacheServices
{
    class InsertData
    {
        public static void Insert(SqlConnection connection)
        {
            try
            {
                // Команда Insert
                string sql = "Insert into Orders (  OrderDate" +
                    //   "RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity," +
                    //   " ShipRegion, ShipPostalCode, ShipCountry" +
                    ") "
                + " values ( @orderdate) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                //SqlParameter orderID = new SqlParameter("@orderid", SqlDbType.Int);
                //orderID.Value = 11078;
                //cmd.Parameters.Add(orderID);

                //SqlParameter emploeeID = cmd.Parameters.Add("@emploeeid", SqlDbType.Int);
                //emploeeID.Value = 1;

                //cmd.Parameters.Add("@customerid", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@orderdate", SqlDbType.Date).Value = "12.12.2012";

                // Выполнить Command (Используется для delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
