using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class tblWalletDetails
    {
        public int CNT { get; set; }
        public int MsrNo { get; set; }
        public decimal Amount { get; set; }
        public int TransactionWith { get; set; }
        public string Description { get; set; }
        public DateTime DateOn { get; set; }
        public string ByAdmin { get; set; }
        public string Usertype { get; set; }
        public string TType { get; set; }
        public int IsLast { get; set; }
        public decimal TDS { get; set; }
        public decimal GST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }

    }
}