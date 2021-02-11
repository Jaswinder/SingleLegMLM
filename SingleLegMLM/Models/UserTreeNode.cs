using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class UserTreeNode
    {
        public int Msrno { get; set; }
        public string MemberId { get; set; }
        public string SponsorId { get; set; }
        public int IntroMsrNo { get; set; }
        public string UpId { get; set; }
        public int UpMsrNo { get; set; }
        public string MemberName { get; set; }
        public string SponserName { get; set; }
        public string UpName { get; set; }
        public string Photo { get; set; }

    }
}