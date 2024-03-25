using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IPositionsBLL
    {
        Task<IEnumerable<PositionDTO>> GetAll();
        Task<PositionDTO> GetById(int id);
        Task<PositionDTO> Insert(PositionCreateDTO position);
        Task<PositionDTO> Update(int id, PositionUpdateDTO position);
        Task<bool> Delete(int id);
    }
}
