using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SysPermission> GetAllPermissions()
        {
            return _context.SysPermission.ToList();
        }

        public SysPermission GetPermissionById(Guid uuid)
        {
            return _context.SysPermission.FirstOrDefault(p => p.Uuid == uuid);
        }

        public void AddPermission(SysPermission permission)
        {
            _context.SysPermission.Add(permission);
            _context.SaveChanges();
        }

        public void UpdatePermission(SysPermission permission)
        {
            _context.SysPermission.Update(permission);
            _context.SaveChanges();
        }

        public void DeletePermission(Guid uuid)
        {
            var permission = GetPermissionById(uuid);
            if (permission != null)
            {
                _context.SysPermission.Remove(permission);
                _context.SaveChanges();
            }
        }

        public bool PermissionExists(Guid permissionUuid)
        {
            return _context.SysPermission.Any(p => p.Uuid == permissionUuid);
        }
    }
}
