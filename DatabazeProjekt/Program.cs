using DatabazeProjekt.database;
using DatabazeProjekt.UI;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseConnection.GetDatabaseConnection();
                Console.WriteLine("Connection to the database was successful.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("The server was not found or was not accessible. ");
            }
            ClinicConsole console = new ClinicConsole();
            console.Start();
        }
    }
}
