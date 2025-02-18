namespace DatabazeProjekt.Entities
{
    internal class VisitHandler
    {

        public static void AddVisit()
        {
            //Id_pat = id_pat;
            //Id_doc = id_doc;

            //Vis_reason = vis_reason;
            //Vis_dat = vis_dat;
            //Vis_price = vis_price;


            Patient patient = PatientHandler.GetPatientByBirthNum();

            Doctor doctor;

            List<Doctor> doctors = DoctorHandler.SearchDoctorBySurname();
            if (doctors.Count == 0)
            {
                Console.WriteLine("Doctor not found");
                return;
            }
            else if (doctors.Count == 1)
            {
                Console.WriteLine(doctors[0]);
                doctor = doctors[0];
            }
            else
            {
                for (int i = 0; i < (doctors.Count - 1); i++)
                {
                    Console.WriteLine(i + 1 + ". " + doctors[i]);
                }
                string num;
                int number;
                do
                {
                    Console.WriteLine("Which one: ");
                    num = Console.ReadLine().Trim();

                } while (string.IsNullOrWhiteSpace(num) || !int.TryParse(num, out number));
                doctor = doctors[number];
            }

            Console.WriteLine("Visit reason: ");
            string reason = Console.ReadLine();

            DateTime visitDate;
            while (true)
            {
                Console.WriteLine("Visit date and time (DD-MM-YYYY HH:mm): ");
                string input = Console.ReadLine().Trim();

                if (DateTime.TryParseExact(input, "dd-MM-yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out visitDate))
                {
                    Console.WriteLine($"You entered: {visitDate:dd-MM-yyyy HH:mm}");
                    break; // Exit loop if valid
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter the date and time as DD-MM-YYYY HH:mm.");
                }
            }

            decimal price;
            while (true)
            {
                Console.WriteLine("Visit price: ");
                string input = Console.ReadLine().Trim();

                if (decimal.TryParse(input, out price) && price >= 0)
                {
                    break; // Exit loop if valid
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid number (e.g., 50.00).");
                }
            }

            Visit visit = new Visit
            {
                Id_pat = patient.Id,
                Id_doc = doctor.Id,
                Vis_reason = reason,
                Vis_dat = visitDate,
                Vis_price = price
            };

            Console.WriteLine(visit);
        }

    }
}
