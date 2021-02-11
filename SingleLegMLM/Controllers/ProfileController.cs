using SingleLegMLM.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SingleLegMLM.Models;
using SingleLegMLM.Code;

namespace SingleLegMLM.Controllers
{
    [Login]
    public class ProfileController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public ProfileController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Profile
        public ActionResult Index()
        {
            var usr = GetMyProfile();
            return View(usr);
        }
        [HttpPost]
        public ActionResult Index(PartyMaster model)
        {
            var usr = GetMyProfile();

            if (Request.Files.Count > 0)
            {

                if (Request.Files["UploadFile"] != null)
                {

                    HttpPostedFileBase file = Request.Files["UploadFile"];
                    if (file.ContentLength > 0)
                    {
                        string value = ConfigurationManager.AppSettings["SliderPath"];
                        usr.Photo = Common.UploadImage(value, file, "pic_");
                    }

                }


                IDbDataParameter[] Insertparam = new[]
                  {
                      CreateParameter(DbType.String, 2000, "@Photo", ParameterDirection.Input,usr.Photo),
                      CreateParameter(DbType.String, 50, "@Msrno", ParameterDirection.Input,gMSRNO),

                  };
                var cmd = "Update PartyMaster set Photo=@Photo where Msrno=@Msrno";
                fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);

                gPic = usr.Photo;
                return RedirectToAction("Index");

            }


            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            
            if (model.NewPassword.Trim() == model.ConfirmPassword.Trim())
            {

                var usr = GetMyProfile();
                if (usr != null)
                {
                    if (usr.Password==model.OldPassword.Trim())
                    {
                        IDbDataParameter[] Insertparam = new[]
                     {
                      CreateParameter(DbType.String, 50, "@Password", ParameterDirection.Input,model.NewPassword),
                      CreateParameter(DbType.String, 50, "@Msrno", ParameterDirection.Input,gMSRNO),

                    };
                        var cmd = "Update PartyMaster set Password=@Password where Msrno=@Msrno";
                        fetchdata.ExecuteQuery(cmd, Insertparam, CommandType.Text);
                        ViewBag._DisplayMsg = "Password Changed";
                    }
                    else
                    {
                        ViewBag._DisplayMsg = "Old password does not match.";
                    }
                }


                
            }
            else
            {
                ViewBag._DisplayMsg = "New Password and Confirm Password does not match.";
            }
            return View();
        }


        private PartyMaster GetMyProfile()
        {
            var model = new PartyMaster();
            string cmd = "Select * from PartyMaster where Msrno="+gMSRNO;
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