using DatabazeProjekt.database;
using DatabazeProjekt.UI;

namespace DatabazeProjekt.Entities
{
    internal class LabTestHandler
    {

        private static LabTestsDAO labTestsDAO = new LabTestsDAO();

        /// <summary>
        /// gets all tests
        /// </summary>
        /// <returns>all tests</returns>
        public static List<LabTest> GetAllTests()
        {
            List<LabTest> labTests = labTestsDAO.GetAll().ToList();

            if (labTests.Count == 0)
            {
                Console.WriteLine("No tests found.");
            }

            return labTests;
        }

        /// <summary>
        /// gets test information from console
        /// adds the test to the DB
        /// </summary>
        public static void AddTest()
        {
            Patient patient = PatientHandler.GetPatientByBirthNum();
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return;
            }
            string name = UserInputManager.GetStringInput("Test name: ");
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
