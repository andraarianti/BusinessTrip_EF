using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace BLL.DTOs
{
    public class StaffDTO
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public int PositionID { get; set; }
        public string Role { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
        public byte MaxAttempt { get; set; }
        public bool IsLocked { get; set; }
        public Position position { get; set; }
    }
}
