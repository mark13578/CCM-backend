using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_user_role")]
    public class SysUserRole
    {
        [Key]
        public Guid Uuid { get; set; }
        public Guid UserUuid { get; set; }
        public Guid RoleUuid { get; set; }
    }
}
