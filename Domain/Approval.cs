using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Approval", Schema = "BusinessTravel")]
public partial class Approval
{
    [Key]
    [Column("ApprovalID")]
    public int ApprovalId { get; set; }

    [Column("ExpenseID")]
    public int ExpenseId { get; set; }

    [Column("ApproverID")]
    public int ApproverId { get; set; }

    public bool? IsApproved { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ApprovalDate { get; set; }

    [ForeignKey("ApproverId")]
    [InverseProperty("Approvals")]
    public virtual Staff Approver { get; set; } = null!;

    [ForeignKey("ExpenseId")]
    [InverseProperty("Approvals")]
    public virtual Expense Expense { get; set; } = null!;

    [InverseProperty("Approval")]
    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
