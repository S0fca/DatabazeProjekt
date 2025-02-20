using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabazeProjekt.database
{
    internal class PatientsDAO : IGenericDAO<Patient>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Patient entity)
        {
            using (SqlCommand command = new SqlCommand(
    "INSERT INTO patients (name, surname, birth_dat, birth_num, contact, height, weight) " +
    "VALUES (@Name, @Surname, @BirthDat, @BirthNum, @Contact, @Height, @Weight)", conn))
            {
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Surname", entity.Surname);
                command.Parameters.AddWithValue("@BirthDat", entity.Birth_dat);
                command.Parameters.AddWithValue("@BirthNum", entity.Birth_num);
                command.Parameters.AddWithValue("@Contact", entity.Contact);
                command.Parameters.AddWithValue("@Height", entity.Height.HasValue ? (object)entity.Height.Value : DBNull.Value);
                command.Parameters.AddWithValue("@Weight", entity.Weight.HasValue ? (object)entity.Weight.Value : DBNull.Value);

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
                            Id = reader.GetInt32("id_pat"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Birth_dat = reader.GetDateTime("birth_dat"),
                            Birth_num = reader.GetString("birth_num"),
                            Contact = reader.GetString("contact"),
                            Height = reader.IsDBNull("height") ? (decimal?)null : reader.GetDecimal("height"),
                            Weight = reader.IsDBNull("weight") ? (decimal?)null : reader.GetDecimal("weight")
                        };
                        yield return patient;
                    }
                }
            }
        }

        public void Update(Patient entity)
        {
            using (SqlCommand command = new SqlCommand(
    "UPDATE patients SET name = @Name, surname = @Surname, birth_dat = @BirthDate, " +
    "birth_num = @BirthNum, contact = @Contact, height = @Height, weight = @Weight " +
    "WHERE id_pat = @PatientId", conn))
            {
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Surname", entity.Surname);
                command.Parameters.AddWithValue("@BirthDate", entity.Birth_dat);
                command.Parameters.AddWithValue("@BirthNum", entity.Birth_num);
                command.Parameters.AddWithValue("@Contact", entity.Contact);
                command.Parameters.AddWithValue("@Height", entity.Height.HasValue ? (object)entity.Height : DBNull.Value);
                command.Parameters.AddWithValue("@Weight", entity.Weight.HasValue ? (object)entity.Weight : DBNull.Value);
                command.Parameters.AddWithValue("@PatientId", entity.Id);

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
