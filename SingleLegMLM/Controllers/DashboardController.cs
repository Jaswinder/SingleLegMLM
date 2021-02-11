using SingleLegMLM.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SingleLegMLM.Models;
using System.Data.SqlClient;
using SingleLegMLM.Code;

namespace SingleLegMLM.Controllers
{
    [Login]
    public class DashboardController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public DashboardController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.ReferalUrl= ConfigurationSettings.AppSettings["RegeralUrl"] + gMemberId;
            ViewBag.Wallet = GetWallet();
            ViewBag.TotalTeams = 0;
            ViewBag.Greenteams = 0;
            ViewBag.Redteams = 0;

            ViewBag.MyDirect = 0;
            ViewBag.SINGLEINC = 0;
            ViewBag.REFERINC = 0;
            ViewBag.TODAYREFE = 0;
            ViewBag.ROYALTYINC = 0;
            ViewBag.LEADERSHIPINC = 0;
            ViewBag.TOTALEARNE = 0;
            ViewBag.LATESTEARNIN = 0;



            GetTeams();
            return View();
        }
        public void GetTeams()
        {
            string cmd = "Select * from PartyMaster where deactive=0 and Msrno > " + gMSRNO;
            var dt = fetchdata.GetDataTable(cmd);
            var list = CommonMethod.ConvertToList<PartyMaster>(dt).ToList();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    var totalTeams = list.Count();
                    var greenTeams = list.Where(x => x.ETicket != "0").Count();
                    var redTeams = list.Where(x => x.ETicket == "0").Count();
                    ViewBag.TotalTeams = totalTeams;
                    ViewBag.Greenteams = greenTeams;
                    ViewBag.Redteams = redTeams;
                    ViewBag.MyDirect = list.Where(x=>x.SponsorId==gMemberId).Count();
                }

            }
           
        }

        public decimal GetWallet()
        {
            decimal total = 0;
            //tblWalletDetails
            string cmd = "Select * from tblWalletDetails where MsrNo="+gMSRNO;
            var dt = fetchdata.GetDataTable(cmd);
            var list = CommonMethod.ConvertToList<tblWalletDetails>(dt).ToList();
            if (list != null)
            {
                if (list.Count > 0)
                {
                    total = list.Sum(x => x.Amount);
                }
                else
                {
                    total = 0;
                }

            }
            else
            {
                total = 0;
            }
            return total;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fetchdata.Dispose();
                fetchdata = null;
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }
    }
}