using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IStaffBLL
    {
        Task<IEnumerable<StaffDTO>> GetAll();
        Task<StaffDTO> GetById(int id);
        Task<IEnumerable<StaffDTO>> GetByUsername(string name);
        Task<StaffDTO> Login(string username, string password);
        Task<Task> Insert (StaffCreateDTO entity);
        Task<Task> Delete(int id);
        Task<Task> Update(int id, StaffUpdateDTO entity);
        Task<IEnumerable<StaffDTO>> GetStaffWithPositions();
        Task<Task> ChangePassword(string username, string password); 

    }
}
