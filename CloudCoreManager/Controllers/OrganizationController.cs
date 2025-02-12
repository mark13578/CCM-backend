using System.Security.Cryptography;
using System.Text;
using CCM.Models;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IAuthService _authService;
        private const string PersonalRoleUuid = "00000000-0000-0000-0000-000000000001"; // 預設個人用戶組 UUID

        public OrganizationController(IOrganizationService organizationService, IAuthService authService)
        {
            _organizationService = organizationService;
            _authService = authService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysOrganization>> GetAll()
        {
            return Ok(_organizationService.GetAllOrganizations());
        }

        [HttpGet("{uuid}")]
        public ActionResult<SysOrganization> GetById(Guid uuid)
        {
            var organization = _organizationService.GetOrganizationById(uuid);
            if (organization == null)
                return NotFound();

            return Ok(organization);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SysOrganization organization)
        {
            _organizationService.CreateOrganization(organization);
            return CreatedAtAction(nameof(GetById), new { uuid = organization.Uuid }, organization);
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(Guid uuid, [FromBody] SysOrganization organization)
        {
            try
            {
                _organizationService.UpdateOrganization(uuid, organization);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(Guid uuid)
        {
            _organizationService.DeleteOrganization(uuid);
            return NoContent();
        }

        [HttpPost("upload-users/{orgUuid}")]
        public async Task<IActionResult> UploadUsers(Guid orgUuid, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(",");

                    var user = new SysUser
                    {
                        Username = values[0],
                        Password = HashPassword(values[1]),
                        RealName = values[2],
                        Email = values[3],
                        Phone = values[4],
                        Uuid = Guid.NewGuid()
                    };

                    _authService.Register(new RegisterRequest
                    {
                        Username = user.Username,
                        Password = values[1],
                        RealName = user.RealName,
                        Email = user.Email,
                        Phone = user.Phone,
                        RoleUuid = orgUuid // ✅ 使用企業的 UUID 作為角色
                    });
                }
            }

            return Ok("Users uploaded successfully.");
        }

        [HttpPost("add-user/{orgUuid}")]
        public IActionResult AddUser(Guid orgUuid, [FromBody] RegisterRequest request)
        {
            try
            {
                _authService.Register(new RegisterRequest
                {
                    Username = request.Username,
                    Password = request.Password,
                    RealName = request.RealName,
                    Email = request.Email,
                    Phone = request.Phone,
                    RoleUuid = orgUuid // ✅ 使用企業的 UUID 作為角色
                });
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

