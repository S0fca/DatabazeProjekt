using DatabazeProjekt.database;
using DatabazeProjekt.UI;
using System.Text.RegularExpressions;

namespace DatabazeProjekt.Entities
{
    internal class PatientHandler
    {

        static PatientsDAO patientsDAO = new PatientsDAO();

        public static List<Patient> GetAllPatients()
        {
            return patientsDAO.GetAll().ToList();
        }

        public static Patient GetPatientInfo()
        {
            string name = UserInputManager.GetStringInput("First name: ");
            string surname = UserInputManager.GetStringInput("Surname: ");
            DateTime birthDate = UserInputManager.GetDateInput("Birth date DD-MM-YYYY: ");
            string birthNum = GetBirthNum();
            string contact = UserInputManager.GetStringInput("Contact: ");
            decimal? height = UserInputManager.GetDecimalInputOptional("Height: ");
            decimal? weight = UserInputManager.GetDecimalInputOptional("Weight");

            Patient patient = new Patient
            {
                Name = name,
                Surname = surname,
                Birth_dat = birthDate,
                Birth_num = birthNum,
                Contact = contact,
                Height = height,
                Weight = weight
            };

            return patient;
        }

        public static void EditPatientInfo()
        {

            Patient? patient = GetPatientByBirthNum();
            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }
            Console.WriteLine(patient);
            Patient editedPatint = GetPatientInfo();
            editedPatint.Id = patient.Id;

            patientsDAO.Update(editedPatint);

        }

        public static void AddPatient()
        {
            patientsDAO.Add(GetPatientInfo());
        }

        public static Patient? GetPatientByBirthNum()
        {
            string birthNum = GetBirthNum();
            Patient patient = patientsDAO.GetAll().Where(x => x.Birth_num.Equals(birthNum)).FirstOrDefault();
            Console.WriteLine(patient);
            return patient;
        }

        private static string GetBirthNum()
        {
            string birthNum = "";
            do
            {
                birthNum = UserInputManager.GetStringInput("Patients birth number: ");
            } while (!Regex.IsMatch(birthNum, @"\d{6}\/\d{4}$"));
            return birthNum;
        }

        public static Patient? GetPatientById(int id)
        {
            return patientsDAO.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
