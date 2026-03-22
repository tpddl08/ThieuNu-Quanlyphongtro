
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("invoices")]
public class ListBills : BaseModel
{
    [PrimaryKey("id")]
    public string id { get; set; } = "";

    [Column("house_id")]
    public string house_id { get; set; } = "";

    [Column("month_year")]
    public string month_year { get; set; } = "";

    [Column("total_amount")]
    public decimal total_amount { get; set; }

    [Column("status")]
    public string status { get; set; } = "";

    [Column("created_at")]
    public DateTime created_at { get; set; }
}