using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CCM.Services;
using CCM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                var modelRequest = new CCM.Models.RegisterRequest
                {
                    Username = request.Username,
                    Password = request.Password,
                    RealName = request.RealName,
                    IdNumber = request.IdNumber,
                    docfile1 = request.docfile1,
                    docfile2 = request.docfile2,
                    docfile2type = request.docfile2type,
                    Phone = request.Phone,
                    Country = request.Country,
                    State = request.State,
                    District = request.District,
                    Address = request.Address,
                    ZipCode = request.ZipCode,
                    Email = request.Email,
                    orgid = request.orgid,
                    CreateTime = request.CreateTime,
                    ModifyTime = request.ModifyTime
                };
                var result = _authService.Register(modelRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _authService.Login(request.Username, request.Password);
                return Ok(new { Token = token });

            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("You have accessed a protected route!");
        }




        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var uuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = _authService.GetProfile(uuid);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            try
            {
                var uuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _authService.UpdateProfile(uuid, request);
                return Ok("Profile updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("profile")]
        public IActionResult DeleteProfile()
        {
            try
            {
                var uuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _authService.DeleteUser(uuid);
                return Ok("Account deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}