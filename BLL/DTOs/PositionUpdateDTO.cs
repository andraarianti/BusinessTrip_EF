﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PositionUpdateDTO
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public bool IsDeleted { get; set; }
        public decimal? BalanceLimit { get; set; }
    }
}
