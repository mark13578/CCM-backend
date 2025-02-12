using CCM.Models;
using CCM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCM.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysMenu>> GetAll()
        {
            return Ok(_menuService.GetAllMenus());
        }

        [HttpGet("{uuid}")]
        public ActionResult<SysMenu> GetById(Guid uuid)
        {
            var menu = _menuService.GetMenuById(uuid);
            if (menu == null)
                return NotFound();

            return Ok(menu);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SysMenu menu)
        {
            _menuService.CreateMenu(menu);
            return CreatedAtAction(nameof(GetById), new { uuid = menu.Uuid }, menu);
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(Guid uuid, [FromBody] SysMenu menu)
        {
            try
            {
                _menuService.UpdateMenu(uuid, menu);
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
            _menuService.DeleteMenu(uuid);
            return NoContent();
        }
    }
}
