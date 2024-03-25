using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Staff", Schema = "BusinessTravel")]
public partial class Staff
{
    [Key]
    [Column("StaffID")]
    public int StaffId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("PositionID")]
    public int PositionId { get; set; }

    [StringLength(20)]
    public string Role { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LastModified { get; set; }

    public bool IsDeleted { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    public byte MaxAttempt { get; set; }

    public bool IsLocked { get; set; }

    [InverseProperty("Approver")]
    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    [InverseProperty("Staff")]
    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    [ForeignKey("PositionId")]
    [InverseProperty("Staff")]
    public virtual Position Position { get; set; } = null!;

    [InverseProperty("SubmittedByNavigation")]
    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
