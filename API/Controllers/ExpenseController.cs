using BLL;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseBLL _expenseBLL;
        private readonly ITripBLL _tripBLL;
        public ExpenseController(IExpenseBLL expenseBLL, ITripBLL tripBLL)
        {
            _expenseBLL = expenseBLL;
            _tripBLL = tripBLL;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expense = await _expenseBLL.GetAll();
            return Ok(expense);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _expenseBLL.GetById(id);
            return Ok(expense);
        }

        [HttpGet("TripId")]
        public async Task<IActionResult> GetExpenseByTripId(int tripid)
        {
            var expense = await _expenseBLL.GetExpensesByTripId(tripid);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ExpenseCreateDTO expenseDTO)
        {
            try
            {
                await _expenseBLL.Insert(expenseDTO);
                return Ok("Success Add new data");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPut("Edit{id}")]
        public async Task<IActionResult> Update(int id, ExpenseUpdateDTO expenseUpdateDTO)
        {
            var expense = await _expenseBLL.GetById(id);
            if(expense == null)
            {
                throw new Exception("Expense Not Found");
            }
            await _expenseBLL.Update(id, expenseUpdateDTO);
            return Ok("Succeess Edit Data");
        }

        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expenseBLL.GetById(id);
            if (expense == null)
            {
                return NotFound($"Expense with ID {id} not found");
            }

            var trip = await _tripBLL.GetById(expense.TripID);
            if ( trip.StatusID == 1)
            {
                await _expenseBLL.Delete(id);
                return Ok($"Delete data id:{id} success");
            }

            return BadRequest("Data Trip is On Reimbursment Progress");
        }
    }
}
