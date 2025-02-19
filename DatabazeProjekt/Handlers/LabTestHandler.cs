using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class LabTestHandler
    {

        private static LabTestsDAO labTestsDAO = new LabTestsDAO();

        public static List<LabTest> GetAllTests()
        {
            return labTestsDAO.GetAll().ToList();
        }

        //id_tes	patients_id_pat	name	tes_ok	result	tes_dat	notes
        public static void AddTest()
        {
            Patient patient = PatientHandler.GetPatientByBirthNum();
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return;
            }
            string name = UserInputManager.GetStringInput("Name: ");
            bool? testOk = UserInputManager.GetBoolInputOptional("Was test result ok?: ");
            string? result = UserInputManager.GetStringInputOptional("Result: ");
            DateTime? testDate = UserInputManager.GetDateInputOptional("Test date: ");
            string? notes = UserInputManager.GetStringInputOptional("Notes: ");

            LabTest labTest = new LabTest
            {
                Id_pat = patient.Id,
                Name = name,
                Tes_ok = testOk,
                Result = result,
                Tes_dat = testDate,
                Notes = notes
            };

            labTestsDAO.Add(labTest);

        }
    }
}
