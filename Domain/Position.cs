using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("Position", Schema = "BusinessTravel")]
public partial class Position
{
    [Key]
    [Column("PositionID")]
    public int PositionId { get; set; }

    [StringLength(50)]
    public string PositionName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    [Column(TypeName = "money")]
    public decimal? BalanceLimit { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
