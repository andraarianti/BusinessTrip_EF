using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TripDTO
    {
        public int TripID { get; set; }
        public int SubmittedBy { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Location { get; set; }
        public int? StatusID { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
