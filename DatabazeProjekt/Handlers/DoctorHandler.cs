using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class DoctorHandler
    {
        static DoctorsDAO doctorsDAO = new DoctorsDAO();

        /// <summary>
        /// gets all doctors
        /// </summary>
        /// <returns>all doctors</returns>
        public static List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = doctorsDAO.GetAll().ToList();

            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found.");
            }

            return doctors;
        }

        /// <summary>
        /// gets doctors surname and doctors with that surname
        /// </summary>
        /// <returns>doctors with specific surname</returns>
        public static List<Doctor> SearchDoctorBySurname()
        {
            string surname = UserInputManager.GetStringInput("Doctors surname: ");
            return doctorsDAO.GetBySurname(surname).ToList();
        }

        /// <summary>
        /// gets doctors information from console
        /// </summary>
        /// <returns>doctor</returns>
        public Doctor GetDoctorInfo()
        {
            string name = UserInputManager.GetStringInput("First name: ");
            string surname = UserInputManager.GetStringInput("Surname: ");
            string specialization = UserInputManager.GetStringInput("Specialization: ");

            Doctor doctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Specialization = specialization
            };

            return doctor;
        }

        public static Doctor? GetDoctorById(int id)
        {
            return doctorsDAO.GetById(id);
        }

    }
}
