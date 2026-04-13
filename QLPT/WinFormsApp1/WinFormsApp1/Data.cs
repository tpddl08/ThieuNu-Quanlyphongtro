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

        [Column("price_rent")]
        public decimal? PriceRent { get; set; }

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
        [Column("is_paid")]
        public bool IsPaid { get; set; } = false;
        [Column("num_absent")]
        public int? NumAbsent { get; set; }
    }

    [Table("chores")]
    public class ChoresData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("house_id")]
        public Guid? HouseId { get; set; }

        [Column("task_name")]
        public string? TaskName { get; set; }

        [Column("assigned_to")]
        public Guid? AssignedTo { get; set; }

        [Column("due_date")]
        public DateTime? DueDate { get; set; }

        [Column("is_completed")]
        public bool IsCompleted { get; set; } = false;

        [Column("completed_at")]
        public DateTime? CompletedAt { get; set; }
    }
    [Table("expenses")]
    public class ExpensesData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("house_id")]
        public Guid? HouseId { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("amount")]
        public decimal? Amount { get; set; }

        [Column("paid_by")]
        public Guid? PaidBy { get; set; }

        [Column("expense_date")]
        public DateTime? ExpenseDate { get; set; }

        [Column("category")]
        public string? Category { get; set; }

        [Column("note")]
        public string? Note { get; set; }
    }

    [Table("invoices")]
    public class InvoicesData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("house_id")]
        public Guid? HouseId { get; set; }

        [Column("month_year")]
        public string? MonthYear { get; set; }

        [Column("total_amount")]
        public decimal? TotalAmount { get; set; }

        [Column("status")]
        public string? Status { get; set; } = "draft";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("old_number")]
        public int? OldNumber { get; set; }

        [Column("new_number")]
        public int? NewNumber { get; set; }
    }

    [Table("invoice_items")]
    public class InvoiceItemsData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("invoice_id")]
        public Guid? InvoiceId { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("amount")]
        public decimal? Amount { get; set; }

        [Column("type")]
        public string? Type { get; set; }
    }

    [Table("invoice_payments")]
    public class InvoicePaymentsData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("invoice_id")]
        public Guid? InvoiceId { get; set; }

        [Column("amount")]
        public decimal? Amount { get; set; }

        [Column("paid_at")]
        public DateTime? PaidAt { get; set; }

        [Column("status")]
        public string? Status { get; set; } = "unpaid";

        [Column("user_id")]
        public Guid? UserId { get; set; }
    }

    [Table("notes")]
    public class NotesData : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("house_id")]
        public Guid? HouseId { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("created_by")]
        public Guid? CreatedBy { get; set; }

        [Column("is_pinned")]
        public bool IsPinned { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
