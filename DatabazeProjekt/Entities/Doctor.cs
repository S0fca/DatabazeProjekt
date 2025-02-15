namespace DatabazeProjekt.Entities
{
    internal class Doctor
    {

        private int id;
        private string name;
        private string surname;
        private string specialization;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Specialization { get => specialization; set => specialization = value; }

        public Doctor(int id, string name, string surname, string specialization)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
        }

        public override string? ToString()
        {
            return $"Doctor[Name: {name} {surname}, Specialization: {specialization}]";
        }
    }
}
