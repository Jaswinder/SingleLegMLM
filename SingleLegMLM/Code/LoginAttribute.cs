using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
//using System.Web.Http.Filters;
using System.Web.Mvc;

namespace SingleLegMLM.Code
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class LoginAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsLoggedIn == false)
            {
                filterContext.Result = new RedirectResult(redirectUrl);

            }

        }

        protected String redirectUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings["redirectUrl"];
            }
        }

        private bool IsLoggedIn
        {
            get
            {
                if (HttpContext.Current.Session["Username"] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}