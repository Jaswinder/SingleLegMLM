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
    public class TreeViewController : BaseController
    {
        DataSet ds;
        DataAccess fetchdata;
        public TreeViewController()
        {
            string odbcstring = ConfigurationSettings.AppSettings["SingleLegConnection"];
            ds = new DataSet();
            fetchdata = new DataAccess(odbcstring, 60);
        }

        // GET: TreeView
        public ActionResult Index()
        {
            List<UserTreeNode> PartyMasterlist = new List<UserTreeNode>();
            IDbDataParameter[] param = new[]
            {
              CreateParameter(DbType.String, 50, "@msrno", ParameterDirection.InputOutput,gMSRNO)
            };
            string cmd = "Select Msrno, MemberId,Photo, SponsorId,(select MemberName from PartyMaster where msrno = pm.IntroMsrNo) SponserName,IntroMsrNo,UpId,UpMsrNo,(select MemberName from PartyMaster where msrno = pm.UpMsrNo) UpName,MemberName from PartyMaster pm where msrno>=@msrno and deactive=0";
            ds = fetchdata.GetDataSet(cmd, param, CommandType.Text);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                PartyMasterlist = CommonMethod.ConvertToList<UserTreeNode>(dt).ToList();
            }
            ViewBag._DisplayMsg = "Nothing to Show";
            return View(PartyMasterlist);
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