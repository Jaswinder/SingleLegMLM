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
    public class LevelsController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public LevelsController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }
        // GET: Levels
        public ActionResult Index()
        {
            string cmd = "Select * from LevelMaster;";
            var dt = fetchdata.GetDataTable(cmd);
            var list = CommonMethod.ConvertToList<LevelMaster>(dt).ToList();
            return View(list);
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