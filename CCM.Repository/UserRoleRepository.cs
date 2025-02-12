using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUserRole(SysUserRole userRole)
        {
            _context.SysUserRole.Add(userRole);
            _context.SaveChanges();
        }

        public IEnumerable<SysUserRole> GetUserRolesByUserId(Guid userUuid)
        {
            return _context.SysUserRole.Where(ur => ur.UserUuid == userUuid).ToList();
        }
    }
}
