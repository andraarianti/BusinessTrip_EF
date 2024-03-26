using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Data
{
    public class StaffData : IStaffData
    {
        private readonly AppDbContext _context;
        public StaffData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Task> ChangePassword(string username, string newPassword)
        {
            try
            {
                var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Username == username);
                if (staff == null) // Ubah != menjadi ==
                {
                    throw new ArgumentException("User not found");
                }
                staff.Password = Helpers.Md5Hash.GetHash(newPassword);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var staff = await _context.Staff.FirstOrDefaultAsync(s => s.StaffId == id);
            if (staff != null)
            {
                staff.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Staff>> GetAll()
        {
            var staff = await _context.Staff.Where(s => s.IsDeleted == false).ToListAsync();
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetStaffWithPosition()
        {
            var staff = await _context.Staff
                                        .Where(s => !s.IsDeleted)
                                        .Join(
                                            _context.Positions,
                                            staff => staff.PositionId,
                                            position => position.PositionId,
                                            (staff, position) => new Staff
                                            {
                                                StaffId = staff.StaffId,
                                                Name = staff.Name,
                                                PositionId = staff.PositionId,
                                                Role = staff.Role,
                                                LastModified = staff.LastModified,
                                                IsDeleted = staff.IsDeleted,
                                                Username = staff.Username,
                                                Password = staff.Password,
                                                Email = staff.Email,
                                                LastLogin = staff.LastLogin,
                                                MaxAttempt = staff.MaxAttempt,
                                                IsLocked = staff.IsLocked,
                                                // Assign the Position object directly
                                                Position = position // Assuming Position is a reference navigation property in StaffDTO
                                            })
                                        .ToListAsync();
            return staff;
        }

        public async Task<Staff> GetById(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            return staff;
        }

        public async Task<IEnumerable<Staff>> GetByUsername(string username)
        {
            var staff = await _context.Staff.Where(s => s.Username == username && s.IsDeleted == false).ToListAsync();
            return staff;
        }

        public Task<Staff> Insert(Staff entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Staff> Login(string username, string password)
        {
            var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Username == username && s.Password == Helpers.Md5Hash.GetHash(password));
            if (staff == null)
            {
                throw new ArgumentException("User not found");
            }
            return staff;
        }

        public Task<Task> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<Staff> Update(int id, Staff entity)
        {
            try
            {
                var existingStaff = await _context.Staff.FindAsync(id);
                if (existingStaff == null)
                {
                    throw new Exception("Staff not found");
                }

                //data yang akan di update
                existingStaff.Name = entity.Name;
                existingStaff.Email = entity.Email;
                existingStaff.Username = entity.Username;
                existingStaff.PositionId = entity.PositionId;
                existingStaff.Role = entity.Role;

                await _context.SaveChangesAsync();
                return existingStaff;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Staff> InsertStaff(Staff entity, string password)
        {
            try
            {
                string hashPassword = Helpers.Md5Hash.GetHash(password);
                entity.Password = hashPassword;
                _context.Staff.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
