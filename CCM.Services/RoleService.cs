using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

namespace CCM.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<SysRole> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public SysRole GetRoleById(Guid uuid)
        {
            return _roleRepository.GetRoleById(uuid);
        }

        public void CreateRole(SysRole role)
        {
            role.Uuid = Guid.NewGuid();
            _roleRepository.AddRole(role);
        }

        public void UpdateRole(Guid uuid, SysRole role)
        {
            var existingRole = _roleRepository.GetRoleById(uuid);
            if (existingRole == null)
                throw new Exception("Role not found.");

            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;

            _roleRepository.UpdateRole(existingRole);
        }

        public void DeleteRole(Guid uuid)
        {
            _roleRepository.DeleteRole(uuid);
        }
    }
}
