using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    public class sys_organization
    {
        public string Uuid { get; set; }
        public string orgname { get; set; }
        public string tel { get; set; }
        public string Ext { get; set; }
        public string guinumber { get; set; }
        public string admin_uuid { get; set; }
        public string tech_uuid { get; set; }
        public string acc_uuid { get; set; }
        public string docfile { get; set; }
        public string permission { get; set; }

        public sys_organization(string uuid_, string orgname_, string tel_, string ext_, string guinumber_, string admin_uuid_, string tech_uuid_, string acc_uuid_, string docfile_, string permission_)
        {
            this.Uuid = uuid_;
            this.orgname = orgname_;
            this.tel = tel_;
            this.Ext = ext_;
            this.guinumber = guinumber_;
            this.admin_uuid = admin_uuid_;
            this.tech_uuid = tech_uuid_;
            this.acc_uuid = acc_uuid_;
            this.docfile = docfile_;
            this.permission = permission_;
        }
    }
}
