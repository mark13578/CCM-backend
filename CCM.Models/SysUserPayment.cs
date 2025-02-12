using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    public class SysUserPayment
    {
        public string uuid { get; set; }
        public string sys_user_uuid { get; set; }
        public string paytype { get; set; }
        public string cardnum { get; set; }
        public string bankcode { get; set; }
        public string bankacc { get; set; }
        public string virtualacc { get; set; }
        public int balance { get; set; }
        public string comment { get; set; }
        public DateTime create_time { get; set; }
        public DateTime modify_time { get; set; }

        public SysUserPayment(string uuid_, string sys_user_uuid_, string paytype_, string cardnum_, string bankcode_, string bankacc_, string virtualacc_, int balance_, string comment_, DateTime create_time_, DateTime modify_time_)
        {
            this.uuid = uuid_;
            this.sys_user_uuid = sys_user_uuid_;
            this.paytype = paytype_;
            this.cardnum = cardnum_;
            this.bankcode = bankcode_;
            this.bankacc = bankacc_;
            this.virtualacc = virtualacc_;
            this.balance = balance_;
            this.comment = comment_;
            this.create_time = create_time_;
            this.modify_time = modify_time_;
        }
    }
}
