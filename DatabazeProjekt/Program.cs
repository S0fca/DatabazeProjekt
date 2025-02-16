using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ClinicConsole console = new ClinicConsole();
            console.Start();

            //SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

            //DatabaseConnection.CloseConnection();
        }
    }
}
