using System.Web;
using System.Web.Optimization;

namespace UsedCar.WebFront.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css/layout").Include(
                "~/Content/css/layout.css"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Content/js/custom.js",
                "~/Content/js/jquery.cookie.js"
                ));

        }
    }
}