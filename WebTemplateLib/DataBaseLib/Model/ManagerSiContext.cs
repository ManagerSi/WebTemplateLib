using System;
using System.Web;
//using System.Data.EntityClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;

namespace DataBaseLib.Model {
    public partial class ManagerSiContext : DbContext {
    public ManagerSiContext(EntityConnection cnt)
      : base(cnt, true) {
    }

    public ManagerSiContext(string nameOrContectingString)
      : base(nameOrContectingString) {
    }

    public override int SaveChanges() {
      return base.SaveChanges();
    }

    #region 单实例 (Per request)
    private const string kDBContextKEY = "tsic_ctx";
    private const string kDBTranscationKEY = "tsic_trans";



    static public ManagerSiContext CurrentHttpContext {
      get {

        HttpContext context = HttpContext.Current;
        if (context == null) {
          throw new ApplicationException("There is no Http Context available");
        }
        lock (context) {
          ManagerSiContext cur = CurrentHttpContextWeak;
          if (cur == null) {
            cur = NewContext(false);
            CurrentHttpContextWeak = cur;
          }
          return cur;
        }
      }
    }

    public static ManagerSiContext NewContext(bool open) {
      var cnt = new EntityConnection("name=ManagerSiContext");
      if (open) {
        cnt.Open();
      }
      return new ManagerSiContext(cnt);
    }

    static private ManagerSiContext CurrentHttpContextWeak {
      get { return HttpContext.Current.Items[kDBContextKEY] as ManagerSiContext; }
      set { HttpContext.Current.Items[kDBContextKEY] = value; }
    }

    static internal void TryDisposeCurrentHttpContext() {
      HttpContext context = HttpContext.Current;
      if (context == null) {
        throw new ApplicationException("There is no Http Context available");
      }
      lock (context) {
        ManagerSiContext cur = CurrentHttpContextWeak;
        if (cur != null) {
          //cur.Database.Connection.Close();
          cur.Dispose();
          CurrentHttpContextWeak = null;
          
          
        }
      }
    }
    public void SetCommandTimeout(int? timeOut) {
      var objectContext = (this as IObjectContextAdapter).ObjectContext;
      // Sets the command timeout for all the commands
      objectContext.CommandTimeout = timeOut;
    }
    public int? GetCommandTimeout() {
      var objectContext = (this as IObjectContextAdapter).ObjectContext;
      // Gets the command timeout for all the commands
      return objectContext.CommandTimeout;
    }
    #endregion
  }
}