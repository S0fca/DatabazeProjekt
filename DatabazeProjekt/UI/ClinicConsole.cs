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
            mainMenu.AddMenuItem(new MenuItem("Import XML data", new Action(() => {
                //VisitHandler.AddVisitXML("visit.xml");
                ReportHandler.AddReportXML("report.xml");
            })));

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
                Console.WriteLine("Patients: ");
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
            })));
            patientMenu.AddMenuItem(new MenuItem("Search patient by birth number", new Action(() =>
            {
                Patient? patient = PatientHandler.GetPatientByBirthNum();
                if (patient is null)
                {
                    Console.WriteLine("Patient not found.");
                    return;
                }
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
                        Console.WriteLine(visit + "\n\tDoctor: " + visit.Doctor);
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
                Console.WriteLine("Doctors: ");
                foreach (Doctor doctor in DoctorHandler.GetAllDoctors())
                {
                    Console.WriteLine(doctor);
                }
            })));
            doctorMenu.AddMenuItem(new MenuItem("Search doctor by surname", new Action(() =>
            {
                List<Doctor> doctors = DoctorHandler.SearchDoctorBySurname();
                if (doctors is null || doctors.Count == 0)
                {
                    Console.WriteLine("No doctors found.");
                }
                else
                {
                    foreach (Doctor doctor in doctors)
                    {
                        Console.WriteLine(doctor);
                    }
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
                Console.WriteLine("Visits: ");
                foreach (Visit visit in VisitHandler.GetAllVisits())
                {
                    Console.WriteLine(visit + "\n\tPatient: " + visit.Patient + "\n\tDoctor: " + visit.Doctor);
                }
            })));
            visitsReportsMenu.AddMenuItem(new MenuItem("View reports", new Action(() =>
            {
                Console.WriteLine("Reports: ");
                foreach (Report report in ReportHandler.GetAllReports())
                {
                    Visit visit = VisitHandler.GetVisitById(report.Id_vis);

                    Console.WriteLine(report + "\n\tPatient: " + visit.Patient + "\n\tDoctor: " + visit.Doctor);
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
                Console.WriteLine("Tests: ");
                foreach (LabTest labTest in LabTestHandler.GetAllTests())
                {
                    Patient patient = PatientHandler.GetPatientById(labTest.Id_pat);
                    Console.WriteLine(labTest + "\n\tPatient: " + patient);
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
