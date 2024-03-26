using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface ITripBLL
    {
        Task<IEnumerable<TripDTO>> GetAll();
        Task<TripDTO> GetById(int id);
        Task<TripDTO> Insert(TripCreateDTO entity);
        Task<TripDTO> Update(int id, TripUpdateDTO position);
        Task<bool> Delete(int id);
        Task<TripDTO> UpdateStatusId (int TripId);
    }
}
