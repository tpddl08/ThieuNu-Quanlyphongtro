
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("houses")]
public class DetailBill : BaseModel
{
    [PrimaryKey("id")]
    public string id { get; set; } = "";

    [Column("name")]
    public string Name { get; set; } = "";


    [Column("total_rent")]
    public decimal totalRent { get; set; }

    [Column("electricity_rate")]
    public decimal electricRate { get; set; }

    [Column("water_rate")]
    public decimal waterRate { get; set; }

    [Column("max_members")]
    public int maxMembers { get; set; }

    [Column("service_rate")]
    public decimal serviceRate { get; set; }

    [Column("old_number")]
    public int oldNums { get; set; }

    [Column("new_number")]
    public int newNums { get; set; }





}