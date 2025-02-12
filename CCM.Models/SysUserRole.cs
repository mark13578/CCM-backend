using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    public class SysUserRole
    {
        [Key]
        public Guid Uuid { get; set; }
        public Guid UserUuid { get; set; }
        public Guid RoleUuid { get; set; }
    }
}
