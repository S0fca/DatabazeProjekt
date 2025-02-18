namespace DatabazeProjekt.Entities
{
    internal class Visit
    {

        private int id;
        private int id_pat;
        private int id_doc;
        private string vis_reason;
        private DateTime vis_dat;
        private decimal vis_price;

        public int Id { get => id; set => id = value; }
        public int Id_pat { get => id_pat; set => id_pat = value; }
        public int Id_doc { get => id_doc; set => id_doc = value; }
        public string Vis_reason { get => vis_reason; set => vis_reason = value; }
        public DateTime Vis_dat { get => vis_dat; set => vis_dat = value; }
        public decimal Vis_price { get => vis_price; set => vis_price = value; }

        public override string? ToString()
        {
            return $"Visit[Patient ID: {id_pat}, Doctor ID: {id_doc}, Reason: {vis_reason}, Date: {vis_dat:yyyy-MM-dd HH:mm}, Price: {vis_price:C}]";
        }

    }
}
