using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt
{
    internal class ClinicConsole
    {
        public void Start()
        {
            try
            {
                MainMenu();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Problem with access to DB.");
            }
            Console.WriteLine("End");
        }

        private void MainMenu()
        {
            Console.WriteLine("Welcome to the clinics database");
            /*
             * Co chcete udelat
             * sprava pacienta - pridat pacienta, Úprava údajů o pacientovi, Smazání pacienta, Vyhledání pacienta podle jména 
             * Správa lékařů - pridat lekare
             * Evidence návštěv - pridat navstevu (novy/stary pacient)
             * vytvorit zpravu (i s testem)
             * zapsat vysledek testu do db
             * 
             */
        }
    }
}
