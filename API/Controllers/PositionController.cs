using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionsBLL _positionsBLL;

        public PositionController(IPositionsBLL positionsBLL)
        {
            _positionsBLL = positionsBLL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPositions()
        {
            var positions = await _positionsBLL.GetAll();
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var positions = await _positionsBLL.GetById(id);
            return Ok(positions);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PositionCreateDTO position)
        {
            var positions = await _positionsBLL.Insert(position);
            return Ok(positions);
        }

        [HttpPut("Edit{id}")]
        public async Task<IActionResult> Update(int id, PositionUpdateDTO position)
        {
            await _positionsBLL.Update(id, position);
            return Ok("Update data success");
        }

        [HttpPut("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _positionsBLL.Delete(id);
            return Ok($"Delete data id:{id} success");
        }
    }
}
