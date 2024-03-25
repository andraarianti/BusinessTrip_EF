using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Data;
using Data.Interfaces;

namespace BLL
{
    public class TripBLL : ITripBLL
    {
        private readonly ITripData _tripData;
        private readonly IMapper _mapper;
        public TripBLL(ITripData tripData, IMapper mapper)
        {
            _tripData = tripData;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var trip = _tripData.GetById(id);
            if(trip != null)
            {
                await _tripData.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TripDTO>> GetAll()
        {
            var trip = await _tripData.GetAll();
            var tripDTO = _mapper.Map<IEnumerable<TripDTO>>(trip);
            return tripDTO;
        }

        public async Task<TripDTO> GetById(int id)
        {
            var trip = await _tripData.GetById(id);
            var tripDTO = _mapper.Map<TripDTO>(trip);
            return tripDTO;
        }

        public async Task<TripDTO> Insert(TripCreateDTO entity)
        {
            try
            {
                var trip = _mapper.Map<Trip>(entity);
                var resut = await _tripData.Insert(trip);
                var tripDto = _mapper.Map<TripDTO>(resut);
                return tripDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<TripDTO> Update(int id, TripUpdateDTO position)
        {
            throw new NotImplementedException();
        }
    }
}
