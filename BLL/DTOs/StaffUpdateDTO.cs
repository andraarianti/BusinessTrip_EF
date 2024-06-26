﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StaffUpdateDTO
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public int PositionID { get; set; }
        public string Role { get; set; }
        public DateTime? LastModified { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
