using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt.database
{
    internal class PatientsDAO : IGenericDAO<Patient>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Patient entity)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO patients (name, surname, birth_dat, birth_num, contact, height, weight) " +
                                             $"VALUES ('{entity.Name}', '{entity.Surname}', '{entity.Birth_dat.ToString("yyyy-MM-dd")}', " +
                                             $"'{entity.Birth_num}', '{entity.Contact}', {entity.Height}, {entity.Weight})", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    Console.WriteLine("Patient added.");
                }
                else
                {
                    Console.WriteLine("Failed to add patient.");
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM patients WHERE id_pac = {id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Patient not found.");
                }
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM patients", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Birth_dat = reader.GetDateTime(3),
                            Birth_num = reader.GetString(4),
                            Contact = reader.GetString(5),
                            Height = reader.IsDBNull(6) ? (decimal?)null : reader.GetDecimal(6),
                            Weight = reader.IsDBNull(7) ? (decimal?)null : reader.GetDecimal(7)
                        };
                        yield return patient;
                    }
                }
            }
        }

        public void Update(Patient entity)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE patients SET name = '{entity.Name}', surname = '{entity.Surname}', " +
                                              $"birth_dat = '{entity.Birth_dat.ToString("yyyy-MM-dd")}', birth_num = '{entity.Birth_num}', " +
                                              $"contact = '{entity.Contact}', height = {entity.Height}, weight = {entity.Weight} " +
                                              $"WHERE id_pat = {entity.Id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("Patient not found or no changes made.");
                }
                else
                {
                    Console.WriteLine("Patient information updated successfully.");
                }
            }
        }
    }
}
