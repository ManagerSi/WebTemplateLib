using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace cpts_161_bet.Security {
    public class MyPrincipal : System.Security.Principal.IPrincipal {
        protected MyIdentity identity;

        public MyPrincipal(MyIdentity identity) {
            this.identity = identity;
        }
        #region IPricipal成员
        public IIdentity Identity {
            get {
                return identity;
            }
        }

        public bool IsInRole(string role) {
            if(identity!=null && identity.Roles!=null)
                return identity.Roles.Contains(role);
            else { return false; }
        }
        #endregion
    }
}
