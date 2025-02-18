using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

namespace DatabazeProjekt.database
{
    internal class DoctorsDAO : IGenericDAO<Doctor>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Doctor entity)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO doctors VALUES ('{entity.Name}', '{entity.Surname}', '{entity.Specialization}')", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    Console.WriteLine("Doctor added.");
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM doctors WHERE id_doc = {id}", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Doctor not found.");
                }
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM doctors", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Specialization = reader[3].ToString()
                    };
                    yield return doctor;
                }
                reader.Close();
            }
        }

        public IEnumerable<Doctor> GetBySurname(string surname)
        {
            List<Doctor> doctors = new List<Doctor>();

            using (SqlCommand command = new SqlCommand($"SELECT * FROM doctors WHERE surname = '{surname}'", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Doctor doctor = new Doctor()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Specialization = reader[3].ToString()
                    };
                    yield return doctor;
                }
                reader.Close();
            }
        }

        public void Update(Doctor entity)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE doctors SET name = '{entity.Name}', surname = '{entity.Surname}', specialization = '{entity.Specialization}' WHERE id_doc = {entity.Id};", conn))
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("Doctor not found or no changes made.");
                }
            }
        }
    }
}
