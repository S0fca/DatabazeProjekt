using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;

namespace DatabazeProjekt.database
{
    internal class LabTestsDAO : IGenericDAO<LabTest>
    {
        public void Add(LabTest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LabTest> GetAll()
        {
            List<LabTest> labTests = new List<LabTest>();
            SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

            using (SqlCommand command = new SqlCommand("SELECT * FROM labTests", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LabTest labTest = new LabTest()
                    {
                        Id = Convert.ToInt32(reader[0].ToString()),
                        Id_pat = Convert.ToInt32(reader[1].ToString()),
                        Name = reader[2].ToString(),
                        Tes_ok = Convert.ToBoolean(reader[3].ToString()),
                        Result = reader[4].ToString(),
                        Tes_dat = Convert.ToDateTime(reader[5].ToString()),
                        Notes = reader[6].ToString()
                    };
                }
                reader.Close();
            }
            return labTests;
        }

        public void Update(LabTest entity)
        {
            throw new NotImplementedException();
        }
    }
}
