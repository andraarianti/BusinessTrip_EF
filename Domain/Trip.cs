using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Trip", Schema = "BusinessTravel")]
public partial class Trip
{
    [Key]
    [Column("TripID")]
    public int TripId { get; set; }

    public int SubmittedBy { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    [StringLength(255)]
    public string Location { get; set; } = null!;

    [Column("StatusID")]
    public int? StatusId { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalCost { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastModified { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Trip")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    [ForeignKey("StatusId")]
    [InverseProperty("Trips")]
    public virtual Status? Status { get; set; }

    [ForeignKey("SubmittedBy")]
    [InverseProperty("Trips")]
    public virtual Staff SubmittedByNavigation { get; set; } = null!;
}
