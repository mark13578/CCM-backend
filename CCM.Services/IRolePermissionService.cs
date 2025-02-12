using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IRolePermissionService
    {
        IEnumerable<SysRolePermission> GetAllRolePermissions();
        SysRolePermission GetRolePermissionById(Guid uuid);
        void CreateRolePermission(SysRolePermission rolePermission);
        void UpdateRolePermission(Guid uuid, SysRolePermission rolePermission);
        void DeleteRolePermission(Guid uuid);
    }
}
