using System.Web;
using System.Web.Optimization;

namespace MSPress
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/vendor_css").Include(
                "~/vendor/bootstrap/css/bootstrap.min.css",
                "~/vendor/metisMenu/metisMenu.min.css",
                "~/vendor/morrisjs/morris.css",
                "~/vendor/font-awesome/css/font-awesome.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/dist_css").Include(
                "~/dist/css/sb-admin-2.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap_core_js").Include(
               "~/vendor/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/metismenu_js").Include(
               "~/vendor/metisMenu/metisMenu.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/errata_js").Include(
                "~/Scripts/errata.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/dashboard_data_js").Include(
                           "~/data/morris.data.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard_dist_js").Include(
                           "~/dist/js/sb-admin-2.js"));

        }
    }
}
