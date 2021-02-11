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
    public class AdminController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public AdminController()
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
              CreateParameter(DbType.String, 50, "@UserName", ParameterDirection.InputOutput,Username),
              CreateParameter(DbType.String, 50, "@Password", ParameterDirection.InputOutput,Password),

            };
            string cmd = "Select * from Usermaster where UserName=@UserName and Password=@Password";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                var Usermaster = CommonMethod.ConvertToList<Usermaster>(dt).FirstOrDefault();
                gMSRNO = Usermaster.Sno;
                gMemberName = Usermaster.Name ?? "";;
                gRole = "ADMIN";
                gUsername = gMSRNO.ToString();

                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag._DisplayMsg = "Wrong username or password";
            return View();
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