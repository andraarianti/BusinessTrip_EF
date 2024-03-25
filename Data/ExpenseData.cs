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
    public class ExpenseData : IExpenseData
    {
        private readonly AppDbContext _context;
        public ExpenseData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(t => t.ExpenseId == id);
            if (expense != null)
            {
                expense.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expense = await _context.Expenses.Where(e => e.IsDeleted == false).ToListAsync();
            return expense;
        }

        public async Task<Expense> GetById(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpenseByTripId(int tripId)
        {
            var expense = await _context.Expenses
                            .Where(e => e.TripId == tripId)
                             .ToListAsync();
            return expense;
        }

        public async Task<Expense> Insert(Expense entity)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@TripID", entity.TripId),
                    new SqlParameter("@ExpenseType", entity.ExpenseType),
                    new SqlParameter("@ItemCost", entity.ItemCost),
                    new SqlParameter("@Description", entity.Description),
                    new SqlParameter("@ReceiptImage", entity.ReceiptImage)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC BusinessTravel.AddExpense @TripID, @ExpenseType, @ItemCost, @Description, @ReceiptImage",
                    parameters);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding expense: {ex.Message}");
            }
        }

        public async Task<Expense> Update(int id, Expense entity)
        {
            try
            {
                var expenses = await GetById(id);
                if (expenses == null)
                {
                    throw new Exception("Position not found");
                }

                var parameters = new[]
                {
                    new SqlParameter("@ExpenseID", entity.ExpenseId),
                    new SqlParameter("@TripID", entity.TripId),
                    new SqlParameter("@ExpenseType", entity.ExpenseType),
                    new SqlParameter("@ItemCost", entity.ItemCost),
                    new SqlParameter("@Description", entity.Description),
                    new SqlParameter("@ReceiptImage", entity.ReceiptImage)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC BusinessTravel.UpdateExpense @ExpenseID, @TripID, @ExpenseType, @ItemCost, @Description, @ReceiptImage",
                    parameters);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating expense: {ex.Message}");
            }
        }
    }
}
