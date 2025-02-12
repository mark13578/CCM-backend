using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    public class SysRole
    {
        [Key]
        public Guid Uuid { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
