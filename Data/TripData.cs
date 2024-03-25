using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TripData : ITripData
    {
        private readonly AppDbContext _context;
        public TripData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var trip = await _context.Trips.FirstOrDefaultAsync(t => t.TripId == id);
            if (trip != null)
            {
                trip.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            var trip = await _context.Trips.Where(t => t.IsDeleted == false).ToListAsync();
            return trip;
        }

        public async Task<Trip> GetById(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            return trip;
        }

        public async Task<Trip> Insert(Trip entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@SubmittedBy", entity.SubmittedBy),
                new SqlParameter("@StartDate", entity.StartDate),
                new SqlParameter("@EndDate", entity.EndDate),
                new SqlParameter("@Location", entity.Location),
                new SqlParameter("@StatusId", entity.StatusId)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC BusinessTravel.CreateTrip @SubmittedBy, @StartDate, @EndDate, @Location, @StatusId", parameters);
            return entity;
        }

        public Task<Trip> Update(int id, Trip entity)
        {
            throw new NotImplementedException();
        }
    }
}
