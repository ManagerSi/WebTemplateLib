using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace cpts_161_bet.Security {
    public interface IBLSessionPersisiter : ISessionPersisiter {
        decimal UserID { get; set; }
        string UserName { get; set; }
        //BaseEmployee BaseEmployee { get; set; }

        ICollection<string> Roles { get; set; }

    }

    public class BLSessionPersisiter : SessionPersisiter, IBLSessionPersisiter {
        protected const string sessionUserIDKey = "_s_userid";
        protected const string sessionUserNameKey = "_s_username";
        protected const string sessionRolesKey = "_s_roles";
        protected const string sessionBaseEmployeeKey = "_s_baseemp";
       
        // remove by one passport
        //protected const string sessionUserTypeKey = "_s_usertype";
        public decimal UserID {
            get {
                return GetValue<decimal>(sessionUserIDKey, -1);
            }
            set {
                SetValue(sessionUserIDKey, value);
            }
        }
        public string UserName {
            get {
                return GetValue<string>(sessionUserNameKey, "SI");
            }
            set {
                SetValue(sessionUserNameKey, value);
            }
        }
        //public BaseEmployee BaseEmployee {
        //    get {
        //        var id = GetValue<decimal>(sessionBaseEmployeeKey, -1);
        //        if (id < 0) {
        //            return null;
        //        }

        //        return BLLFactory.Create<IBaseEmployeeBL>().GetEmployeeByCached(id);
        //    }
        //    set {
        //        SetValue(sessionBaseEmployeeKey, value.ID);
        //    }
        //}

        public ICollection<string> Roles {
            get {
                return GetValue<ICollection<string>>(sessionRolesKey, null);
            }
            set {
                SetValue(sessionRolesKey, value);
            }
        }

        public override bool RemoveSession() {
            if (HttpContext.Current == null) {
                throw new InvalidOperationException();
            }
            var session = HttpContext.Current.Session;
            
            session.Remove(sessionUserIDKey);
            session.Remove(sessionUserNameKey);
            session.Remove(sessionBaseEmployeeKey);
            session.Remove(sessionRolesKey);
         
            return true;
        }
    }
}
