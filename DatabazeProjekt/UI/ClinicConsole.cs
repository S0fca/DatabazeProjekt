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

        private Menu MenuPatients()
        {
            Menu patientMenu = new Menu("Select one option: ");

            patientMenu.AddMenuItem(new MenuItem("View all patients", new Action(() =>
            {
                foreach (Patient patient in PatientHandler.GetAllPatients())
                {
                    Console.WriteLine(patient);
                }
            })));
            patientMenu.AddMenuItem(new MenuItem("Add new patient", new Action(() =>
            {
                PatientHandler.AddPatient();
            })));
            patientMenu.AddMenuItem(new MenuItem("Edit patient information", new Action(() =>
            {
                PatientHandler.EditPatientInfo();
                Console.WriteLine("Patient information updated.");
            })));
            patientMenu.AddMenuItem(new MenuItem("Search patient by birth number", new Action(() =>
            {
                Patient? patient = PatientHandler.GetPatientByBirthNum();
                if (patient is null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }
                Console.WriteLine(patient);
            })));
            patientMenu.AddMenuItem(new MenuItem("View patients visits", new Action(() =>
            {
                List<Visit>? visits = VisitHandler.GetPatientsVisits();

                if (visits is not null && visits.Count == 0)
                {
                    Console.WriteLine("Patient has no visits.");
                }
                else if (visits is not null)
                {
                    foreach (Visit visit in visits)
                    {
                        Patient patient = PatientHandler.GetPatientById(visit.Id_pat);
                        Doctor doctor = DoctorHandler.GetDoctorById(visit.Id_doc);
                        Console.WriteLine(visit + " Doctor: " + doctor + "Patient: " + patient);
                    }
                }

            })));

            patientMenu.AddMenuItem(new MenuItem("Main menu", new Action(() => MainMenu())));

            return patientMenu;
        }

        private Menu MenuDoctors()
        {
            Menu doctorMenu = new Menu("Select one option: ");

            doctorMenu.AddMenuItem(new MenuItem("View all doctors", new Action(() =>
            {
                foreach (Doctor doctor in DoctorHandler.GetAllDoctors())
                {
                    Console.WriteLine(doctor);
                }
            })));
            doctorMenu.AddMenuItem(new MenuItem("Search doctor by surname", new Action(() =>
            {
                foreach (Doctor doctor in DoctorHandler.SearchDoctorBySurname())
                {
                    Console.WriteLine(doctor);
                }
            })));
            doctorMenu.AddMenuItem(new MenuItem("Main menu", new Action(() => MainMenu())));

            return doctorMenu;
        }

        private Menu MenuVisitsReports()
        {
            Menu visitsReportsMenu = new Menu("Select one option: ");

            visitsReportsMenu.AddMenuItem(new MenuItem("View visits", new Action(() =>
            {
                foreach (Visit visit in VisitHandler.GetAllVisits())
                {
                    Console.WriteLine(visit);
                }
            })));
            visitsReportsMenu.AddMenuItem(new MenuItem("View reports", new Action(() =>
            {
                foreach (Report report in ReportHandler.GetAllReports())
                {
                    Console.WriteLine(report);
                }
            })));
            visitsReportsMenu.AddMenuItem(new MenuItem("Add new visit", new Action(() =>
            {
                VisitHandler.AddVisit();
            })));
            visitsReportsMenu.AddMenuItem(new MenuItem("Create report for visit", new Action(() =>
            {
                Visit? visit = VisitHandler.GetVisit();

                if (visit is not null)
                {
                    ReportHandler.AddReport(visit.Id);
                }
            })));
            visitsReportsMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return visitsReportsMenu;
        }

        private Menu MenuTests()
        {
            Menu testsMenu = new Menu("Select one option: ");

            testsMenu.AddMenuItem(new MenuItem("View tests", new Action(() =>
            {
                foreach (LabTest labTest in LabTestHandler.GetAllTests())
                {
                    Console.WriteLine(labTest);
                }
            })));
            testsMenu.AddMenuItem(new MenuItem("Add new test", new Action(() =>
            {
                LabTestHandler.AddTest();
            })));
            testsMenu.AddMenuItem(new MenuItem("Main menu", new Action(() =>
            {
                MainMenu();
            })));

            return testsMenu;

        }

    }
}
