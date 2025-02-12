using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCM.Models
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }


    
        public string docfile1 { get; set; }
 
        public string docfile2 { get; set; }
   
        public string docfile2type { get; set; }




        public string? ZipCode { get; set; }



        public int? orgid { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }




    }
}
