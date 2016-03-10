using System.Web;
using System.Web.Optimization;

namespace Centerhum.SmartFood.Web.Admin
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js/essentials").Include(
                "~/Content/bootstrap/js/bootstrap.js",
                "~/Content/plugins/touchpunch/jquery.ui.touch-punch.js",
                "~/Content/plugins/reveal/jquery.reveal.js",                
                "~/Content/plugins/event.swipe/jquery.event.move.js",
                "~/Content/plugins/event.swipe/jquery.event.swipe.js",
                "~/Content/assets/js/libs/breakpoints.js",
                "~/Content/plugins/cookie/jquery.cookie.js",
                "~/Content/plugins/slimscroll/jquery.slimscroll.js",
                "~/Content/plugins/slimscroll/jquery.slimscroll.horizontal.js",
                "~/Content/plugins/sparkline/jquery.sparkline.js",
                "~/Content/plugins/flot/jquery.flot.js",
                "~/Content/plugins/flot/jquery.flot.tooltip.js",
                "~/Content/plugins/flot/jquery.flot.resize.js",
                "~/Content/plugins/flot/jquery.flot.time.js",
                "~/Content/plugins/flot/jquery.flot.growraf.js",
                "~/Content/plugins/flot/jquery.flot.pie.js",
                "~/Content/plugins/easy-pie-chart/jquery.easy-pie-chart.js",
                "~/Content/plugins/blockui/jquery.blockUI.js",
                "~/Content/plugins/fullcalendar/fullcalendar.js",
                "~/Content/plugins/noty/jquery.noty.js",
                "~/Content/plugins/noty/layouts/top.js",
                "~/Content/plugins/noty/themes/default.js",
                "~/Content/plugins/bootbox/bootbox.js",
                "~/Content/plugins/typeahead/typeahead.js",
                "~/Content/plugins/autosize/jquery.autosize.js",
                "~/Content/plugins/inputlimiter/jquery.inputlimiter.js",
                "~/Content/plugins/uniform/jquery.uniform.js",
                "~/Content/plugins/tagsinput/jquery.tagsinput.js",
                "~/Content/plugins/select2/select2.js",
                "~/Content/plugins/fileinput/fileinput.js",
                "~/Content/plugins/duallistbox/jquery.duallistbox.js",
                "~/Content/plugins/bootstrap-inputmask/jquery.inputmask.js",
                "~/Content/plugins/bootstrap-wysihtml5/wysihtml5.js",
                "~/Content/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js",
                "~/Content/plugins/bootstrap-multiselect/bootstrap-multiselect.js",
                "~/Content/plugins/pickadate/picker.js",
                "~/Content/plugins/pickadate/picker.date.js",
                "~/Content/plugins/pickadate/picker.time.js",
                "~/Content/plugins/pickadate/legacy.js",
                "~/Content/plugins/pickadate/translations/pt_BR.js",
                "~/Content/assets/js/app.js",
                "~/Content/assets/js/plugins.js",
                "~/Content/assets/js/plugins.form-components.js",
                "~/Content/plugins/globalize/globalize.js",
                "~/Content/plugins/globalize/cultures/globalize.culture.pt-BR.js",
                "~/Content/plugins/validation/jquery.validate.js",
                "~/Content/plugins/validation/additional-methods.js",
                "~/Content/plugins/nprogress/nprogress.js",
                "~/Content/plugins/noty/jquery.noty.js",
                "~/Content/plugins/noty/layouts/top.js",
                "~/Content/plugins/noty/themes/default.js",
                "~/Content/plugins/datatables/jquery.dataTables.js",
                "~/Content/plugins/datatables/DT_bootstrap.js",
                "~/Content/plugins/datatables/responsive/datatables.responsive.js",
                "~/Content/plugins/datatables/colvis/ColVis.js"));

            bundles.Add(new StyleBundle("~/Content/assets/css/essentials").Include(
                "~/Content/assets/css/main.css",
                "~/Content/plugins/reveal/reveal.css",
                "~/Content/assets/css/responsive.css",
                "~/Content/assets/css/icons.css"));

            
        }
    }
}