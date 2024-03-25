using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PositionCreateDTO
    {
        //public int PositionId { get; set; }
        public string PositionName { get; set; }
        public decimal? BalanceLimit { get; set; }
    }
}
