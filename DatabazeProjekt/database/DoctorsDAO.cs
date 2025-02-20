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
        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
