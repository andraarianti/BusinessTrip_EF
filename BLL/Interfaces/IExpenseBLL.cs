using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IExpenseBLL
    {
        Task<IEnumerable<ExpenseDTO>> GetAll();
        Task<IEnumerable<ExpenseDTO>> GetExpensesByTripId(int tripId);
        Task<ExpenseDTO> GetById(int id);
        Task<ExpenseDTO> Insert(ExpenseCreateDTO entity);
        Task<ExpenseDTO> Update(int id, ExpenseUpdateDTO entity);
        Task<bool> Delete(int id);
    }
}
