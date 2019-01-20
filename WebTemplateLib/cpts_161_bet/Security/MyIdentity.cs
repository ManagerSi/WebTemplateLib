using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpts_161_bet.Security {
    public class MyIdentity : System.Security.Principal.IIdentity {
        public MyIdentity(decimal userID) {
            this.UserID = userID;
        }
        public decimal UserID { get; set; }
        protected IBLSessionPersisiter session;
        public ICollection<string> Roles {
            get { return session.Roles; }
        }

        #region IIdentity成员
        public string AuthenticationType {
            get {
                return "MyLib";
            }
        }

        public bool IsAuthenticated {
            get { return UserID > 0; }
        }

        public string Name {
            get {  return session==null ?"Si": session.UserName; }
        }
        #endregion
    }
}
