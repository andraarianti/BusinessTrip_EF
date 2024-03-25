using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace Data.Interfaces
{
    public interface IStaffData : ICrudData<Staff>
    {
        Task<Task> ChangePassword(string username, string newPassword);
        Task<Staff> Login(string username, string password);
        Task<Task> Logout();
        Task<Staff> InsertStaff(Staff entity, string password);

        //GET DATA
        Task<IEnumerable<Staff>> GetStaffWithPosition();
        Task<IEnumerable<Staff>> GetByUsername(string username);
    }
}
