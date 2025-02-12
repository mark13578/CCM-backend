using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SysRole> GetAllRoles()
        {
            return _context.SysRole.ToList();
        }

        public SysRole GetRoleById(Guid uuid)
        {
            return _context.SysRole.FirstOrDefault(r => r.Uuid == uuid);
        }

        public void AddRole(SysRole role)
        {
            _context.SysRole.Add(role);
            _context.SaveChanges();
        }

        public void UpdateRole(SysRole role)
        {
            _context.SysRole.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Guid uuid)
        {
            var role = GetRoleById(uuid);
            if (role != null)
            {
                _context.SysRole.Remove(role);
                _context.SaveChanges();
            }
        }

      
        public bool RoleExists(Guid roleUuid)
        {
            return _context.SysRole.Any(r => r.Uuid == roleUuid);
        }
    }
}
