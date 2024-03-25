using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PositionsData : IPositionsData
    {
        private readonly AppDbContext _appDbContext;
        public PositionsData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var position = await _appDbContext.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
            if (position != null)
            {
                position.IsDeleted = true;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false; // Or throw new NotFoundException("Position not found")
        }


        public async Task<IEnumerable<Position>> GetAll()
        {
            var positions = await _appDbContext.Positions.Where(p => p.IsDeleted == false).OrderBy(p => p.PositionName).ToListAsync();
            return positions;
        }

        public async Task<Position> GetById(int id)
        {
            var positions = await _appDbContext.Positions.FindAsync(id);
            return positions;
        }

        public async Task<Position> Insert(Position entity)
        {
            _appDbContext.Positions.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<Position> Update(int id, Position entity)
        {
            try
            {
                var positions = await GetById(id);
                if (positions == null)
                {
                    throw new Exception("Position not found");
                }
                positions.PositionName = entity.PositionName;
                await _appDbContext.SaveChangesAsync();
                return positions;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
