using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_organization")]
    public class SysOrganization
    {
        [Key]
        [Column("uuid")]
        public Guid Uuid { get; set; }

        [Column("orgname")]
        [Required, MaxLength(50)]
        public string OrgName { get; set; }

        [Column("tel")]
        [Required, MaxLength(16)]
        public string Tel { get; set; }

        [Column("ext")]
        public string? Ext { get; set; }

        [Column("guinumber")]
        [Required, MaxLength(9)]
        public string GuiNumber { get; set; }

        [Column("admin_uuid")]
        public Guid? AdminUuid { get; set; }

        [Column("tech_uuid")]
        public Guid? TechUuid { get; set; }

        [Column("acc_uuid")]
        public Guid? AccUuid { get; set; }

        [Column("docfile")]
        public string? DocFile { get; set; }

        [Column("permission")]
        public string? Permission { get; set; }
    }
}
