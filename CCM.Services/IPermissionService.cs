using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IPermissionService
    {
        IEnumerable<SysPermission> GetAllPermissions();
        SysPermission GetPermissionById(Guid uuid);
        void CreatePermission(SysPermission permission);
        void UpdatePermission(Guid uuid, SysPermission permission);
        void DeletePermission(Guid uuid);
    }
}
