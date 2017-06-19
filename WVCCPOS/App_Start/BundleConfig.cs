using System.Web;
using System.Web.Optimization;

namespace CPOS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                        "~/Scripts/jquery.validate-vsdoc.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //通用脚本
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                       "~/Content/js/jquery-1.8.3.min.js",
                      "~/Content/assets/jquery-slimscroll/jquery-ui-1.9.2.custom.min.js",
                      "~/Content/assets/jquery-slimscroll/jquery.slimscroll.min.js",
                      //"~/Content/assets/fullcalendar/fullcalendar/fullcalendar.min.js",
                      "~/Content/assets/bootstrap/js/bootstrap.min.js",
                      "~/Content/js/jquery.blockui.js",
                      "~/Content/js/jquery.cookie.js",
                      "~/Content/assets/jqvmap/jqvmap/jquery.vmap.js",
                      "~/Content/assets/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                      "~/Content/assets/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                      "~/Content/assets/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                      "~/Content/assets/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                      "~/Content/assets/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                      "~/Content/assets/jqvmap/jqvmap/data/jquery.vmap.sampledata.js",
                      "~/Content/assets/jquery-knob/js/jquery.knob.js",
                      "~/Content/js/jquery.peity.min.js",
                      "~/Content/assets/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
                      "~/Content/js/jquery.blockui.js",
                      "~/Content/assets/chosen-bootstrap/chosen/chosen.jquery.min.js",
                      "~/Content/assets/uniform/jquery.uniform.min.js",
                      "~/Content/js/scripts.js"));

            //Table 列表脚本
            bundles.Add(new ScriptBundle("~/Scripts/list").Include("~/Scripts/tablelist/bootstrap-table.min.js",
                                                                    "~/Scripts/tablelist/bootstrap-table-zh-CN.min.js",
                                                                    "~/Scripts/tablelist/liyin.bootstraptable.pager.js"));
            //图表
            bundles.Add(new ScriptBundle("~/Scripts/chat").Include("~/Content/assets/flot/jquery.flot.js",
                                     "~/Content/assets/flot/jquery.flot.resize.js",
                                     "~/Content/assets/flot/jquery.flot.pie.js",
                                     "~/Content/assets/flot/jquery.flot.stack.js",
                                     "~/Content/assets/flot/jquery.flot.crosshair.js"));



            //表单js
            bundles.Add(new ScriptBundle("~/Scripts/FormAction").Include("~/Scripts/date/bootstrap-datepicker.js",
                                     "~/Scripts/date/bootstrap-datepicker.min.js",
                                     "~/Scripts/date/bootstrap-datepicker.zh-CN.js",
                                     "~/Content/assets/bootstrap-toggle-buttons/static/js/jquery.toggle.buttons.js",
                                     "~/Content/assets/chosen-bootstrap/chosen/chosen.jquery.min.js",
                                     "~/Scripts/fileupload/bootstrap-fileupload.js",
                                     "~/Scripts/AjaxForm/jquery.unobtrusive-ajax.js",
                                     "~/Content/assets/gritter/js/jquery.gritter.js"));



            //树
            bundles.Add(new ScriptBundle("~/Scripts/TreeVIew").Include("~/Scripts/treeview/bootstrap-treeview.js"));


            //样式信息
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                        "~/Content/assets/bootstrap/css/bootstrap.min.css",
                                        "~/Content/assets/bootstrap/css/bootstrap-responsive.min.css"
                                        , "~/Content/assets/font-awesome/css/font-awesome.css"
                                        , "~/Content/css/style.css"
                                        , "~/Content/css/style_responsive.css"
                                        , "~/Content/css/style_default.css"
                                        , "~/Content/assets/fancybox/source/jquery.fancybox.css"
                                        , "~/Content/assets/uniform/css/uniform.default.css"
                                        //, "~/Content/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css"
                                        , "~/Content/assets/jqvmap/jqvmap/jqvmap.css"));



            //样式信息
            bundles.Add(new StyleBundle("~/Content/formaction").Include(
                      "~/Content/assets//bootstrap/css/bootstrap-fileupload.css",
                      "~/Content/assets//chosen-bootstrap/chosen/chosen.css"
                      , "~/Content/assets//bootstrap-datepicker/css/datepicker.css"
                      , "~/Content/assets//bootstrap-timepicker/compiled/timepicker.css"
                      , "~/Content/assets//bootstrap-daterangepicker/daterangepicker.css"
                      , "~/Content/assets//bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css"
                      , "~/Content/assets/dropzone/css/dropzone.css"));



            //时间选择样式
            bundles.Add(new StyleBundle("~/Content/listcss").Include(
                          "~/Content/bootstrap-table.css"));

            //时间选择样式
            bundles.Add(new StyleBundle("~/Content/datetimecss").Include(
                          "~/Content/assets//bootstrap-datepicker/css/datepicker.css",
                          "~/Content/assets//bootstrap-timepicker/compiled/timepicker.css"
                          , "~/Content/assets//bootstrap-daterangepicker/daterangepicker.css"));
            //开关样式
            bundles.Add(new StyleBundle("~/Content/togglecss").Include(
                          "~/Content/assets//bootstrap-toggle-buttons/static/stylesheets/bootstrap-toggle-buttons.css"));

            //开关样式
            bundles.Add(new StyleBundle("~/Content/select2css").Include(
                         "~/Content/assets//chosen-bootstrap/chosen/chosen.css"));

            //文件上传
            bundles.Add(new StyleBundle("~/Content/fileuploadcss").Include(
                         "~/Content/assets//bootstrap/css/bootstrap-fileupload.css"));

        }
    }
}