using Microsoft.IdentityModel.Tokens;

namespace DatabazeProjekt.Entities
{
    internal class LabTest
    {

        private int id;
        private int id_pat;
        private string name;
        private bool? tes_ok;
        private string? result;
        private DateTime? tes_dat;
        private string? notes;

        public int Id { get => id; set => id = value; }
        public int Id_pat { get => id_pat; set => id_pat = value; }
        public string Name { get => name; set => name = value; }
        public bool? Tes_ok { get => tes_ok; set => tes_ok = value; }
        public string? Result { get => result; set => result = value; }
        public DateTime? Tes_dat { get => tes_dat; set => tes_dat = value; }
        public string? Notes { get => notes; set => notes = value; }

        public override string? ToString()
        {
            return $"Name: {name}, Test ok: {((tes_ok is null) ? "-" : ("" + (((bool)tes_ok) ? "Yes" : "No")))}, Result: {((result is null) ? "-" : result)}, Date: {((tes_dat is null) ? "-" : tes_dat.Value.ToString("yyyy-MM-dd"))}, Notes: {((notes.IsNullOrEmpty()) ? "" : notes)}";
        }

    }
}
