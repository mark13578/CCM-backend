using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IPermissionRepository
    {
        IEnumerable<SysPermission> GetAllPermissions();
        SysPermission GetPermissionById(Guid uuid);
        void AddPermission(SysPermission permission);
        void UpdatePermission(SysPermission permission);
        void DeletePermission(Guid uuid);
        bool PermissionExists(Guid permissionUuid);
    }
}
