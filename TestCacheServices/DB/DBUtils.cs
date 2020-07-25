using System.Data.SqlClient;

namespace TestCacheServices.SqlConn
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"MSI\SQLEXPRESS";
            string database = "Northwind";
            string username = "sa";
            string password = "1234";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
