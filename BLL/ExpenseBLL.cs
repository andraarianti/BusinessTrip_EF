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
    public class ExpenseBLL : IExpenseBLL
    {
        private readonly IExpenseData _expenseData;
        private readonly IMapper _mapper;
        public ExpenseBLL(IExpenseData expenseData, IMapper mapper)
        {
            _expenseData = expenseData;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var expense = _expenseData.GetById(id);
            if (expense != null)
            {
                await _expenseData.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAll()
        {
            var expense = await _expenseData.GetAll();
            var expenseDTO = _mapper.Map<IEnumerable<ExpenseDTO>>(expense);
            return expenseDTO;
        }

        public async Task<ExpenseDTO> GetById(int id)
        {
            var expense = await _expenseData.GetById(id);
            var expenseDTO = _mapper.Map<ExpenseDTO>(expense);
            return expenseDTO;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByTripId(int tripId)
        {
            var expense = await _expenseData.GetExpenseByTripId(tripId);
            var expenseDTO = _mapper.Map<IEnumerable<ExpenseDTO>>(expense);
            return expenseDTO;
        }

        public async Task<ExpenseDTO> Insert(ExpenseCreateDTO entity)
        {
            try
            {
                var expense = _mapper.Map<Expense>(entity);
                var resut = await _expenseData.Insert(expense);
                var expenseDTO = _mapper.Map<ExpenseDTO>(resut);
                return expenseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ExpenseDTO> Update(int id, ExpenseUpdateDTO entity)
        {
            try
            {
                var expense = _mapper.Map<Expense>(entity);
                var resut = await _expenseData.Update(id, expense);
                var expenseDTO = _mapper.Map<ExpenseDTO>(resut);
                return expenseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
