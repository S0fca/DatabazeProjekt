using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabazeProjekt.database
{
    internal class DoctorsDAO : IGenericDAO<Doctor>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        public void Add(Doctor entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all doctors from database
        /// </summary>
        /// <returns>doctors</returns>
        public IEnumerable<Doctor> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM doctors", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor()
                        {
                            Id = reader.GetInt32("id_doc"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Specialization = reader.GetString("specialization")
                        };
                        yield return doctor;
                    }
                }
            }
        }
        
        /// <summary>
        /// gets all doctors with specified surname
        /// </summary>
        /// <param name="surname">doctors surname</param>
        /// <returns>doctors with specified surname</returns>
        public IEnumerable<Doctor> GetBySurname(string surname)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM doctors WHERE surname = @Surname", conn))
            {
                command.Parameters.AddWithValue("@Surname", surname);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor()
                        {
                            Id = reader.GetInt32("id_doc"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Specialization = reader.GetString("specialization")
                        };
                        yield return doctor;
                    }
                }
            }
        }

        /// <summary>
        /// gets doctor with specifie id
        /// </summary>
        /// <param name="id">doctors id</param>
        /// <returns>doctor with specifie id</returns>
        public Doctor? GetById(int id)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM doctors WHERE id_doc = @Id", conn))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor()
                        {
                            Id = reader.GetInt32("id_doc"),
                            Name = reader.GetString("name"),
                            Surname = reader.GetString("surname"),
                            Specialization = reader.GetString("specialization")
                        };
                        return doctor;
                    }
                }
            }
            return null;
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
