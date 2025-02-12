using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

namespace CCM.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        public IEnumerable<SysRolePermission> GetAllRolePermissions()
        {
            return _rolePermissionRepository.GetAllRolePermissions();
        }

        public SysRolePermission GetRolePermissionById(Guid uuid)
        {
            return _rolePermissionRepository.GetRolePermissionById(uuid);
        }

        public void CreateRolePermission(SysRolePermission rolePermission)
        {
            if (!_roleRepository.RoleExists(rolePermission.RoleUuid))
                throw new Exception("Role does not exist.");

            if (!_permissionRepository.PermissionExists(rolePermission.PermissionUuid))
                throw new Exception("Permission does not exist.");

            rolePermission.Uuid = Guid.NewGuid();
            _rolePermissionRepository.AddRolePermission(rolePermission);
        }

        public void UpdateRolePermission(Guid uuid, SysRolePermission rolePermission)
        {
            var existingRolePermission = _rolePermissionRepository.GetRolePermissionById(uuid);
            if (existingRolePermission == null)
                throw new Exception("Role Permission not found.");

            if (!_roleRepository.RoleExists(rolePermission.RoleUuid))
                throw new Exception("Role does not exist.");

            if (!_permissionRepository.PermissionExists(rolePermission.PermissionUuid))
                throw new Exception("Permission does not exist.");

            existingRolePermission.RoleUuid = rolePermission.RoleUuid;
            existingRolePermission.PermissionUuid = rolePermission.PermissionUuid;

            _rolePermissionRepository.UpdateRolePermission(existingRolePermission);
        }

        public void DeleteRolePermission(Guid uuid)
        {
            _rolePermissionRepository.DeleteRolePermission(uuid);
        }
    }
}
