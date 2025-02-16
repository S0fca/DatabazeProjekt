using DatabazeProjekt.database;
using DatabazeProjekt.Entities;
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
                Console.WriteLine(e.Message);//
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
        #region Patient
        private Menu MenuPatients()
        {
            Menu patientMenu = new Menu("Select one option: ");

            patientMenu.AddMenuItem(new MenuItem("Add new patient", new Action(() =>
            {
                AddNewPatient();
            })));

            patientMenu.AddMenuItem(new MenuItem("Edit patient information", new Action(() =>
            {
                EditPatientInfo();
            })));

            patientMenu.AddMenuItem(new MenuItem("Delete patient", new Action(() =>
            {
                DeletePatient();
            })));

            patientMenu.AddMenuItem(new MenuItem("Search patient by name", new Action(() =>
            {
                SearchPatientByName();
            }))); 

            //pacientovy zpravy
            //navstevy
            //testy

            patientMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return patientMenu;
        }

        private void AddNewPatient()
        {
            throw new NotImplementedException();
        }

        private void EditPatientInfo()
        {
            throw new NotImplementedException();
        }

        private void DeletePatient()
        {
            throw new NotImplementedException();
        }

        private void SearchPatientByName()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Doctor
        private Menu MenuDoctors()
        {
            Menu doctorMenu = new Menu("Select one option: ");

            doctorMenu.AddMenuItem(new MenuItem("Add new doctor", new Action(() =>
            {
                AddNewDoctor();
            })));
            doctorMenu.AddMenuItem(new MenuItem("Edit doctor information", new Action(() =>
            {
                EditDoctorInfo();
            })));
            doctorMenu.AddMenuItem(new MenuItem("Search doctor by surname", new Action(() =>
            {
                SearchDoctorBySurname();
            })));
            doctorMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return doctorMenu;
        }

        private void AddNewDoctor()
        {
            Console.WriteLine("First name: ");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine().Trim();

            Console.WriteLine("Specialization: ");
            string specialization = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(specialization))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Doctor newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Specialization = specialization
            };

            DoctorsDAO doctorsDAO = new DoctorsDAO();
            doctorsDAO.Add(newDoctor);
        }

        private void EditDoctorInfo()
        {
            DoctorsDAO doctorsDAO = new DoctorsDAO();

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

        private void SearchDoctorBySurname()
        {
            Console.WriteLine("Doctors surname: ");
            string surname = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            DoctorsDAO doctorsDAO = new DoctorsDAO();

            string doctors = string.Join(',', doctorsDAO.GetBySurname(surname));

            Console.WriteLine(doctors);

        }
        #endregion

        #region VisitsAndReports
        private Menu MenuVisitsReports()
        {
            Menu visitsReportsMenu = new Menu("Select one option: ");

            visitsReportsMenu.AddMenuItem(new MenuItem("Add new visit", new Action(() =>
            {
                AddNewVisit();
            })));

            visitsReportsMenu.AddMenuItem(new MenuItem("Create report for visit", new Action(() =>
            {
                CreateReportForVisit();
            })));

            //upravit navstevu
            //upravit zpravu

            visitsReportsMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return visitsReportsMenu;
        
        }

        private void AddNewVisit()
        {
            throw new NotImplementedException();
        }

        private void CreateReportForVisit()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Tests
        private Menu MenuTests()
        {
            Menu testsMenu = new Menu("Select one option: ");
            
            testsMenu.AddMenuItem(new MenuItem("Add new test", new Action(() =>
            {
                AddNewTest();
            })));

            testsMenu.AddMenuItem(new MenuItem("Add test result", new Action(() =>
            {
                AddNewTestResult();
            })));

            testsMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return testsMenu;

        }

        private void AddNewTest()
        {
            throw new NotImplementedException();
        }

        private void AddNewTestResult()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
