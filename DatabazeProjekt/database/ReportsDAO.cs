using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabazeProjekt.database
{
    internal class ReportsDAO : IGenericDAO<Report>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        /// <summary>
        /// adds report to the database
        /// </summary>
        /// <param name="entity">report to add to the database</param>
        public void Add(Report entity)
        {
            using (SqlCommand command = new SqlCommand(
    "INSERT INTO reports (visits_id_vis, symptoms, diagnosis, recommendation, treatment, conclusion, rep_dat) " +
    "VALUES (@VisitId, @Symptoms, @Diagnosis, @Recommendation, @Treatment, @Conclusion, @ReportDate)", conn))
            {
                command.Parameters.AddWithValue("@VisitId", entity.Id_vis);
                command.Parameters.AddWithValue("@Symptoms", entity.Symptoms);
                command.Parameters.AddWithValue("@Diagnosis", string.IsNullOrEmpty(entity.Diagnosis) ? (object)DBNull.Value : entity.Diagnosis);
                command.Parameters.AddWithValue("@Recommendation", string.IsNullOrEmpty(entity.Recommendation) ? (object)DBNull.Value : entity.Recommendation);
                command.Parameters.AddWithValue("@Treatment", string.IsNullOrEmpty(entity.Treatment) ? (object)DBNull.Value : entity.Treatment);
                command.Parameters.AddWithValue("@Conclusion", entity.Conclusion);
                command.Parameters.AddWithValue("@ReportDate", entity.Rep_dat);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    Console.WriteLine("Report added.");
                }
                else
                {
                    Console.WriteLine("Failed to add report.");
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all reports from the database
        /// </summary>
        /// <returns>all reports from the database</returns>
        public IEnumerable<Report> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM reports", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Report report = new Report()
                        {
                            Id = reader.GetInt32("id_rep"),
                            Id_vis = reader.GetInt32("visits_id_vis"),
                            Symptoms = reader.GetString("symptoms"),
                            Diagnosis = reader.IsDBNull("diagnosis") ? (string?)null : reader.GetString("diagnosis"),
                            Recommendation = reader.IsDBNull("recommendation") ? (string?)null : reader.GetString("recommendation"),
                            Treatment = reader.IsDBNull("treatment") ? (string?)null : reader.GetString("treatment"),
                            Conclusion = reader.GetString("conclusion"),
                            Rep_dat = reader.GetDateTime("rep_dat")
                        };
                        yield return report;
                    }
                }
            }
        }

        /// <summary>
        /// updates a report in database
        /// </summary>
        /// <param name="entity">updated report</param>
        public void Update(Report entity)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE reports SET symptoms = '{entity.Symptoms}', diagnosis = '{entity.Diagnosis}', " +
                                             $"recommendation = '{entity.Recommendation}', treatment = '{entity.Treatment}', " +
                                             $"conclusion = '{entity.Conclusion}', rep_dat = '{entity.Rep_dat.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                                             $"WHERE id_rep = {entity.Id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("Report not found or no changes made.");
                }
                else
                {
                    Console.WriteLine("Report information updated successfully.");
                }
            }
        }
    }
}
