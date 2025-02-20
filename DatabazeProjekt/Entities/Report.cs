using Microsoft.IdentityModel.Tokens;

namespace DatabazeProjekt.Entities
{
    internal class Report
    {

        private int id;
        private int id_vis;
        private string symptoms;
        private string? diagnosis;
        private string? recommendation;
        private string? treatment;
        private string conclusion;
        private DateTime rep_dat;

        public int Id { get => id; set => id = value; }
        public int Id_vis { get => id_vis; set => id_vis = value; }
        public string Symptoms { get => symptoms; set => symptoms = value; }
        public string? Diagnosis { get => diagnosis; set => diagnosis = value; }
        public string? Recommendation { get => recommendation; set => recommendation = value; }
        public string? Treatment { get => treatment; set => treatment = value; }
        public string Conclusion { get => conclusion; set => conclusion = value; }
        public DateTime Rep_dat { get => rep_dat; set => rep_dat = value; }

        public override string? ToString()
        {
            return $"Symptoms: {symptoms}, Diagnosis: {((diagnosis.IsNullOrEmpty())?"-":diagnosis)}, Recommendation: {((recommendation.IsNullOrEmpty()) ? "-" : recommendation)}, Treatment: {((treatment.IsNullOrEmpty()) ? "-" : treatment)}, Conclusion: {conclusion}, Date: {rep_dat:dd-MM-yyyy HH:mm}";
        }

    }
}
