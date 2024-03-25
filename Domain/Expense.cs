using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Expense", Schema = "BusinessTravel")]
public partial class Expense
{
    [Key]
    [Column("ExpenseID")]
    public int ExpenseId { get; set; }

    [Column("TripID")]
    public int TripId { get; set; }

    [StringLength(50)]

    public string ExpenseType { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal ItemCost { get; set; }

    public string? Description { get; set; }

    public string? ReceiptImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastModified { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsApproved { get; set; }

    [InverseProperty("Expense")]
    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    [ForeignKey("TripId")]
    [InverseProperty("Expenses")]
    public virtual Trip Trip { get; set; } = null!;
}
