using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class PatientHandler
    {

        static PatientsDAO patientsDAO = new PatientsDAO();

        public static List<Patient> GetAllPatients()
        {
            return patientsDAO.GetAll().ToList();
        }

        public Patient GetPatientInfo()
        {
            string name = UserInputManager.GetStringInput("First name: ");
            string surname = UserInputManager.GetStringInput("Surname: ");
            DateTime birthDate = UserInputManager.GetDateInput("Birth date: ");
            string birthNum = GetBirthNum();
            string contact = UserInputManager.GetStringInput("Contact: ");
            decimal height = UserInputManager.GetDecimalInput("Height: ");
            decimal weight = UserInputManager.GetDecimalInput("Weight");

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

        private void EditPatientInfo()
        {
            

            
        }

        public static Patient GetPatientByBirthNum()
        {
            string birthNum = GetBirthNum();

            return patientsDAO.GetByBirthNum(birthNum);
        }

        private static string GetBirthNum()
        {
            return UserInputManager.GetStringInput("Patients birth number: ");
        }

    }
}
