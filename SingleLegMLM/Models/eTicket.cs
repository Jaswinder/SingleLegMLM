using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class eTicket
    {
        public int PinId { get; set; }
        public DateTime GenDate { get; set; }
        public int Nos { get; set; }
        public string UserId { get; set; }
        public string ETicket { get; set; }
        public int IsPrint { get; set; }
        public int IsUsed { get; set; }
        public int IsCancel { get; set; }
        public int ItemId { get; set; }
        public string PMode { get; set; }
        public string DDNo { get; set; }
        public DateTime DDDate { get; set; }
        public int EpinNo { get; set; }
        public string Narration { get; set; }
        public string Bank { get; set; }
        public string UserType { get; set; }
        public string Transfer { get; set; }
        public int ToMsrno { get; set; }
        public DateTime ToDate { get; set; }
        public string MemberId { get; set; }
        

    }
}