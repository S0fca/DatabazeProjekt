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

        public override string? ToString()
        {
            return $"Doctor[Name: {name} {surname}, Specialization: {specialization}]";
        }
    }
}
