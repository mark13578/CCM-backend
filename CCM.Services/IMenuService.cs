using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IMenuService
    {
        IEnumerable<SysMenu> GetAllMenus();
        SysMenu GetMenuById(Guid uuid);
        void CreateMenu(SysMenu menu);
        void UpdateMenu(Guid uuid, SysMenu menu);
        void DeleteMenu(Guid uuid);
    }
}
