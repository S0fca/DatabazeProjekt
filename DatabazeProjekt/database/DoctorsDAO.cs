using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;

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
                            Id = Convert.ToInt32(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            Surname = reader[2].ToString(),
                            Specialization = reader[3].ToString()
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
