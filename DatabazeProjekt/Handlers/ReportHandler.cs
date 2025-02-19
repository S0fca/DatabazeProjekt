using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class ReportHandler
    {
        private static ReportsDAO reportsDAO = new ReportsDAO();

        public static List<Report> GetAllReports()
        {
            return reportsDAO.GetAll().ToList();
        }

        public static void AddReport(int id_vis)
        {
            string symptoms = UserInputManager.GetStringInput("Symptoms: ");
            string diagnosis = UserInputManager.GetStringInputOptional("Diagnosis: ");
            string recommendation = UserInputManager.GetStringInputOptional("Recommendation: ");
            string treatment = UserInputManager.GetStringInputOptional("Treatment: ");
            string conclusion = UserInputManager.GetStringInput("Conclusion: ");
            DateTime repDate = UserInputManager.GetDateInput("Report date: ");

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

    }
}
