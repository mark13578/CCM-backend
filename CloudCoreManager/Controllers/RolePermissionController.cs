using CCM.Models;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysRolePermission>> GetAll()
        {
            return Ok(_rolePermissionService.GetAllRolePermissions());
        }

        [HttpGet("{uuid}")]
        public ActionResult<SysRolePermission> GetById(Guid uuid)
        {
            var rolePermission = _rolePermissionService.GetRolePermissionById(uuid);
            if (rolePermission == null)
                return NotFound();

            return Ok(rolePermission);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SysRolePermission rolePermission)
        {
            try
            {
                _rolePermissionService.CreateRolePermission(rolePermission);
                return CreatedAtAction(nameof(GetById), new { uuid = rolePermission.Uuid }, rolePermission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(Guid uuid, [FromBody] SysRolePermission rolePermission)
        {
            try
            {
                _rolePermissionService.UpdateRolePermission(uuid, rolePermission);
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
            _rolePermissionService.DeleteRolePermission(uuid);
            return NoContent();
        }
    }
}
