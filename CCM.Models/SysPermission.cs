using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_permission")]
    public class SysPermission
    {
        [Key]
        public Guid Uuid { get; set; }

        [Required]
        [MaxLength(100)]
        public string PermissionName { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public Guid? Menu_Uuid { get; set; }
    }
}
