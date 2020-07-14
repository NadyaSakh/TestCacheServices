using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using TestCacheServices.SqlConn;

namespace TestCacheServices
{
    class GetData
    {
        private static string shipCity;
        public static string queryCity(int orderId)
        {
            // Получить объект Connection подключенный к DB.
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                string sql = "Select ShipCity from Orders where OrderID=@orderid";

                // Создать объект Command.
                SqlCommand cmd = new SqlCommand();

                // Сочетать Command с Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = orderId;

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            shipCity = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Разрушить объект, освободить ресурс.
                conn.Dispose();
            }
            return shipCity;
        }
    }
}
