using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ApprovalDTO
    {
        public int ApprovalID { get; set; }
        public int ExpenseID { get; set; }
        public int ApproverID { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }
}
