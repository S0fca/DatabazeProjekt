using DatabazeProjekt.database;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

            DatabaseConnection.CloseConnection();
        }
    }
}
