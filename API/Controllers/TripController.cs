using API.Models;
using BLL;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripBLL _tripBLL;
        public TripController(ITripBLL tripBLL)
        {
            _tripBLL = tripBLL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trip = await _tripBLL.GetAll();
            return Ok(trip);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var trip = await _tripBLL.GetById(id);
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TripCreateDTO tripCreate)
        {
            try
            {
                // Konversi nilai JSON ke tipe System.DateOnly di sini
                DateOnly startDate = new DateOnly(tripCreate.StartDate.Year, tripCreate.StartDate.Month, tripCreate.StartDate.Day);
                DateOnly endDate = new DateOnly(tripCreate.EndDate.Year, tripCreate.EndDate.Month, tripCreate.EndDate.Day);

                // Panggil metode BLL dengan data yang telah dikonversi
                TripDTO createdTrip = await _tripBLL.Insert(new TripCreateDTO
                {
                    SubmittedBy = tripCreate.SubmittedBy,
                    StartDate = startDate,
                    EndDate = endDate,
                    Location = tripCreate.Location,
                    StatusID = tripCreate.StatusID
                });

                return Ok(createdTrip);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = _tripBLL.GetById(id).Result;
            if (trip.StatusID == 1)
            {
                await _tripBLL.Delete(id);
                return Ok($"Delete data id:{id} success");
            }
            return BadRequest($"Data Trip is On Reimbursment Progress");
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            try
            {
                // Panggil metode BLL untuk memperbarui status trip
                var updatedTrip = await _tripBLL.UpdateStatusId(id);

                // Jika trip berhasil diperbarui, kembalikan respon OK dengan data trip yang telah diperbarui
                return Ok(updatedTrip);
            }
            catch (Exception ex)
            {
                // Jika terjadi kesalahan, tangani dan kembalikan respon BadRequest dengan pesan kesalahan
                return BadRequest($"Failed to update trip status: {ex.Message}");
            }
        }
    }
}
