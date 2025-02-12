using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<SysRole> GetAllRoles();
        SysRole GetRoleById(Guid uuid);
        void AddRole(SysRole role);
        void UpdateRole(SysRole role);
        void DeleteRole(Guid uuid);
        bool RoleExists(Guid roleUuid);

    }
}
