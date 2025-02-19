namespace DatabazeProjekt.Entities
{
    internal class Patient
    {

        private int id;
        private string name;
        private string surname;
        private DateTime birth_dat;
        private string birth_num;
        private string contact;
        private decimal height;
        private decimal weight;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime Birth_dat { get => birth_dat; set => birth_dat = value; }
        public string Birth_num { get => birth_num; set => birth_num = value; }
        public string Contact { get => contact; set => contact = value; }
        public decimal Height { get => height; set => height = value; }
        public decimal Weight { get => weight; set => weight = value; }

        public override string? ToString()
        {
            return $"Name: {name} {surname}, Birth Date: {birth_dat:yyyy-MM-dd}, Birth Number: {birth_num}, Contact: {contact}, Height: {height}cm, Weight: {weight}kg";
        }

    }
}
