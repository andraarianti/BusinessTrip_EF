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

        public async Task<Task> ChangePassword(string username, string password)
        {
            try
            {
                var changePassword = await _staffData.ChangePassword(username, password);
                return changePassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<StaffDTO> Login(string username, string password)
        {
            try
            {
                var userLogin = await _staffData.Login(username, password);
                var loginDTO = _mapper.Map<StaffDTO>(userLogin);
                return loginDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Task> Update(int id, StaffUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
