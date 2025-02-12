using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

namespace CCM.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<SysMenu> GetAllMenus()
        {
            return _menuRepository.GetAllMenus();
        }

        public SysMenu GetMenuById(Guid uuid)
        {
            return _menuRepository.GetMenuById(uuid);
        }

        public void CreateMenu(SysMenu menu)
        {
            menu.Uuid = Guid.NewGuid();
            _menuRepository.AddMenu(menu);
        }

        public void UpdateMenu(Guid uuid, SysMenu menu)
        {
            var existingMenu = _menuRepository.GetMenuById(uuid);
            if (existingMenu == null)
                throw new Exception("Menu not found.");

            existingMenu.Name = menu.Name;
            existingMenu.Path = menu.Path;
            existingMenu.ParentUuid = menu.ParentUuid;
            existingMenu.Order = menu.Order;
            existingMenu.IsActive = menu.IsActive;

            _menuRepository.UpdateMenu(existingMenu);
        }

        public void DeleteMenu(Guid uuid)
        {
            _menuRepository.DeleteMenu(uuid);
        }
    }
}
