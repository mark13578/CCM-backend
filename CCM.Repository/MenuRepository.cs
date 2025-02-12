using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SysMenu> GetAllMenus()
        {
            return _context.SysMenu.ToList();
        }

        public SysMenu GetMenuById(Guid uuid)
        {
            return _context.SysMenu.FirstOrDefault(m => m.Uuid == uuid);
        }

        public void AddMenu(SysMenu menu)
        {
            _context.SysMenu.Add(menu);
            _context.SaveChanges();
        }

        public void UpdateMenu(SysMenu menu)
        {
            _context.SysMenu.Update(menu);
            _context.SaveChanges();
        }

        public void DeleteMenu(Guid uuid)
        {
            var menu = GetMenuById(uuid);
            if (menu != null)
            {
                _context.SysMenu.Remove(menu);
                _context.SaveChanges();
            }
        }
    }
}
