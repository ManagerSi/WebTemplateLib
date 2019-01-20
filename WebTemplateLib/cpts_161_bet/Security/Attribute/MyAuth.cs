using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet.Security.Attribute {
    public class MyAuth: AuthorizeAttribute {

        //protected override void HandleUnauthorizedRequest(AuthorizationContext context) {
        //    if (context == null) {
        //        throw new ArgumentNullException("filterContext");
        //    } else {
        //        string path = context.HttpContext.Request.Path;
        //        string strUrl = "~/Account/Login?returnUrl={0}";

        //        context.HttpContext.Response.Redirect(string.Format(strUrl, HttpUtility.UrlEncode(path)), true);
        //    }
        //    context.Result = new RedirectResult("/");
        //}

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
        //    base.HandleUnauthorizedRequest(filterContext);
        //    if (filterContext.HttpContext.Response.StatusCode == 401) {
        //        filterContext.Result = new RedirectResult("~/Account/Login");
        //    }
        //}
    }
}