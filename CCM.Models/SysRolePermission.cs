using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_role_permission")]
    public class SysRolePermission
    {
        [Key]
        public Guid Uuid { get; set; }

        [Required]
        public Guid RoleUuid { get; set; }

        [Required]
        public Guid PermissionUuid { get; set; }
    }
}
