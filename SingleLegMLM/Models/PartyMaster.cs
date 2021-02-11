using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SingleLegMLM.Models
{
    public class PartyMaster
    {
        public int Msrno { get; set; }
        public string MemberId { get; set; }
        public string SponsorId { get; set; }
        public int IntroMsrNo { get; set; }
        public string UpId { get; set; }
        public int UpMsrNo { get; set; }
        public string Sex { get; set; }
        public string MemberName { get; set; }
        public DateTime DOJ { get; set; }
        public string CareOfTitle { get; set; }
        public string CareOfName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Phones { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string MStatus { get; set; }
        public string NName { get; set; }
        public string NRelation { get; set; }
        public DateTime NDOB { get; set; }
        public int MScheme { get; set; }
        public string PMode { get; set; }
        public string DDNo { get; set; }
        public string DDDate { get; set; }
        public string Password { get; set; }
        public DateTime Paiddt { get; set; }
        public string IsActive { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AcNo { get; set; }
        public string PanNo { get; set; }
        public string DtUser { get; set; }
        public string ETicket { get; set; }
        public int Rejoining { get; set; }
        public int DeActive { get; set; }
        public DateTime LastLogin { get; set; }
        public int LegC { get; set; }
        public int PageOPTION { get; set; }
        public string tempLeg { get; set; }
        public string Scode { get; set; }
        public string Nameprefix { get; set; }
        public string Coupan { get; set; }
        public string Cuopan1 { get; set; }
        public string ISFC { get; set; }
        public string UserUode { get; set; }
        public string InvoiceNo { get; set; }
        public int StateID { get; set; }
        public int IsPrint { get; set; }
        public DateTime BillDate { get; set; }
        public int IsPan { get; set; }
        public int PaymentOptionId { get; set; }
        public string IsTransferAc { get; set; }
        public string IsTransferVoucher { get; set; }
        public int Submscheme { get; set; }
        public string Remark { get; set; }
        public int Shipping { get; set; }
        public int ByMsrno { get; set; }
        public int Isdocument { get; set; }
        public DateTime DocumentDt { get; set; }
        public int OldMscheme { get; set; }

        public string AadharNo { get; set; }
        public string SponsorName { get; set; }
        public string UniqueUrl { get; set; }

        public string Photo { get; set; }

        public string OTP { get; set; }
        public bool IsMobileVerified { get; set; }

    }
}