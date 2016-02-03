using System.Web;
using System.Web.Optimization;

namespace RestfulSecurity
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Libraries/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/Libraries/jquery-ui-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Libraries/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Libraries/bootstrap.js",
                      "~/Scripts/Libraries/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jQueryUI/css").Include(
                    "~/Content/jQueryUI/accordion.css",
                    "~/Content/jQueryUI/all.css",
                    "~/Content/jQueryUI/autocomplete.css",
                    "~/Content/jQueryUI/base.css",
                    "~/Content/jQueryUI/button.css",
                    "~/Content/jQueryUI/core.css",
                    "~/Content/jQueryUI/datepicker.css",
                    "~/Content/jQueryUI/dialog.css",
                    "~/Content/jQueryUI/draggable.css",
                    "~/Content/jQueryUI/menu.css",
                    "~/Content/jQueryUI/progressbar.css",
                    "~/Content/jQueryUI/resizable.css",
                    "~/Content/jQueryUI/selectable.css",
                    "~/Content/jQueryUI/selectmenu.css",
                    "~/Content/jQueryUI/slider.css",
                    "~/Content/jQueryUI/sortable.css",
                    "~/Content/jQueryUI/spinner.css",
                    "~/Content/jQueryUI/tabs.css",
                    "~/Content/jQueryUI/theme.css",
                    "~/Content/jQueryUI/tooltip.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout/js").Include("~/Scripts/Libraries/knockout-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom/js").Include("~/Scripts/patient.js"));
        }
    }
}