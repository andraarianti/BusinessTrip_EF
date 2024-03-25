using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Data.Interfaces;

namespace BLL
{
    public class PositionsBLL : IPositionsBLL
    {
        private readonly IPositionsData _positionsData;
        private readonly IMapper _mapper;
        public PositionsBLL(IPositionsData positionsData, IMapper mapper)
        {
            _positionsData = positionsData;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _positionsData.Delete(id);
        }


        public async Task<IEnumerable<PositionDTO>> GetAll()
        {
            var positions = await _positionsData.GetAll();
            var positionsDto = _mapper.Map<IEnumerable<PositionDTO>>(positions);
            return positionsDto;
        }

        public async Task<PositionDTO> GetById(int id)
        {
            var positions = await _positionsData.GetById(id);
            var positionsDto = _mapper.Map<PositionDTO>(positions);
            return positionsDto;
        }

        public async Task<PositionDTO> Insert(PositionCreateDTO entity)
        {
            try
            {
                var position = _mapper.Map<Position>(entity);
                var resut = await _positionsData.Insert(position);
                var positionDto = _mapper.Map<PositionDTO>(resut);
                return positionDto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PositionDTO> Update(int id, PositionUpdateDTO entity)
        {
            try
            {
                var position = _mapper.Map<Position>(entity);
                var result = await _positionsData.Update(id, position);
                var positionDto = _mapper.Map<PositionDTO>(result);
                return positionDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
