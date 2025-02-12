using Microsoft.AspNetCore.Mvc;
using CCM.Models;
using CCM.Services;
using System;
namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysRole>> GetAll()
        {
            return Ok(_roleService.GetAllRoles());
        }

        [HttpGet("{uuid}")]
        public ActionResult<SysRole> GetById(Guid uuid)
        {
            var role = _roleService.GetRoleById(uuid);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SysRole role)
        {
            _roleService.CreateRole(role);
            return CreatedAtAction(nameof(GetById), new { uuid = role.Uuid }, role);
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(Guid uuid, [FromBody] SysRole role)
        {
            try
            {
                _roleService.UpdateRole(uuid, role);
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
            _roleService.DeleteRole(uuid);
            return NoContent();
        }
    }
}
