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

        private void EditDoctorInfo()
        {
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine().Trim();

            List<Doctor> matchingDoctors = doctorsDAO.GetBySurname(surname).ToList();

            if (!matchingDoctors.Any())
            {
                Console.WriteLine($"No doctor found with surname {surname}.");
                return;
            }

            foreach (Doctor doctor in matchingDoctors)
            {
                Console.WriteLine($"Editing doctor: {doctor.Name} {doctor.Surname}, Specialization: {doctor.Specialization}");
                Console.WriteLine("leave empty to keep");

                Console.WriteLine("New first name: ");
                string newName = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(newName)) doctor.Name = newName;

                Console.WriteLine("New surname: ");
                string newSurname = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(newSurname)) doctor.Surname = newSurname;

                Console.WriteLine("New specialization: ");
                string newSpecialization = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(newSpecialization)) doctor.Specialization = newSpecialization;

                doctorsDAO.Update(doctor);

                Console.WriteLine("Doctor information updated successfully.");
            }
        }

        public static List<Doctor> SearchDoctorBySurname()
        {
            string surname = UserInputManager.GetStringInput("Doctors surname: ");
            return doctorsDAO.GetBySurname(surname).ToList();
        }

    }
}
