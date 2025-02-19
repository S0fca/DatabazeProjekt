using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class DoctorHandler
    {
        static DoctorsDAO doctorsDAO = new DoctorsDAO();

        public static List<Doctor> GetAllDoctors()
        {
            return doctorsDAO.GetAll().ToList();
        }

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

        public static List<Doctor> SearchDoctorBySurname()
        {
            string surname = UserInputManager.GetStringInput("Doctors surname: ");
            return doctorsDAO.GetAll().Where(x => x.Surname.Equals(surname)).ToList();
        }

        public static Doctor? GetDoctorById(int id)
        {
            return doctorsDAO.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
