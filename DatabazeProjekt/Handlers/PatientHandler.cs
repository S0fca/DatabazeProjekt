using DatabazeProjekt.database;
using DatabazeProjekt.UI;
using System.Text.RegularExpressions;

namespace DatabazeProjekt.Entities
{
    internal class PatientHandler
    {

        static PatientsDAO patientsDAO = new PatientsDAO();

        /// <summary>
        /// gets all patients
        /// </summary>
        /// <returns>all patients</returns>
        public static List<Patient> GetAllPatients()
        {
            List<Patient> patients = patientsDAO.GetAll().ToList();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }

            return patients;
        }

        /// <summary>
        /// gets patient info from the console
        /// </summary>
        /// <returns>patient</returns>
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

        /// <summary>
        /// gets info to edit patient
        /// edits patient in DB
        /// </summary>
        public static void EditPatientInfo()
        {

            Patient? patient = GetPatientByBirthNum();

            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            string? name = UserInputManager.GetStringInputOptional("First name: ");
            string? surname = UserInputManager.GetStringInputOptional("Surname: ");
            string? contact = UserInputManager.GetStringInputOptional("Contact: ");
            decimal? height = UserInputManager.GetDecimalInputOptional("Height: ");
            decimal? weight = UserInputManager.GetDecimalInputOptional("Weight");

            Patient editedPatint = new Patient()
            {
                Name = string.IsNullOrWhiteSpace(name) ? patient.Name : name,
                Surname = string.IsNullOrWhiteSpace(surname) ? patient.Surname : surname,
                Birth_dat = patient.Birth_dat,
                Birth_num = patient.Birth_num,
                Contact = string.IsNullOrWhiteSpace(contact) ? patient.Contact : contact,
                Height = (height is null) ? patient.Height : height,
                Weight = (weight is null) ? patient.Weight : weight,
            };

            editedPatint.Id = patient.Id;

            patientsDAO.Update(editedPatint);
            Console.WriteLine("Patient information updated.");
        }

        /// <summary>
        /// gets patient info
        /// adds the patient to DB
        /// </summary>
        public static void AddPatient()
        {
            patientsDAO.Add(GetPatientInfo());
        }

        /// <summary>
        /// gets patients birth number and patient with the birth number
        /// </summary>
        /// <returns>patient with a specific birth number</returns>
        public static Patient? GetPatientByBirthNum()
        {
            string birthNum = GetBirthNum();
            Patient patient = patientsDAO.GetAll().Where(x => x.Birth_num.Equals(birthNum)).FirstOrDefault();
            Console.WriteLine(patient);
            return patient;
        }

        /// <summary>
        /// gets birth number form console
        /// </summary>
        /// <returns>birth number</returns>
        private static string GetBirthNum()
        {
            string birthNum = "";
            do
            {
                birthNum = UserInputManager.GetStringInput("Patients birth number: ");
            } while (!Regex.IsMatch(birthNum, @"\d{6}\/\d{4}$"));
            return birthNum;
        }

        /// <summary>
        /// gets patient by id
        /// </summary>
        /// <param name="id">patients id</param>
        /// <returns>patient with specific id</returns>
        public static Patient? GetPatientById(int id)
        {
            return patientsDAO.GetById(id);
        }
    }
}
