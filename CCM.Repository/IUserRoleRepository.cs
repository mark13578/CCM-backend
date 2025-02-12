using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IUserRoleRepository
    {
        void AddUserRole(SysUserRole userRole);
        IEnumerable<SysUserRole> GetUserRolesByUserId(Guid userUuid);
    }
}
