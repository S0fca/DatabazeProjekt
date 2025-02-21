using DatabazeProjekt.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabazeProjekt.database
{
    internal class LabTestsDAO : IGenericDAO<LabTest>
    {
        SqlConnection conn = DatabaseConnection.GetDatabaseConnection();

        /// <summary>
        /// adds lab test
        /// </summary>
        /// <param name="entity">test to add</param>
        public void Add(LabTest entity)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO labTests (patients_id_pat, name, tes_ok, result, tes_dat, notes) " +
                                                       "VALUES (@Id_pat, @Name, @Tes_ok, @Result, @Tes_dat, @Notes);", conn))
            {
                command.Parameters.AddWithValue("@Id_pat", entity.Id_pat);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Tes_ok", entity.Tes_ok == null ? (object)DBNull.Value : entity.Tes_ok);
                command.Parameters.AddWithValue("@Result", entity.Result == null ? (object)DBNull.Value : entity.Result);
                command.Parameters.AddWithValue("@Tes_dat", entity.Tes_dat == null ? (object)DBNull.Value : entity.Tes_dat);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(entity.Notes) ? (object)DBNull.Value : entity.Notes);

                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all tests from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LabTest> GetAll()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM labTests", conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LabTest labTest = new LabTest()
                        {
                            Id = reader.GetInt32("id_tes"),
                            Id_pat = reader.GetInt32("patients_id_pat"),
                            Name = reader.GetString("name"),
                            Tes_ok = reader.IsDBNull("tes_ok") ? (bool?)null : reader.GetBoolean("tes_ok"),
                            Result = reader.IsDBNull("result") ? (string?)null : reader.GetString("result"),
                            Tes_dat = reader.IsDBNull("tes_dat") ? (DateTime?)null : reader.GetDateTime("tes_dat"),
                            Notes = reader.IsDBNull("notes") ? (string?)null : reader.GetString("notes")
                        };
                        yield return labTest;
                    }
                }
            }
        }
        public void Update(LabTest entity)
        {
            throw new NotImplementedException();
        }
    }
}
