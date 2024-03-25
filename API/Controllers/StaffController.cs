using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffBLL _staffBLL;
        public StaffController(IStaffBLL staffBLL)
        {
            _staffBLL = staffBLL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staff = await _staffBLL.GetAll();
            return Ok(staff);
        }

        [HttpGet("Id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var staff = await _staffBLL.GetById(id);
            return Ok(staff);
        }

        [HttpGet("Username/{name}")]
        public async Task<IActionResult> GetByUsername(string name)
        {
            var staff = await _staffBLL.GetByUsername(name);
            return Ok(staff);
        }

        [HttpGet("StaffPosition")]
        public async Task<IActionResult> GetStaffWithPosition()
        {
            var staff = await _staffBLL.GetStaffWithPositions();
            return Ok(staff);
        }
    }
}
