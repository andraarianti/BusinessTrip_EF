using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Data.Interfaces;

namespace BLL
{
    public class StaffBLL : IStaffBLL
    {
        private readonly IStaffData _staffData;
        private readonly IMapper _mapper;
        public StaffBLL(IStaffData staffData, IMapper mapper)
        {
            _staffData = staffData;
            _mapper = mapper;
        }

        public Task<Task> ChangePassword(StaffChangePasswordDTO changePasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StaffDTO>> GetAll()
        {
            var staff = await _staffData.GetAll();
            var staffDTO = _mapper.Map<IEnumerable<StaffDTO>>(staff);
            return staffDTO;
        }

        public async Task<StaffDTO> GetById(int id)
        {
            var staff = await _staffData.GetById(id);
            var staffDTO = _mapper.Map<StaffDTO>(staff);
            return staffDTO;
        }

        public async Task<IEnumerable<StaffDTO>> GetByUsername(string name)
        {
            var staff = await _staffData.GetByUsername(name);
            var staffDTO = _mapper.Map<IEnumerable<StaffDTO>>(staff);
            return staffDTO;
        }

        public async Task<IEnumerable<StaffDTO>> GetStaffWithPositions()
        {
            var staff = await _staffData.GetStaffWithPosition();
            var staffDTO = _mapper.Map<IEnumerable<StaffDTO>>(staff);
            return staffDTO;
        }

        public Task<Task> Insert(StaffCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<StaffDTO> Login(StaffLoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Update(int id, StaffUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
