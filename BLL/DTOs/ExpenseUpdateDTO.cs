using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ExpenseUpdateDTO
    {
        public int ExpenseID { get; set; }
        public int TripID { get; set; }
        public string ExpenseType { get; set; }
        public decimal ItemCost { get; set; }
        public string Description { get; set; }
        public string ReceiptImage { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
