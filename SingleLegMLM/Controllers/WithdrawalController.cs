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
    public class WithdrawalController : BaseController
    {
        // GET: Withdrawal
        public ActionResult Index()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View(model);
        }

        public ActionResult SingleLegEarning()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View("Index",model);
        }
        public ActionResult ReferEarning()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View("Index", model);
        }
        public ActionResult RoyaltyEarning()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View("Index", model);
        }
        public ActionResult LeadershipEarning()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View("Index", model);
        }
        public ActionResult AllCreditDebit()
        {
            List<tblWalletDetails> model = new List<tblWalletDetails>();
            return View("Index", model);
        }
    }
}