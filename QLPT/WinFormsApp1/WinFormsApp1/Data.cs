using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ThieunuQLPT
{
    [Table("profiles")]
    public class ProfilesData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("email")]
        public string? Email { get; set; }
        [Column("password")]
        public string? Password { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }


    [Table("houses")]
    public class HousesData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("total_rent")]
        public decimal? TotalRent { get; set; }

        [Column("electricity_rate")]
        public decimal? ElectricityRate { get; set; }

        [Column("water_rate")]
        public decimal? WaterRate { get; set; }

        [Column("max_members")]
        public int? MaxMembers { get; set; } = 6;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

       

        [Column("service_rate")]
        public decimal? ServiceRate { get; set; }
    }

    [Table("house_members")]
    public class HouseMembersData : BaseModel
    {
        [Column("is_paid")]
        public bool? IsPaid { get; set; }

        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("house_id")]
        public Guid HouseId { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("role")]
        public string? Role { get; set; } = "member";

        [Column("joined_at")]
        public DateTime JoinedAt { get; set; } = DateTime.Now;

        [Column("left_at")]
        public DateTime? LeftAt { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
