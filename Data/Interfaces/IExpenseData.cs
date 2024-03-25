using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace Data.Interfaces
{
    public interface IExpenseData : ICrudData<Expense>
    {
        Task<IEnumerable<Expense>> GetExpenseByTripId(int tripId);
    }
}
