namespace DatabazeProjekt.Entities
{
    internal class LabTest
    {

        private int id;
        private int id_pat;
        private string name;
        private bool tes_ok;
        private string result;
        private DateTime tes_dat;
        private string notes;

        public int Id { get => id; set => id = value; }
        public int Id_pat { get => id_pat; set => id_pat = value; }
        public string Name { get => name; set => name = value; }
        public bool Tes_ok { get => tes_ok; set => tes_ok = value; }
        public string Result { get => result; set => result = value; }
        public DateTime Tes_dat { get => tes_dat; set => tes_dat = value; }
        public string Notes { get => notes; set => notes = value; }

        public LabTest(int id, int id_pat, string name, bool tes_ok, string result, DateTime tes_dat, string notes)
        {
            Id = id;
            Id_pat = id_pat;
            Name = name;
            Tes_ok = tes_ok;
            Result = result;
            Tes_dat = tes_dat;
            Notes = notes;
        }

        public override string? ToString()
        {
            return $"LabTest[Patient ID: {id_pat}, Name: {name}, Result: {result}, Date: {tes_dat:yyyy-MM-dd}, OK: {tes_ok}, Notes: {notes}]";
        }

    }
}
