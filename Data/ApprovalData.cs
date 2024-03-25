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
    public class ApprovalData : IApprovalData
    {
        private readonly AppDbContext _context;
        public ApprovalData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SetApproval(Approval approval)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", approval.ExpenseId),
                new SqlParameter("@ApproverID", approval.ApproverId)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC BusinessTravel.ApproveExpenseItems @ExpenseID, @ApproverID", parameters);
            return true;
        }

        public async Task<bool> SetRejection(Approval approval)
        {
            var parameters = new[]
            {
                new SqlParameter("@ExpenseID", approval.ExpenseId),
                new SqlParameter("@ApproverID", approval.ApproverId)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC BusinessTravel.RejectExpenseItems @ExpenseID, @ApproverID", parameters);
            return true;
        }
    }
}
