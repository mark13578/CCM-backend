using CCM.Models;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysPermission>> GetAll()
        {
            return Ok(_permissionService.GetAllPermissions());
        }

        [HttpGet("{uuid}")]
        public ActionResult<SysPermission> GetById(Guid uuid)
        {
            var permission = _permissionService.GetPermissionById(uuid);
            if (permission == null)
                return NotFound();

            return Ok(permission);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SysPermission permission)
        {
            _permissionService.CreatePermission(permission);
            return CreatedAtAction(nameof(GetById), new { uuid = permission.Uuid }, permission);
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(Guid uuid, [FromBody] SysPermission permission)
        {
            try
            {
                _permissionService.UpdatePermission(uuid, permission);
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
            _permissionService.DeletePermission(uuid);
            return NoContent();
        }
    }
}
