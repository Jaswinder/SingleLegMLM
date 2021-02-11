using SingleLegMLM.Code;
using SingleLegMLM.Data;
using SingleLegMLM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingleLegMLM.Controllers
{
    [Login]
    public class PartyMasterController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public PartyMasterController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: PartyMaster
        public ActionResult Index()
        {
            DateTime today = DateTime.Now.Date;
            IDbDataParameter[] param = new[]
            {
              CreateParameter(DbType.DateTime, 50, "@FromDOJ", ParameterDirection.InputOutput,today),
              CreateParameter(DbType.DateTime, 50, "@ToDOJ", ParameterDirection.InputOutput,today),

            };
            // string cmd = "Select * from PartyMaster where DOJ >= @FromDOJ and DOJ <= @ToDOJ";
            string cmd = "Select * from PartyMaster";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).ToList();
                return View(PartyMasterlist);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime FromDate,DateTime Todate)
        {
            DateTime today = DateTime.Now.Date;
            IDbDataParameter[] param = new[]
            {
              CreateParameter(DbType.DateTime, 50, "@FromDOJ", ParameterDirection.InputOutput,FromDate),
              CreateParameter(DbType.DateTime, 50, "@ToDOJ", ParameterDirection.InputOutput,Todate),

            };
            // string cmd = "Select * from PartyMaster where DOJ >= @FromDOJ and DOJ <= @ToDOJ";
            string cmd = "Select * from PartyMaster";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).ToList();
                return View(PartyMasterlist);
            }
            return View();
        }
        public ActionResult PersonalDetails(string id = "")
        {
            if (gRole == "USER")
            {
                id = gMemberId;
            }
            var model = new PartyMaster();
            model = GetProfileById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult PersonalDetails(PartyMaster umodel)
        {
            string dob = umodel.DOB.Day +"/" + umodel.DOB.Month + "/" + umodel.DOB.Year;

            IDbDataParameter[] Insertparam = new[]
            {
                CreateParameter(DbType.String, 100, "@MemberName", ParameterDirection.Input,(umodel.MemberName)),
                CreateParameter(DbType.String, 4, "@CareOfName", ParameterDirection.Input,(umodel.CareOfName)),
                CreateParameter(DbType.String, 10, "@Sex", ParameterDirection.Input,(umodel.Sex)),
                CreateParameter(DbType.String, 50, "@DOB", ParameterDirection.Input,dob),
                CreateParameter(DbType.String, 500, "@Address", ParameterDirection.Input,(umodel.Address)),
                CreateParameter(DbType.String, 50, "@City", ParameterDirection.Input,(umodel.City)),
                CreateParameter(DbType.String, 50, "@State", ParameterDirection.Input,(umodel.State)),
                CreateParameter(DbType.String, 50, "@PinCode", ParameterDirection.Input,(umodel.PinCode)),
                CreateParameter(DbType.String, 100, "@Phones", ParameterDirection.Input,(umodel.Phones)),
                CreateParameter(DbType.String, 50, "@Mobile", ParameterDirection.Input,(umodel.Mobile)),
                CreateParameter(DbType.String, 50, "@Email", ParameterDirection.Input,(umodel.Email)),
                CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.Input,(umodel.MemberId))
            };
            var cmd = "Update PartyMaster set MemberName='@MemberName',CareOfName='@CareOfName',Sex='@Sex',DOB=convert(datetime,'@DOB',103),Address='@Address',City='@City',State='@State',PinCode=@PinCode,Phones='@Phones',Mobile='@Mobile',Email='@Email' where MemberId='@MemberId'";
            fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);
            ViewBag._DisplayMsg = "Personal Details Updated";
            // var model = GetProfileById(umodel.MemberId);
            return View(umodel);
        }
        public ActionResult BankDetails(string id = "")
        {
            if (gRole == "USER")
            {
                id = gMemberId;
            }
            var model = new PartyMaster();
            model = GetProfileById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult BankDetails(PartyMaster umodel)
        {

            IDbDataParameter[] Insertparam = new[]
             {
                CreateParameter(DbType.String, 50, "@AcNo", ParameterDirection.Input,umodel.AcNo),
                CreateParameter(DbType.String, 200, "@BankName", ParameterDirection.Input,umodel.BankName),
                CreateParameter(DbType.String, 50, "@BranchName", ParameterDirection.Input,umodel.BranchName),
                CreateParameter(DbType.String, 200, "@ISFC", ParameterDirection.Input,umodel.ISFC),
                CreateParameter(DbType.String, 50, "@AadharNo", ParameterDirection.Input,umodel.AadharNo),
                CreateParameter(DbType.String, 50, "@PanNo", ParameterDirection.Input,umodel.PanNo),
                CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.Input,umodel.MemberId),

            };
            var cmd = "Update PartyMaster set AcNo=@AcNo,BankName=@BankName,BranchName=@BranchName,ISFC=@ISFC,AadharNo=@AadharNo,PanNo=@PanNo where MemberId=@MemberId";
            fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);
            ViewBag._DisplayMsg = "Bank Details Updated";
            //var model = GetProfileById(umodel.MemberId);
            return View(umodel);
        }
        public ActionResult Deactivate(string id = "")
        {
            IDbDataParameter[] Insertparam = new[]
             {
                CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.Input,id),

            };
            var cmd = "Update PartyMaster set DeActive=1 where MemberId=@MemberId";
            fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);
            return RedirectToAction("Index");
        }
        public ActionResult Activate(string id = "")
        {
            IDbDataParameter[] Insertparam = new[]
             {
                CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.Input,id),

            };
            var cmd = "Update PartyMaster set DeActive=0 where MemberId=@MemberId";
            fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);
            return RedirectToAction("Index");
        }
        private PartyMaster GetProfileById(string id = "")
        {
            var model = new PartyMaster();
            string cmd = "Select * from PartyMaster where MemberId='" + id + "'";
            ds = fetchdata.GetDataSet(cmd);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                model = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
            }
            return model;
        }

        public ActionResult Register(string id = "")
        {
            PartyMaster model = new PartyMaster();
            model.SponsorId = id;
            return View(model);
        }
        private bool CheckSponserId(string id)
        {
            IDbDataParameter[] param = new[]
          {
              CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.InputOutput,id),

            };
            string cmd = "Select * from PartyMaster where MemberId=@MemberId";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];

                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
                if (PartyMasterlist != null)
                {
                    return true;
                }
                return false;
            }
            return false;

        }
        [HttpPost]
        public ActionResult Register(PartyMaster model)
        {

            if (!CheckSponserId(model.SponsorId))
            {
                ViewBag._DisplayMsg = "Please enter a valid SponsorId";
                return View(model);
            }
            IDbDataParameter[] param = new[]
           {
              CreateParameter(DbType.String, 50, "@PanNo", ParameterDirection.InputOutput,model.PanNo),

            };
            string cmd = "Select * from PartyMaster where PanNo=@PanNo";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];

                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
                if (PartyMasterlist == null)
                {
                    var UnigueUrl = Guid.NewGuid().ToString().Replace("-", "");
                    var OTP = CreateEPin(7);
                    IDbDataParameter[] Insertparam = new[]
                   {
                      CreateParameter(DbType.String, 50, "@SponsorId", ParameterDirection.Input,model.SponsorId),
                      CreateParameter(DbType.String, 100, "@SponsorName", ParameterDirection.Input,model.SponsorName),
                      CreateParameter(DbType.String, 100, "@MemberName", ParameterDirection.Input,model.MemberName),
                      CreateParameter(DbType.String, 10, "@Sex", ParameterDirection.Input,model.Sex),
                      CreateParameter(DbType.String, 50, "@PanNo", ParameterDirection.Input,model.PanNo),
                      CreateParameter(DbType.String, 50, "@Mobile", ParameterDirection.Input,model.Mobile),
                      CreateParameter(DbType.String, 50, "@Email", ParameterDirection.Input,model.Email),
                      CreateParameter(DbType.String, 50, "@Password", ParameterDirection.Input,model.Password),
                      CreateParameter(DbType.String, 500, "@UnigueUrl", ParameterDirection.Input,UnigueUrl),
                      CreateParameter(DbType.String, 50, "@OTP", ParameterDirection.Input,OTP),
                      CreateParameter(DbType.String, 50, "@OUTMemberID", ParameterDirection.Output,""),
                  };
                    cmd = "spInsertMember";
                    var memberid = fetchdata.ExecuteQuerySP(cmd, Insertparam, CommandType.StoredProcedure);
                    SendWelcomeMsg(model.Mobile, model.MemberName, memberid, model.Password);
                    return RedirectToAction("Index");
                }
            }
            ViewBag._DisplayMsg = "Please use different Pan number, this is already used";
            return View(model);
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