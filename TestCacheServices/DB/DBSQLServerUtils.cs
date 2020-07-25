using System.Data.SqlClient;

namespace TestCacheServices.SqlConn
{
    class DBSQLServerUtils
    {
        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            // Data Source=MSI\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                       + database + ";Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
