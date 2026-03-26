using System.ComponentModel.DataAnnotations;

namespace ThieunuQLPT.Models.Invoices
{
    public class Invoice
    {
        public Guid id { get; set; }
        public Guid house_id { get; set; }
        public string month_year { get; set; } = "";
        public string status { get; set; } = "";
        public DateTime created_at { get; set; }
        public List<InvoiceItem> items { get; set; }
        public decimal total_amount {  get; set; }
    }
}
