using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("History", Schema = "BusinessTravel")]
public partial class History
{
    [Key]
    [Column("HistoryID")]
    public int HistoryId { get; set; }

    [Column("StaffID")]
    public int StaffId { get; set; }

    [Column("ApprovalID")]
    public int ApprovalId { get; set; }

    [ForeignKey("ApprovalId")]
    [InverseProperty("Histories")]
    public virtual Approval Approval { get; set; } = null!;

    [ForeignKey("StaffId")]
    [InverseProperty("Histories")]
    public virtual Staff Staff { get; set; } = null!;
}
