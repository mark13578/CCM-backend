using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IRolePermissionRepository
    {
        IEnumerable<SysRolePermission> GetAllRolePermissions();
        SysRolePermission GetRolePermissionById(Guid uuid);
        void AddRolePermission(SysRolePermission rolePermission);
        void UpdateRolePermission(SysRolePermission rolePermission);
        void DeleteRolePermission(Guid uuid);
    }

   
}
