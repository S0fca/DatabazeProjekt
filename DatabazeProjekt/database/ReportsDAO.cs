using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt.database
{
    internal class ReportsDAO : IGenericDAO<Report>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

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
                            Id = Convert.ToInt32(reader[0].ToString()),
                            Id_vis = Convert.ToInt32(reader[1].ToString()),
                            Symptoms = reader[2].ToString(),
                            Diagnosis = reader[3].ToString(),
                            Recommendation = reader[4].ToString(),
                            Treatment = reader[5].ToString(),
                            Conclusion = reader[6].ToString(),
                            Rep_dat = Convert.ToDateTime(reader[7])
                        };
                        yield return report;
                    }
                }
            }
        }

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
