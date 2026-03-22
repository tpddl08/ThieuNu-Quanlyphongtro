namespace ThieunuQLPT.Models
{
    public class House
    {
        public Guid id {  get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public decimal total_rent {  get; set; }
        public decimal electricity_rate {  get; set; }
        public decimal water_rate {  get; set; }
        public int max_members { get; set; }
        public DateTime created_at { get; set; }
    }
}
