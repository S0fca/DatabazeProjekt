using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

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
                command.Parameters.AddWithValue("@PatientId", entity.Patient.Id);
                command.Parameters.AddWithValue("@DoctorId", entity.Doctor.Id);
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
            using (SqlCommand command = new SqlCommand("SELECT * FROM visits v JOIN patients p on p.id_pat = v.patients_id_pat JOIN doctors d on d.id_doc = v.doctors_id_doc;", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient()
                        {
                            Id = reader.GetInt32("id_pat"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Birth_dat = reader.GetDateTime("birth_dat"),
                            Birth_num = reader.GetString("birth_num"),
                            Contact = reader.GetString("contact"),
                            Height = reader.IsDBNull("height") ? (decimal?)null : reader.GetDecimal("height"),
                            Weight = reader.IsDBNull("weight") ? (decimal?)null : reader.GetDecimal("weight")
                        };
                        Doctor doctor = new Doctor()
                        {
                            Id = reader.GetInt32("id_doc"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Specialization = reader.GetString("specialization")
                        };

                        Visit visit = new Visit()
                        {
                            Id = reader.GetInt32("id_vis"),
                            Patient = patient,
                            Doctor = doctor,
                            Vis_reason = reader.GetString("vis_reason"),
                            Vis_dat = reader.GetDateTime("vis_dat"),
                            Vis_price = reader.GetDecimal("vis_price")
                        };
                        yield return visit;
                    }
                }
            }
        }

        public void Update(Visit entity)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE visits SET patients_id_pat = {entity.Patient.Id}, doctors_id_doc = {entity.Doctor.Id}, " +
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
