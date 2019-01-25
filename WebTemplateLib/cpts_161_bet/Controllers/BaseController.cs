using cpts_161_bet.Security;
using DataBaseLib;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cpts_161_bet.Controllers {
    public class BaseController:System.Web.Mvc.Controller {
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseController));

        protected static int count = 0;
        protected static object locker = new object();
        private DateTime startTime;
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (true) {
                int local_count;
                lock (locker) {
                    count++;
                    local_count = count;
                };
                log.Info("executing uri={" + filterContext.RequestContext.HttpContext.Request.RawUrl + "},count =" + local_count);
                //log.Info("executing uri(" + DateTime.Now + ")" + count + "=" + filterContext.RequestContext.HttpContext.Request.RawUrl);
            }
            startTime = DateTime.Now;
            HttpContext.Trace.Write("Action Executing");
            ViewBag.CurrentControllerName = filterContext.RouteData.Values["controller"];
            //if (filterContext.RouteData.DataTokens["area"].ToString() == "Wap") {
            filterContext.HttpContext.Response.Buffer = true;
            filterContext.HttpContext.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            filterContext.HttpContext.Response.Expires = 0;
            filterContext.HttpContext.Response.CacheControl = "no-cache";
            filterContext.HttpContext.Response.AppendHeader("Pragma", "No-Cache");
            filterContext.HttpContext.Response.AppendHeader("X-Wap-Proxy-Cookie", "none");
            filterContext.HttpContext.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            //}

            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
            //if(filterContext.RouteData.Values["controller"].ToString() == "Report" && filterContext.RouteData.DataTokens["area"].ToString() == "Admin") {
            //  filterContext.Result = RedirectToAction("Index","Dashboard");
            //}
            if (true) {
                int local_count;
                lock (locker) {
                    count--;
                    local_count = count;
                };
                log.Info("executed uri={" + filterContext.RequestContext.HttpContext.Request.RawUrl + "},count =" + local_count);
            }
            var delta = DateTime.Now - startTime;
            if (delta.TotalMilliseconds > 1000) {
                log.Fatal("slow executing =" + delta.TotalMilliseconds + ",uri=" + filterContext.RequestContext.HttpContext.Request.RawUrl);
            }

            base.OnActionExecuted(filterContext);
            HttpContext.Trace.Write("OnActionExecuted");
        }
        protected override void OnAuthorization(AuthorizationContext filterContext) {
            log.Info(this.GetType() + "OnAuthorization");
            var session = new BLSessionPersisiter();
            filterContext.HttpContext.User = new MyPrincipal(
              new MyIdentity(session.UserID));
            base.OnAuthorization(filterContext);
        }

    }
}
