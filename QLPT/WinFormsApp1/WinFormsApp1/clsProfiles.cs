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
    public class clsProfiles:BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("full_name")]
        public string ?FullName { get; set; }

        [Column("phone")]
        public string ?Phone { get; set; }

        [Column("email")]
        public string ?Email { get; set; }
        [Column("password")]
        public string ?Password { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
