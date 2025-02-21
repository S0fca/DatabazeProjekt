using DatabazeProjekt.database;
using DatabazeProjekt.UI;
using System.Xml.Linq;

namespace DatabazeProjekt.Entities
{
    internal class ReportHandler
    {
        private static ReportsDAO reportsDAO = new ReportsDAO();

        /// <summary>
        /// gets all reports
        /// </summary>
        /// <returns>all reports</returns>
        public static List<Report> GetAllReports()
        {
            List<Report> reports = reportsDAO.GetAll().ToList();

            if (reports.Count == 0)
            {
                Console.WriteLine("No reports found.");
            }

            return reports;
        }

        /// <summary>
        /// adds report to a visit in DB
        /// </summary>
        /// <param name="id_vis">id of the visit</param>
        public static void AddReport(int id_vis)
        {
            string symptoms = UserInputManager.GetStringInput("Symptoms: ");
            string diagnosis = UserInputManager.GetStringInputOptional("Diagnosis: ");
            string recommendation = UserInputManager.GetStringInputOptional("Recommendation: ");
            string treatment = UserInputManager.GetStringInputOptional("Treatment: ");
            string conclusion = UserInputManager.GetStringInput("Conclusion: ");
            DateTime repDate = UserInputManager.GetDateInput("Report date DD-MM-YYYY: ");

            Report report = new Report()
            {
                Id_vis = id_vis,
                Symptoms = symptoms,
                Diagnosis = diagnosis,
                Recommendation = recommendation,
                Treatment = treatment,
                Conclusion = conclusion,
                Rep_dat = repDate
            };
            reportsDAO.Add(report);
        }

        /// <summary>
        /// adds reports from XML file
        /// </summary>
        /// <param name="file">file path</param>
        public static void AddReportXML(string file)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(file);

                foreach (var report in xmlDoc.Descendants("Report"))
                {
                    int visitId = int.Parse(report.Element("VisitId").Value);
                    string symptoms = report.Element("Symptoms").Value;
                    string conclusion = report.Element("Conclusion").Value;
                    DateTime reportDate = DateTime.Parse(report.Element("ReportDate").Value);

                    string? diagnosis = report.Element("Diagnosis")?.Value;
                    string? recommendation = report.Element("Recommendation")?.Value;
                    string? treatment = report.Element("Treatment")?.Value;
                    diagnosis = string.IsNullOrWhiteSpace(diagnosis) ? null : diagnosis;
                    recommendation = string.IsNullOrWhiteSpace(recommendation) ? null : recommendation;
                    treatment = string.IsNullOrWhiteSpace(treatment) ? null : treatment;

                    Report report1 = new Report
                    {
                        Id_vis = visitId,
                        Symptoms = symptoms,
                        Diagnosis = diagnosis,
                        Recommendation = recommendation,
                        Treatment = treatment,
                        Conclusion = conclusion,
                        Rep_dat = reportDate
                    };

                    Console.WriteLine(report1);

                    reportsDAO.Add(report1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing XML file: {ex.Message}");
            }
        }

    }
}
