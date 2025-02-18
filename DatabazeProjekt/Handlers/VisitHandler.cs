using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class VisitHandler
    {

        public static void AddVisit()
        {
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
                int number = 0;
                do
                {
                    number = UserInputManager.GetIntInput("Which one: ");
                } while (number <= 0 || number > doctors.Count);
                doctor = doctors[number - 1];
            }

            string reason = UserInputManager.GetStringInput("Visit reason: ");

            DateTime visitDate = UserInputManager.GetDateInput("Visit date and time (DD-MM-YYYY HH:mm): ");

            decimal price = 0;
            do
            {
                price = UserInputManager.GetDecimalInput("Visit price: ");
            } while (price < 0);

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
