using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

namespace CCM.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public IEnumerable<SysPermission> GetAllPermissions()
        {
            return _permissionRepository.GetAllPermissions();
        }

        public SysPermission GetPermissionById(Guid uuid)
        {
            return _permissionRepository.GetPermissionById(uuid);
        }

        public void CreatePermission(SysPermission permission)
        {
            permission.Uuid = Guid.NewGuid();
            _permissionRepository.AddPermission(permission);
        }

        public void UpdatePermission(Guid uuid, SysPermission permission)
        {
            var existingPermission = _permissionRepository.GetPermissionById(uuid);
            if (existingPermission == null)
                throw new Exception("Permission not found.");

            existingPermission.PermissionName = permission.PermissionName;
            existingPermission.Description = permission.Description;

            _permissionRepository.UpdatePermission(existingPermission);
        }

        public void DeletePermission(Guid uuid)
        {
            _permissionRepository.DeletePermission(uuid);
        }
    }
}
