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
    public class EpinController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public EpinController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Epin
        public ActionResult Index()
        {
            string cmd = "SELECT eTicket.PinId, eTicket.ETicket,eTicket.IsUsed,eTicket.IsCancel,eTicket.Narration, eTicket.GenDate, eTicket.EpinNo, eTicket.ToMsrno, PartyMaster.MemberId, PartyMaster.Msrno FROM eTicket CROSS JOIN PartyMaster where eTicket.ToMsrno = PartyMaster.Msrno";
            var dt = fetchdata.GetDataTable(cmd);
            var list = CommonMethod.ConvertToList<eTicket>(dt).ToList();
            return View(list);
        }
        public ActionResult GenerateEpin()
        {
            var model = new eTicket();
            ViewBag.ToMsrno = new SelectList(GetMembers(), "Value", "Text", "");
            model.Nos = 1;
            return View(model);
        }
        public int GetMaxEpin()
        {
            string cmd = "Select MAX(EpinNo) from eTicket";
            var ds = fetchdata.GetValue(cmd);
            if(String.IsNullOrEmpty(ds))
            {
                return 0;
            }
            return Convert.ToInt32(ds);
        }
        [HttpPost]
        public ActionResult GenerateEpin(eTicket model)
        {
            int ToMsrno = model.ToMsrno;
            string Narration = model.Narration;
            int Nos = model.Nos;
            SqlTransaction trans = fetchdata.GetTrans();
            int epinNo = GetMaxEpin();
            for (int i = 1; i <= Nos; i++)
            {
                epinNo = epinNo + 1;
                var ticket = CreateEPin(10) ;
                ticket = ticket + epinNo.ToString();
                IDbDataParameter[] Insertparam = new[]
                {
                    CreateParameter(DbType.DateTime, 50, "@GenDate", ParameterDirection.Input,DateTime.Now),
                    CreateParameter(DbType.Int32, 100, "@Nos", ParameterDirection.Input,i),
                    CreateParameter(DbType.String, 100, "@UserId", ParameterDirection.Input,gMSRNO),
                    CreateParameter(DbType.String, 50, "@ETicket", ParameterDirection.Input,ticket),
                    CreateParameter(DbType.Int32, 50, "@IsPrint", ParameterDirection.Input,0),
                    CreateParameter(DbType.Int32, 50, "@IsUsed", ParameterDirection.Input,0),
                    CreateParameter(DbType.Int32, 50, "@IsCancel", ParameterDirection.Input,0),
                    CreateParameter(DbType.Int32, 50, "@ItemId", ParameterDirection.Input,PlanID),
                    CreateParameter(DbType.Int32, 50, "@EpinNo", ParameterDirection.Input,epinNo),
                    CreateParameter(DbType.String, 4000, "@Narration", ParameterDirection.Input,Narration),
                    CreateParameter(DbType.String, 5000, "@Transfer", ParameterDirection.Input,""),
                    CreateParameter(DbType.Int32, 500, "@ToMsrno", ParameterDirection.Input,ToMsrno),
                };
               string cmd = "insert eTicket (GenDate,Nos,UserId,ETicket,IsPrint,IsUsed,IsCancel,ItemId,EpinNo,Narration,Transfer,ToMsrno)values(@GenDate,@Nos,@UserId,@ETicket,@IsPrint,@IsUsed,@IsCancel,@ItemId,@EpinNo,@Narration,@Transfer,@ToMsrno)";
               fetchdata.ExecuteQuery(cmd, Insertparam, trans, CommandType.Text);
            }
            trans.Commit();
            
            ViewBag.ToMsrno = new SelectList(GetMembers(), "Value", "Text", ToMsrno.ToString());
            return View(model);
        }

        public List<KeyPair> GetMembers()
        {
            IDbDataParameter[] param = new[]
           {
              CreateParameter(DbType.Int32, 50, "@deactive", ParameterDirection.InputOutput,0),

            };
            string cmd = "Select cast(Msrno as varchar) as Value,(MemberId +' - '+MemberName +' ('+Mobile+')') As Text from PartyMaster where deactive=@deactive";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];
                var list= CommonMethod.ConvertToList<KeyPair>(dt).ToList();
                return list;
            }
            return null;
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