using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IMenuRepository
    {
        IEnumerable<SysMenu> GetAllMenus();
        SysMenu GetMenuById(Guid uuid);
        void AddMenu(SysMenu menu);
        void UpdateMenu(SysMenu menu);
        void DeleteMenu(Guid uuid);
    }
}
