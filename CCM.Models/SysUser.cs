using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    [Table("sys_user")]
    public class SysUser
    {
        [Key]
        [Column("uuid")]
        public Guid Uuid { get; set; } // 主键

        [Column("username")]
        [Required, MaxLength(20)]
        public string Username { get; set; } // 用户名

        [Column("password")]
        [Required, MaxLength(60)]
        public string Password { get; set; } // 密码
        [Column("googleuid")]
        public string GoogleUid { get; set; } // 谷歌验证器

        [Column("realname")]
        public string? RealName { get; set; } // 真实姓名


        [Column("nickname")]
        public string? NickName { get; set; } // 昵称

        [Column("idnumber")]
        public string? IdNumber { get; set; } // 身份证号

        [Column("docfile1")]
        public string docfile1 { get; set; }
        [Column("docfile2")]
        public string docfile2 { get; set; }
        [Column("docfile2type")]
        public string docfile2type { get; set; }

        [Column("phone")]
        public string? Phone { get; set; } //電話    

        [Column("country")]
        public string? Country { get; set; }     //国家

        [Column("state")]
        public string? State { get; set; }  // 省份

        [Column("district")]
        public string? District { get; set; }  // 城市

        [Column("address")]
        public string? Address { get; set; }     //地址

        [Column("zipcode")]
        public string? ZipCode { get; set; }

        [Column("email")]
        public string? Email { get; set; }


        [Column("orgid")]
        public int? orgid { get; set; }


        [Column("pve_token")]
        public string? pve_token { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("modify_time")]
        public DateTime ModifyTime { get; set; }

        [Column("lastotp")]
        public string lastotp { get; set; }
        [Column("verifycode")]

        public string verifycode { get; set; }
        [Column("isverified")]
        public byte isverified { get; set; }
        [Column("verifyexp_time")]
        public DateTime verifyexp_time { get; set; }


    }
}
