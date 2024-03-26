using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Helpers;
using API.Models;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffBLL _staffBLL;
        private readonly AppSettings _appSettings;
        
        public StaffController(IStaffBLL staffBLL, IOptions<AppSettings> appSettings)
        {
            _staffBLL = staffBLL;
            _appSettings = appSettings.Value;
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

        [HttpPut]
        public async Task<IActionResult> ChangePassword(string username, string password)
        {
            try
            {
                var staff = await _staffBLL.GetByUsername(username);
                if (staff == null)
                {
                    return NotFound("User not found");
                }

                // Periksa jika ada pemanggilan metode ChangePassword di sini
                await _staffBLL.ChangePassword(username, password);
                return Ok("Password changed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] StaffLoginDTO loginDTO)
        {
            try
            {
                var staff = await _staffBLL.Login(loginDTO.Username, loginDTO.Password);
                if (staff == null)
                {
                    return Unauthorized(new { message = "Invalid username or password" });
                }

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginDTO.Username));
                
                var tokenHandler = new JwtSecurityTokenHandler();

                //_logger.LogInformation($"---------------------------> {_appSettings.Secret}");
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                //_logger.LogInformation($"---------------------------> Token generated for {tokenHandler.WriteToken(token)}");
                var tokenDto = new TokenDTO
                {
                    Username = loginDTO.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(tokenDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
