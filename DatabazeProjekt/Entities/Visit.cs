namespace DatabazeProjekt.Entities
{
    internal class Visit
    {

        private int id;
        private Patient patient;
        private Doctor doctor;
        private string vis_reason;
        private DateTime vis_dat;
        private decimal vis_price;

        public int Id { get => id; set => id = value; }
        internal Patient Patient { get => patient; set => patient = value; }
        internal Doctor Doctor { get => doctor; set => doctor = value; }
        public string Vis_reason { get => vis_reason; set => vis_reason = value; }
        public DateTime Vis_dat { get => vis_dat; set => vis_dat = value; }
        public decimal Vis_price { get => vis_price; set => vis_price = value; }

        public override string? ToString()
        {
            return $"Reason: {vis_reason}, Date: {vis_dat:dd-MM-yyyy HH:mm}, Price: {vis_price} CZK";
        }

    }
}
