using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DataBaseLib.Infrastructure.BLL;
namespace DataBaseLib.BLL {
  public partial class BLLFactory {
    static partial void ExtraInit() {
      //RegisterBL("IBaseLog", typeof(IBaseLog), typeof(BaseLog));
    }
    static bool disableBLLService = false;
    public static void DisableBLLService() {
      disableBLLService = true;
    }
    public static void EnableBLLService() {
      disableBLLService = false;
    }

    public static IBLLService CurrentService {
      get {
        if (disableBLLService) {
          return null;
        }
        HttpContext context = HttpContext.Current;
        if (context == null) {
          //throw new ApplicationException("There is no Http Context available");
          return null;
        }
        lock (context) {
          IBLLService cur = CurrentServiceWeak;
          if (cur == null) {
            cur = CreateService();
            CurrentServiceWeak = cur;
          }
          return cur;
        }
      }
    }

    private const string kDBContextKEY = "tsic_bl_svr";

    static private IBLLService CurrentServiceWeak {
      get { return HttpContext.Current.Items[kDBContextKEY] as IBLLService; }
      set { HttpContext.Current.Items[kDBContextKEY] = value; }
    }


    public static IBLLService CreateService() {
      return new BLLService(new DataBaseLib.DAL.UnitOfWork());
    }
  }
}
