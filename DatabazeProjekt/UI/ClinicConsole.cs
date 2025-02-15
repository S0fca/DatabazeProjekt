using Microsoft.Data.SqlClient;
using Mineraly.UserInterface;

namespace DatabazeProjekt.UI
{
    internal class ClinicConsole
    {

        private bool exit = false;

        public void Start()
        {
            try
            {
                MainMenu();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Problem with accessing database");
            }
            Console.WriteLine("End");
        }

        private void MainMenu()
        {
            Console.WriteLine("Welcome to the clinics database");

            Menu mainMenu = new Menu("Select one option: ");

            mainMenu.AddMenuItem(new MenuItem("Manage patients",
                new Action(() =>
                {
                    var menu = MenuPatients();
                    var item = menu.GetMenuItem();
                    item.Execute();
                })));
            mainMenu.AddMenuItem(new MenuItem("Manage doctors",
                new Action(() =>
                {
                    var menu = MenuDoctors();
                    var item = menu.GetMenuItem();
                    item.Execute();
                })));
            mainMenu.AddMenuItem(new MenuItem("Manage visits and reports",
                new Action(() =>
                {
                    var menu = MenuVisitsReports();
                    var item = menu.GetMenuItem();
                    item.Execute();
                })));
            mainMenu.AddMenuItem(new MenuItem("Manage laboratory tests",
                new Action(() =>
                {
                    var menu = MenuTests();
                    var item = menu.GetMenuItem();
                    item.Execute();
                })));
            mainMenu.AddMenuItem(new MenuItem("Exit program", new Action(() => { exit = true; })));

            while (!exit)
            {
                var item = mainMenu.GetMenuItem();
                item.Execute();
            }
        }

        private Menu MenuTests()
        {
            throw new NotImplementedException();
        }

        private Menu MenuVisitsReports()
        {
            throw new NotImplementedException();
        }

        private Menu MenuDoctors()
        {
            throw new NotImplementedException();
        }

        private Menu MenuPatients()
        {
            throw new NotImplementedException();
        }
    }
}
