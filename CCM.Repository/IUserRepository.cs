using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IUserRepository
    {
        SysUser GetUserByUsername(string username);
        SysUser GetUserById(Guid uuid);
        void AddUser(SysUser user);
        void UpdateUser(SysUser user);
        void DeleteUser(Guid uuid);
    }
}
