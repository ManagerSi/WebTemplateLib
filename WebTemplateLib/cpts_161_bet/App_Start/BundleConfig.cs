using System.Web;
using System.Web.Optimization;

namespace cpts_161_bet {
    public class BundleConfig {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //sitecss
            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                      "~/Resource/CSS/style.css"));
            //sitejs
            bundles.Add(new ScriptBundle("~/Content/sitejs").Include(
                    //jquery
                        "~/Resource/Javascript/jQuery/jquery-1.7.2.min.js",
                        //flot
                        "~/Resource/Javascript/Flot/jquery.flot.js",
                        "~/Resource/Javascript/Flot/jquery.flot.resize.js",
                        "~/Resource/Javascript/Flot/jquery.flot.pie.js",
                        //DataTables
                        "~/Resource/Javascript/DataTables/jquery.dataTables.min.js",
                        //ColResizable
                        "~/Resource/Javascript/ColResizable/colResizable-1.3.js",
                        //jQuryUI
                        "~/Resource/Javascript/jQueryUI/jquery-ui-1.8.21.min.js",
                        //Uniform
                        "~/Resource/Javascript/Uniform/jquery.uniform.js",
                        //Tipsy
                        "~/Resource/Javascript/Tipsy/jquery.tipsy.js",
                        //Elastic
                        "~/Resource/Javascript/Elastic/jquery.elastic.js",
                        //ColorPicker
                        "~/Resource/Javascript/ColorPicker/colorpicker.js",
                        //SuperTextarea
                        "~/Resource/Javascript/SuperTextarea/jquery.supertextarea.min.js",
                        //UISpinner
                        "~/Resource/Javascript/UISpinner/ui.spinner.js",
                         //MaskedInput
                         "~/Resource/Javascript/MaskedInput/jquery.maskedinput-1.3.js",
                        //ClEditor
                        "~/Resource/Javascript/ClEditor/jquery.cleditor.js",
                         //Full Calendar
                         "~/Resource/Javascript/FullCalendar/fullcalendar.js",
                        //Color Box
                        "~/Resource/Javascript/ColorBox/jquery.colorbox.js",
                         //Kanrisha Script
                         "~/Resource/Javascript/kanrisha.js"
                        ));
            
        }
    }
}
