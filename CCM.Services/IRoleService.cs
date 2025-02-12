using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IRoleService
    {
        IEnumerable<SysRole> GetAllRoles();
        SysRole GetRoleById(Guid uuid);
        void CreateRole(SysRole role);
        void UpdateRole(Guid uuid, SysRole role);
        void DeleteRole(Guid uuid);
    }
}
