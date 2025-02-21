using Microsoft.Data.SqlClient;
using System.Configuration;

namespace DatabazeProjekt.database
{
    internal class DatabaseConnection
    {
        private static SqlConnection? conn = null;

        private DatabaseConnection()
        {
        }

        public static SqlConnection GetDatabaseConnection()
        {
            if (conn == null)
            {
                string connstring = $"Data Source={ConfigurationManager.AppSettings["DataSource"]};Initial Catalog={ConfigurationManager.AppSettings["InitialCatalog"]};User ID={ConfigurationManager.AppSettings["UserID"]};Password={ConfigurationManager.AppSettings["Password"]};Connect Timeout=10;Trust Server Certificate=True";
                conn = new SqlConnection(connstring);
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
