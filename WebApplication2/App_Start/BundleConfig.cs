using System.Web;
using System.Web.Optimization;

namespace WebApplication2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/Content/AngularApp/App.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/i18n/angular-locale_en-150.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/angular-resource.js")
                .Include("~/Scripts/angular-mocks.js")
                .Include("~/Scripts/angular-messages.js")
                .Include("~/Scripts/angular-cookies.js")
                .Include("~/Scripts/angular-sanitize.js")
                .Include("~/Scripts/angular-animate.js")
                .Include("~/Scripts/angular-ui/ui-bootstrap-tpls.js")
                .Include("~/Scripts/angular-ui/ui-utils.js")
                .Include("~/Scripts/angular-ui/ui-utils-ieshiv.js")
                .Include("~/Scripts/angular-ui-router.js")
                .Include("~/Scripts/ui-grid.js")
                );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ui-grid.css",
                      "~/Content/ui-bootstrap-csp.css",
                      "~/Content/site.css"));
        }
    }
}
