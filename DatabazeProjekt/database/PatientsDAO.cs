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
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Birth_dat = Convert.ToDateTime(reader[3]),
                        Birth_num = reader[4].ToString(),
                        Contact = reader[5].ToString(),
                        Height = Convert.ToDecimal(reader[6]),
                        Weight = Convert.ToDecimal(reader[7])
                    };
                    yield return patient;
                }
                reader.Close();
            }
        }

        public Patient GetByBirthNum(string birht_num)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM patients WHERE birth_num = '{birht_num}'", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Patient patient = new Patient()
                {
                    Id = Convert.ToInt32(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Surname = reader[2].ToString(),
                    Birth_dat = Convert.ToDateTime(reader[3]),
                    Birth_num = reader[4].ToString(),
                    Contact = reader[5].ToString(),
                    Height = Convert.ToDecimal(reader[6]),
                    Weight = Convert.ToDecimal(reader[7])
                };
                reader.Close();
                return patient;
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
