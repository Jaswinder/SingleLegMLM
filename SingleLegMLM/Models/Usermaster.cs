using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class Usermaster
    {
        public int Sno { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public string Name { get; set; }
        public string TIN { get; set; }
        public string ParentCode { get; set; }
        public string Type { get; set; }
        public decimal Creditlimit { get; set; }
        public string Epassword { get; set; }
        public int Block { get; set; }
        public string UserType { get; set; }
        public int BranchCode { get; set; }

    }
}