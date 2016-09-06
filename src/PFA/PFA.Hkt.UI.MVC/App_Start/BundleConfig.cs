using System.Web;
using System.Web.Optimization;

namespace PFA.Hkt.UI.MVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Css Bundles


            bundles.Add(new StyleBundle("~/bundles/Style/Lib").Include(
                        "~/Content/Lib/Bootstrap/bootstrap.css"
                
                        ));

            //Bundle for branding style sheets
            bundles.Add(new StyleBundle("~/bundles/Style/Branding").Include(
                        "~/Content/Branding/brand.css"));

            #endregion







            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/Style/Lib").Include(
                        "~/Content/Lib/Bootstrap/bootstrap.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/Style/Branding").Include(
                       "~/Content/Branding/brand.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Core").Include(
                            "~/Scripts/core/jquery-{version}.js",
                            "~/Scripts/core/jquery.validate.js",
                            "~/Scripts/core/bootstrap.js",
                             "~/Scripts/utility/tooltip-viewport.js",
                            "~/Scripts/core/angular.js",
                            "~/Scripts/core/angular-route.js",
                            "~/Scripts/core/angular-sanitize.js",
                            "~/Scripts/core/lodash.js",
                            "~/Scripts/core/bootstrap-multiselect.js"));

            //Bundle for Telerik javascript file
            bundles.Add(new ScriptBundle("~/bundles/Lib/Telerik").Include(
                            "~/Scripts/lib/Telerik/kendo.all.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}