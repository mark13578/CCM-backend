using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AppDbContext _context;

        public RolePermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SysRolePermission> GetAllRolePermissions()
        {
            return _context.SysRolePermission.ToList();
        }

        public SysRolePermission GetRolePermissionById(Guid uuid)
        {
            return _context.SysRolePermission.FirstOrDefault(rp => rp.Uuid == uuid);
        }

        public void AddRolePermission(SysRolePermission rolePermission)
        {
            _context.SysRolePermission.Add(rolePermission);
            _context.SaveChanges();
        }

        public void UpdateRolePermission(SysRolePermission rolePermission)
        {
            _context.SysRolePermission.Update(rolePermission);
            _context.SaveChanges();
        }

        public void DeleteRolePermission(Guid uuid)
        {
            var rolePermission = GetRolePermissionById(uuid);
            if (rolePermission != null)
            {
                _context.SysRolePermission.Remove(rolePermission);
                _context.SaveChanges();
            }
        }
    }
}
