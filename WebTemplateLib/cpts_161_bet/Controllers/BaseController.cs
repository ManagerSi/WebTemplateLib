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

        protected override void OnAuthorization(AuthorizationContext filterContext) {
            var session = new BLSessionPersisiter();
            filterContext.HttpContext.User = new MyPrincipal(
              new MyIdentity(session.UserID));
            base.OnAuthorization(filterContext);
        }

    }
}
