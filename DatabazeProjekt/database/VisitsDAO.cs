using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt.database
{
    internal class VisitsDAO : IGenericDAO<Visit>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Visit entity)
        {
            using (SqlCommand command = new SqlCommand(
    "INSERT INTO visits (patients_id_pat, doctors_id_doc, vis_reason, vis_dat, vis_price) " +
    "VALUES (@PatientId, @DoctorId, @VisitReason, @VisitDate, @VisitPrice)", conn))
            {
                command.Parameters.AddWithValue("@PatientId", entity.Id_pat);
                command.Parameters.AddWithValue("@DoctorId", entity.Id_doc);
                command.Parameters.AddWithValue("@VisitReason", entity.Vis_reason);
                command.Parameters.AddWithValue("@VisitDate", entity.Vis_dat);
                command.Parameters.AddWithValue("@VisitPrice", entity.Vis_price);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    Console.WriteLine("Visit added.");
                }
                else
                {
                    Console.WriteLine("Failed to add visit.");
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM visits WHERE id_vis = {id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Visit not found.");
                }
            }
        }

        public IEnumerable<Visit> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM visits", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Visit visit = new Visit()
                        {
                            Id = Convert.ToInt32(reader[0].ToString()),
                            Id_pat = Convert.ToInt32(reader[1].ToString()),
                            Id_doc = Convert.ToInt32(reader[2].ToString()),
                            Vis_reason = reader[3].ToString(),
                            Vis_dat = Convert.ToDateTime(reader[4]),
                            Vis_price = Convert.ToDecimal(reader[5])
                        };
                        yield return visit;
                    }
                }
            }
        }

        public void Update(Visit entity)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE visits SET patients_id_pat = {entity.Id_pat}, doctors_id_doc = {entity.Id_doc}, " +
                                              $"vis_reason = '{entity.Vis_reason}', vis_dat = '{entity.Vis_dat.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                              $"vis_price = {entity.Vis_price} WHERE id_vis = {entity.Id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("Visit not found or no changes made.");
                }
                else
                {
                    Console.WriteLine("Visit information updated successfully.");
                }
            }
        }
    }
}
