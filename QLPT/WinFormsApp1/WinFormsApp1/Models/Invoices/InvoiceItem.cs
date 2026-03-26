using Newtonsoft.Json;
using System.ComponentModel;

namespace ThieunuQLPT.Models.Invoices
{
    public class InvoiceItem
    {
        [Browsable(false)]
        public Guid id { get; set; }

        [Browsable(false)]
        public Guid invoice_id {  get; set; }
        public string name { get; set; } = "";
        public string type { get; set; } = "";
        public decimal amount { get; set; }

        [JsonIgnore]
        public decimal TotalAmount { get; set; }
    }
}
