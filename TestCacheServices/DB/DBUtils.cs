using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
