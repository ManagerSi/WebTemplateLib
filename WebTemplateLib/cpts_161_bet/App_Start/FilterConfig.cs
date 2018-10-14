using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
