using log4net;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet.Security.Attribute {
    public class MP_OAuth : AuthorizeAttribute {
        private static readonly ILog log = LogManager.GetLogger(typeof(MP_OAuth));

        public static IList<string> wechatAgnet = new[] { "MicroMessenger", "Windows Phone" };

        public static bool IsWeChat(HttpRequestBase request) {
            log.Info(request.UserAgent);
            return IsWeChat(request.UserAgent);
        }

        public static bool IsWeChat(string userAgent) {
            return !string.IsNullOrEmpty(userAgent) && wechatAgnet.Any(userAgent.Contains);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext context) {
            log.Info("HandleUnauthorizedRequest");
            if (context == null) {
                throw new ArgumentNullException("filterContext");
            }

            //else {
            //    string path = context.HttpContext.Request.Path;
            //    string strUrl = "~/Account/Login?returnUrl={0}";

            //    context.HttpContext.Response.Redirect(string.Format(strUrl, HttpUtility.UrlEncode(path)), true);
            //}
            //context.Result = new RedirectResult("/");

            if (false && !IsWeChat(context.RequestContext.HttpContext.Request)) {//非微信
                log.Info("非微信,跳转到登录页面");
                context.Result = new RedirectResult("/Account/MyLogin");

            }else {
                string CorpID = ConfigurationManager.AppSettings["WeChatCorpId"];
                string Secret = ConfigurationManager.AppSettings["WeChatCorpSecret"];
                string Flag_MockUserId = null;// ConfigurationManager.AppSettings[BaseDictType.CRMTest];
                if (!string.IsNullOrEmpty(Flag_MockUserId)) {
                    //AuthorizationService.SetAuthSession(int.Parse(Flag_MockUserId));
                    //return true;
                }

                var Session = context.Controller.ControllerContext.HttpContext.Session;
                //log.Info("sessionID:" + Session.SessionID);
                //var wechat = new WeChatOAuth();
                //var empCode = wechat.TryGetOpenIdFromOAuthState(CorpID, Session.SessionID);
                //log.Info("empCode=" + empCode);
                //if (!string.IsNullOrEmpty(empCode)) {
                //    var empBL = BLLFactory.Create<IBaseEmployeeBL>();
                //    var emp = empBL.GetEmployeeByCode(empCode);
                //    if (emp == null) {
                //        return false;
                //    }
                //    var userBL = BLLFactory.Create<IBaseUserBL>();
                //    BaseUser user = null;
                //    if (!string.IsNullOrEmpty(Flag_MockUserId)) {
                //        user = userBL.GetUser(int.Parse(Flag_MockUserId));
                //    } else {
                //        user = userBL.GetUser(emp.ID);
                //    }
                //    AuthorizationService.SetAuthSession((int)user.ID);
                //    filterContext.Result = Redirect(Request.Url.ToString());
                //    return true;
                //}
                log.Info("微信验证");
                string returnUrl = "http://www.managersi.top/Home/Index";
                var url = OAuthApi.GetAuthorizeUrl(CorpID,
                "http://www.managersi.top/OAuthCallback/Index?returnUrl=" + returnUrl,
                Session.SessionID, OAuthScope.snsapi_base);
                log.Info(url);
                context.Result = new RedirectResult(url);
            }
        }

     
    }
}