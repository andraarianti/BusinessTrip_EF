using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalsController : ControllerBase
    {
        private readonly IApprovalBLL _approvalBLL;
        private readonly IExpenseBLL _expenseBLL;
        public ApprovalsController(IApprovalBLL approvalBLL, IExpenseBLL expenseBLL)
        {
            _approvalBLL = approvalBLL;
            _expenseBLL = expenseBLL;

        }

        [HttpPost("Approved")]
        public async Task<IActionResult> SetApproval(ApprovalSetStatusDTO approvalSetStatus)
        {
            var items = await _expenseBLL.GetById(approvalSetStatus.ExpenseID);
            if(items.IsApproved == true)
            {
                return BadRequest("The data has been approved.");
            }
            await _approvalBLL.SetApproval(approvalSetStatus);
            return Ok($"Success Approved Expense Id : {approvalSetStatus.ExpenseID}");

        }

        [HttpPost("Rejected")]
        public async Task<IActionResult> SetRejection(ApprovalSetStatusDTO approvalSetStatus)
        {
            var items = await _expenseBLL.GetById(approvalSetStatus.ExpenseID);
            if (items.IsApproved == false)
            {
                return BadRequest("The data has been rejected.");
            }
            await _approvalBLL.SetRejection(approvalSetStatus);
            return Ok($"Success Rejected Expense Id : {approvalSetStatus.ExpenseID}");
        }
    }
}
