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
    public class MyPinsController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public MyPinsController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Epin
        public ActionResult Index()
        {
            string cmd = "SELECT eTicket.PinId, eTicket.ETicket,eTicket.IsUsed,eTicket.IsCancel,eTicket.Narration, eTicket.GenDate, eTicket.EpinNo, eTicket.ToMsrno, PartyMaster.MemberId, PartyMaster.Msrno FROM eTicket CROSS JOIN PartyMaster where eTicket.ToMsrno = PartyMaster.Msrno and eTicket.ToMsrno="+gMSRNO;
            var dt = fetchdata.GetDataTable(cmd);
            var list = CommonMethod.ConvertToList<eTicket>(dt).ToList();
            return View(list);
        }
        public ActionResult AssignPin(int id,string q)
        {
            PartyMaster model = new PartyMaster();
            ViewBag.PinId = id;
            ViewBag.ETicket = q;
            return View(model);
        }
        [HttpPost]
        public ActionResult AssignPin(int id, string q, string memberid, PartyMaster umodel, string btn="")
        {
            if (btn == "Assign Pin")
            {

                SqlTransaction trans = fetchdata.GetTrans();

              
                IDbDataParameter[] param = new[]
                {
                CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.Input,umodel.MemberId),
                CreateParameter(DbType.String, 50, "@ETicket", ParameterDirection.Input,q),
                };
                string cmd = "Update PartyMaster set ETicket=@ETicket where MemberId=@MemberId";
                fetchdata.ExecuteQuery(cmd,param, trans, CommandType.Text);

                IDbDataParameter[] eparam = new[]
               {
                CreateParameter(DbType.Int32, 50, "@PinId", ParameterDirection.Input,id),
                CreateParameter(DbType.String, 50, "@ETicket", ParameterDirection.Input,q),
                };
                cmd = "Update eTicket set IsUsed=1 where PinId=@PinId";
                fetchdata.ExecuteQuery(cmd, eparam, trans, CommandType.Text);

                IDbDataParameter[] insertparam = new[]
               {
                CreateParameter(DbType.String, 50, "@MemberID", ParameterDirection.Input,umodel.MemberId),
                CreateParameter(DbType.Int32, 50, "@Msrno", ParameterDirection.Input,umodel.Msrno),
                CreateParameter(DbType.Int32, 50, "@ETicketId", ParameterDirection.Input,id),
                CreateParameter(DbType.DateTime, 50, "@Paiddt", ParameterDirection.Input,DateTime.Now),
                };
                string ncmd = "insert into GreenDetail(Msrno,MemberID,ETicketId,Paiddt) values(@Msrno,@MemberID,@ETicketId,@Paiddt)";
                fetchdata.ExecuteQuery(ncmd, insertparam, trans, CommandType.Text);

                trans.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                PartyMaster model = GetProfileById(memberid);
                ViewBag.PinId = id;
                ViewBag.ETicket = q;
                return View(model);
            }
        }
        private PartyMaster GetProfileById(string id="")
        {
            var model = new PartyMaster();
            string cmd = "Select * from PartyMaster where MemberId='" + id+"'";
            ds = fetchdata.GetDataSet(cmd);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                model = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
            }
            return model;
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