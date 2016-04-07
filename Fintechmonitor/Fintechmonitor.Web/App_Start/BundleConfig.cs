using System.Web;
using System.Web.Optimization;

namespace Fintechmonitor.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);

            RegisterScriptBundles(bundles);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            var headStyles = new StyleBundle("~/bundles/css").Include
            (
                "~/libs/bootstrap/css/bootstrap.min.css",
                "~/libs/font-awesome/css/font-awesome.min.css",
                "~/libs/jquery.scrollbar/jquery.scrollbar.css",
                "~/libs/ionrangeslider/css/ion.rangeSlider.css",
                "~/libs/ionrangeslider/css/ion.rangeSlider.skinFlat.css",
                "~/libs/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.min.css",
                "~/libs/datatables/media/css/dataTables.bootstrap.min.css",
                "~/libs/selectize/dist/css/selectize.default.css",
                "~/libs/selectize/dist/css/selectize.bootstrap3.css",
                "~/libs/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                "~/libs/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css",
                "~/libs/bootstrap-select/dist/css/bootstrap-select.min.css",
                "~/css/right.dark.css",
                "~/css/demo.css"
            );

            bundles.Add(headStyles);
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            var footerScripts = new ScriptBundle("~/bundles/js").Include
            (
                "~/libs/jquery/jquery.min.js",
                "~/libs/bootstrap/js/bootstrap.min.js",
                "~/libs/jquery.scrollbar/jquery.scrollbar.min.js",
                "~/libs/bootstrap-tabdrop/bootstrap-tabdrop.min.js",
                "~/libs/sparkline/jquery.sparkline.min.js",
                "~/libs/ionrangeslider/js/ion.rangeSlider.min.js",
                "~/libs/inputNumber/js/inputNumber.js",
                "~/libs/bootstrap-switch/dist/js/bootstrap-switch.min.js",
                "~/libs/datatables/media/js/jquery.dataTables.min.js",
                "~/libs/datatables/media/js/dataTables.select.js",
                "~/libs/datatables/media/js/dataTables.bootstrap.js",
                "~/libs/selectize/dist/js/standalone/selectize.min.js",
                "~/libs/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                "~/libs/bootstrap-select/dist/js/bootstrap-select.min.js",
                "~/js/template/products.js",
                "~/js/main.js",
                "~/js/demo.js"
            );

            bundles.Add(footerScripts);
        }
    }
}
