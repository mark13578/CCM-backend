using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_menu")]
    public class SysMenu
    {
        [Key]
        public Guid Uuid { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Path { get; set; }

        public string Icon { get; set; }


        public Guid? ParentUuid { get; set; } // 父選單 (可為 null)

        public int Order { get; set; }


        public int Visible { get; set; }


        public bool IsActive { get; set; } = true;
    }
}
