using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt.database
{
    internal class ReportsDAO : IGenericDAO<Report>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Report entity)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO reports (visits_id_vis, symptoms, diagnosis, recommendation, treatment, conclusion, rep_dat) " +
                                              $"VALUES ({entity.Id_vis}, '{entity.Symptoms}', '{entity.Diagnosis}', '{entity.Recommendation}', " +
                                              $"'{entity.Treatment}', '{entity.Conclusion}', '{entity.Rep_dat.ToString("yyyy-MM-dd HH:mm:ss")}')", conn))
            {
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
            using (SqlCommand command = new SqlCommand($"DELETE FROM reports WHERE id_rep = {id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Report not found.");
                }
            }
        }

        public IEnumerable<Report> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM reports", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
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
