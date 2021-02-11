using SingleLegMLM.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SingleLegMLM.Models;

namespace SingleLegMLM.Controllers
{
    public class AccountController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public AccountController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string Username = form["Username"].ToString();
            string Password = form["Password"].ToString();

            IDbDataParameter[] param = new[]
            {
              CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.InputOutput,Username),
              CreateParameter(DbType.String, 50, "@Password", ParameterDirection.InputOutput,Password),
           
            };
            string cmd = "Select * from PartyMaster where MemberId=@MemberId and Password=@Password and DeActive=0";
            ds = fetchdata.GetDataSet(cmd, param,CommandType.Text);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                
                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
                if (PartyMasterlist != null)
                {
                    gMSRNO = PartyMasterlist.Msrno;
                    gIntroMsrNo = PartyMasterlist.IntroMsrNo;
                    gIntroId = PartyMasterlist.SponsorId ?? "";
                    gMemberId = PartyMasterlist.MemberId ?? "";
                    gMemberName = PartyMasterlist.MemberName ?? "";
                    gMobile = PartyMasterlist.Mobile ?? "";
                    gUsername = gMSRNO.ToString();
                    gRole = "USER";
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            ViewBag._DisplayMsg = "Wrong username or password";
            return View();
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

            if(!CheckSponserId(model.SponsorId))
            {
                ViewBag.DisplayClass = "text-red";
                ViewBag._DisplayMsg = "Please enter a valid SponsorId";
                return View(model);
            }
           // IDbDataParameter[] param = new[]
           //{
           //   CreateParameter(DbType.String, 50, "@PanNo", ParameterDirection.InputOutput,model.PanNo),

           // };
           // string cmd = "Select * from PartyMaster where PanNo=@PanNo";
           // ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
           // if (ds.Tables.Count > 0)
           // {
           //     var dt = ds.Tables[0];

           //     var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
           //     if (PartyMasterlist == null)
           //     {
                    var UnigueUrl = Guid.NewGuid().ToString().Replace("-","");
                    var OTP = CreateEPin(7);
                    IDbDataParameter[] Insertparam = new[]
                   {
                      CreateParameter(DbType.String, 50, "@SponsorId", ParameterDirection.Input,model.SponsorId),
                      CreateParameter(DbType.String, 100, "@SponsorName", ParameterDirection.Input,model.SponsorName),
                      CreateParameter(DbType.String, 100, "@MemberName", ParameterDirection.Input,model.MemberName),
                      CreateParameter(DbType.String, 10, "@Sex", ParameterDirection.Input,model.Sex),
                      CreateParameter(DbType.String, 50, "@PanNo", ParameterDirection.Input,""),
                      CreateParameter(DbType.String, 50, "@Mobile", ParameterDirection.Input,model.Mobile),
                      CreateParameter(DbType.String, 50, "@Email", ParameterDirection.Input,model.Email),
                      CreateParameter(DbType.String, 50, "@Password", ParameterDirection.Input,model.Password),
                      CreateParameter(DbType.String, 500, "@UnigueUrl", ParameterDirection.Input,UnigueUrl),
                      CreateParameter(DbType.String, 50, "@OTP", ParameterDirection.Input,OTP),
                      CreateParameter(DbType.String, 50, "@OUTMemberID", ParameterDirection.Output,""),
                  };
                    string cmd = "spInsertMember";
                    var memberid=fetchdata.ExecuteQuerySP(cmd, Insertparam, CommandType.StoredProcedure);
                    var name = model.MemberName + " Your MemberId is " + memberid;
                    //SendOTP(model.Mobile, OTP,name);
                    SendWelcomeMsg(model.Mobile, model.MemberName, memberid, model.Password);
            //return RedirectToAction("VerifyMobile",new {id= memberid });
            //    }
            //}
            ViewBag.DisplayClass = "text-green";
            ViewBag._DisplayMsg = "Your account has been created. You can login to your account Now.";
            model = new PartyMaster();
            return View(model);
        }
        public ActionResult VerifyMobile(string id="")
        {
            ViewBag.MemberId = id;
            return View();
        }
        [HttpPost]
        public ActionResult VerifyMobile(string memberid, string otp)
        {
            IDbDataParameter[] param = new[]
         {
              CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.InputOutput,memberid),

            };
            string cmd = "Select * from PartyMaster where MemberId=@MemberId";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            if (ds.Tables.Count > 0)
            {
                var dt = ds.Tables[0];

                var PartyMasterlist = CommonMethod.ConvertToList<PartyMaster>(dt).FirstOrDefault();
                if (PartyMasterlist != null)
                {
                    if(PartyMasterlist.OTP == otp)
                    {
                        IDbDataParameter[] insertparam = new[]
                         {
                              CreateParameter(DbType.String, 50, "@MemberId", ParameterDirection.InputOutput,memberid),

                         };
                        cmd = "update PartyMaster set IsMobileVerified=1 where MemberId=@MemberId";
                        fetchdata.ExecuteQuery(cmd, insertparam, CommandType.Text);
                        SendWelcomeMsg(PartyMasterlist.Mobile, PartyMasterlist.MemberName, PartyMasterlist.MemberId, PartyMasterlist.Password);
                        return View("Index");
                    }
                }
            }
            ViewBag.MemberId = memberid;
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
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