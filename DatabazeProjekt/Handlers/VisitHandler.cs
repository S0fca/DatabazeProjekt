using DatabazeProjekt.database;
using DatabazeProjekt.UI;
using System.Xml.Linq;

namespace DatabazeProjekt.Entities
{
    internal class VisitHandler
    {
        private static VisitsDAO visitsDAO = new VisitsDAO();

        public static List<Visit> GetAllVisits()
        {
            return visitsDAO.GetAll().ToList();
        }

        public static void AddVisit()
        {
            Patient? patient = PatientHandler.GetPatientByBirthNum();
            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

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
            visitsDAO.Add(visit);

            bool report = UserInputManager.GetBoolInput("Add report?");
            if (report)
            {
                ReportHandler.AddReport(visit.Id);
            }

        }

        public static List<Visit>? GetPatientsVisits()
        {
            Patient? patient = PatientHandler.GetPatientByBirthNum();
            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return null;
            }
            List<Visit> visits = visitsDAO.GetAll().Where(x => x.Id_pat == patient.Id).ToList();
            return visits;
        }

        public static Visit? GetVisit()
        {
            Visit? visit = null;
            Patient? patient = PatientHandler.GetPatientByBirthNum();
            if (patient is null)
            {
                Console.WriteLine("Patient not found.");
                return null;
            }
            DateTime visDat = UserInputManager.GetDateInput("Visits date: ");
            List<Visit> visits = visitsDAO.GetAll().Where(x => x.Id_pat == patient.Id).Where(x => x.Vis_dat == visDat).ToList();
            if (visits is null || visits.Count == 0)
            {
                Console.WriteLine("No visits fond.");
            }
            else if (visits is not null && visits.Count > 1)
            {
                for (int i = 1; i < visits.Count - 1; i++)
                {
                    Console.WriteLine(i + ". " + visits[i]);
                }
                visit = visits[UserInputManager.GetIntInput("Which one: ")];
            }
            else
            {
                visit = visits[0];
            }
            return visit;
        }

        public static Visit GetVisitById(int id)
        {
            return visitsDAO.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public static void AddVisitXML(string file)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(file);

                foreach (var visit in xmlDoc.Descendants("Visit"))
                {
                    int patientId = int.Parse(visit.Element("PatientId").Value);
                    int doctorId = int.Parse(visit.Element("DoctorId").Value);
                    string reason = visit.Element("Reason").Value;
                    DateTime visitDate = DateTime.Parse(visit.Element("VisitDate").Value);
                    decimal price = decimal.Parse(visit.Element("Price").Value);

                    Visit visit1 = new Visit
                    {
                        Id_pat = patientId,
                        Id_doc = doctorId,
                        Vis_reason = reason,
                        Vis_dat = visitDate,
                        Vis_price = price
                    };

                    Console.WriteLine(visit1);

                    visitsDAO.Add(visit1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing XML file: {ex.Message}");
            }
        }
    
    }
}
