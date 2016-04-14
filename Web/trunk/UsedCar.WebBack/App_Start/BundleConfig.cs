using System.Web;
using System.Web.Optimization;

namespace UsedCar.WebBack
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js"
                        "~/Content/charisma/bower_components/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Content/charisma/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Scripts/bootstrap-paginator.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/charisma/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/site.css"));

            #region 自定义（Charisma）

            bundles.Add(new ScriptBundle("~/bundles/charismajs").Include(
                //library for cookie management
                     "~/Content/charisma/js/jquery.cookie.js",
                //calender plugin
                     "~/Content/charisma/bower_components/moment/min/moment.min.js",
                     "~/Content/charisma/bower_components/fullcalendar/dist/fullcalendar.min.js",
                //data table plugin
                     "~/Content/charisma/js/jquery.dataTables.min.js",
                //select or dropdown enhancer
                     "~/Content/charisma/bower_components/chosen/chosen.jquery.min.js",
                //plugin for gallery image view
                     "~/Content/charisma/bower_components/colorbox/jquery.colorbox-min.js",
                //notification plugin
                     "~/Content/charisma/js/jquery.noty.js",
                //library for making tables responsive
                     "~/Content/charisma/bower_components/responsive-tables/responsive-tables.js",
                //tour plugin
                     "~/Content/charisma/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js",
                //star rating plugin
                     "~/Content/charisma/js/jquery.raty.min.js",
                //for iOS style toggle switch
                     "~/Content/charisma/js/jquery.iphone.toggle.js",
                //autogrowing textarea plugin
                     "~/Content/charisma/js/jquery.autogrow-textarea.js",
                //multiple file upload plugin
                     "~/Content/charisma/js/jquery.uploadify-3.1.min.js",
                //history.js for cross-browser state change on ajax
                     "~/Content/charisma/js/jquery.history.js",
                //application script for Charisma demo
                     "~/Content/charisma/js/charisma.js"));

            bundles.Add(new StyleBundle("~/Content/charismacss").Include(
                //"~/Content/charisma/css/bootstrap-cerulean.min.css",
                      "~/Content/charisma/css/charisma-app.css",
                      "~/Content/charisma/bower_components/fullcalendar/dist/fullcalendar.css",
                      "~/Content/charisma/bower_components/fullcalendar/dist/fullcalendar.print.css",
                      "~/Content/charisma/bower_components/chosen/chosen.min.css",
                      "~/Content/charisma/bower_components/colorbox/example3/colorbox.css",
                      "~/Content/charisma/bower_components/responsive-tables/responsive-tables.css",
                      "~/Content/charisma/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css",
                      "~/Content/charisma/css/jquery.noty.css",
                      "~/Content/charisma/css/noty_theme_default.css",
                      "~/Content/charisma/css/elfinder.min.css",
                      "~/Content/charisma/css/elfinder.min.css",
                      "~/Content/charisma/css/elfinder.theme.css",
                      "~/Content/charisma/css/jquery.iphone.toggle.css",
                      "~/Content/charisma/css/uploadify.css",
                      "~/Content/charisma/css/animate.min.css"
                      ));
            #endregion
        }
    }
}
