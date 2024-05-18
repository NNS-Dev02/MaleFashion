using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MaleFashion.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            //------------------------------ Public ------------------------------//

            //--- CSS trang Public ---//
            bundle.Add(new StyleBundle("~/bundle/css1").Include("~/Content/MaleFashion/bootstrap.min.css",
                                                                "~/Content/MaleFashion/elegant-icons.css",
                                                                "~/Content/MaleFashion/font-awesome.min.css",
                                                                "~/Content/MaleFashion/magnific-popup.css",
                                                                "~/Content/MaleFashion/nice-select.css",
                                                                "~/Content/MaleFashion/owl.carousel.min.css",
                                                                "~/Content/MaleFashion/slicknav.min.css",
                                                                "~/Content/MaleFashion/style.css",
                                                                "~/Content/MaleFashion/PagedList.css",
                                                                "~/Content/MaleFashion/Site.css",
                                                                "~/Content/MaleFashion/style.css.map"));

            //--- JavaScript trang Public ---//
            bundle.Add(new ScriptBundle("~/bundle/script1").Include("~/Script/MaleFashion/bootstrap.min.js",
                                                                   "~/Script/MaleFashion/jquery-3.3.1.min.js",
                                                                   "~/Script/MaleFashion/jquery.countdown.min.js",
                                                                   "~/Script/MaleFashion/jquery.magnific-popup.min.js",
                                                                   "~/Script/MaleFashion/jquery.nice-select.min.js",
                                                                   "~/Script/MaleFashion/jquery.nicescroll.min.js",
                                                                   "~/Script/MaleFashion/jquery.slicknav.js",
                                                                   "~/Script/MaleFashion/mixitup.min.js",
                                                                   "~/Script/MaleFashion/owl.carousel.min.js",
                                                                   "~/Script/MaleFashion/main.js"));

            //------------------------------ Area ------------------------------//

            //--- CSS trang Area ---//
            bundle.Add(new StyleBundle("~/bundle/css2").Include("~/Content/area/bootstrap.min.css",
                                                                "~/Content/area/font-awesome.min.css",
                                                                "~/Content/area/nprogress.css",
                                                                "~/Content/area/green.css",
                                                                "~/Content/area/prettify.min.css",
                                                                "~/Content/area/select2.min.css",
                                                                "~/Content/area/switchery.min.css",
                                                                "~/Content/area/starrr.css",
                                                                "~/Content/area/daterangepicker.css",
                                                                "~/Content/area/database/buttons.bootstrap.min.css",
                                                                "~/Content/area/database/dataTables.bootstrap.min.css",
                                                                "~/Content/area/database/fixedHeader.bootstrap.min.css",
                                                                "~/Content/area/database/responsive.bootstrap.min.css",
                                                                "~/Content/area/database/scroller.bootstrap.min.css",
                                                                "~/Content/area/dashboard/bootstrap-progressbar-3.3.4.min.css",
                                                                "~/Content/area/custom.min.css"));

            //--- JavaScript trang Area ---//
            bundle.Add(new ScriptBundle("~/bundle/script2").Include( "~/Script/area/jquery.min.js",
                                                                    "~/Script/area/bootstrap.bundle.min.js",
                                                                    "~/Script/area/fastclick.js",
                                                                    "~/Script/area/nprogress.js",
                                                                    "~/Script/area/bootstrap-progressbar.min.js",
                                                                    "~/Script/area/icheck.min.js",
                                                                    "~/Script/area/moment.min.js",
                                                                    "~/Script/area/daterangepicker.js",
                                                                    "~/Script/area/bootstrap-wysiwyg.min.js",
                                                                    "~/Script/area/jquery.hotkeys.js",
                                                                    "~/Script/area/prettify.js",
                                                                    "~/Script/area/jquery.tagsinput.js",
                                                                    "~/Script/area/switchery.min.js",
                                                                    "~/Script/area/select2.full.min.js",
                                                                    "~/Script/area/parsley.min.js",
                                                                    "~/Script/area/autosize.min.js",
                                                                    "~/Script/area/jquery.autocomplete.min.js",
                                                                    "~/Script/area/starrr.js",
                                                                    "~/Script/area/custom.min.js",
                                                                    "~/Script/area/database/buttons.bootstrap.min.js",
                                                                    "~/Script/area/database/buttons.flash.min.js",
                                                                    "~/Script/area/database/buttons.html5.min.js",
                                                                    "~/Script/area/database/buttons.print.min.js",
                                                                    "~/Script/area/database/dataTables.bootstrap.min.js",
                                                                    "~/Script/area/database/dataTables.buttons.min.js",
                                                                    "~/Script/area/database/dataTables.fixedHeader.min.js",
                                                                    "~/Script/area/database/dataTables.keyTable.min.js",
                                                                    "~/Script/area/database/dataTables.responsive.min.js",
                                                                    "~/Script/area/database/jquery.dataTables.min.js",
                                                                    "~/Script/area/database/jszip.min.js",
                                                                    "~/Script/area/database/pdfmake.min.js",
                                                                    "~/Script/area/database/responsive.bootstrap.js",
                                                                    "~/Script/area/database/vfs_fonts.js",
                                                                    "~/Script/area/dashboard/curvedLines.js",
                                                                    "~/Script/area/dashboard/Chart.min.js",
                                                                    "~/Script/area/dashboard/date.js",
                                                                    "~/Script/area/dashboard/gauge.min.js",
                                                                    "~/Script/area/dashboard/jquery.flot.js",
                                                                    "~/Script/area/dashboard/jquery.flot.orderBars.js",
                                                                    "~/Script/area/dashboard/jquery.flot.pie.js",
                                                                    "~/Script/area/dashboard/jquery.flot.resize.js",
                                                                    "~/Script/area/dashboard/jquery.flot.spline.min.js",
                                                                    "~/Script/area/dashboard/jquery.flot.stack.js",
                                                                    "~/Script/area/dashboard/jquery.flot.time.js",
                                                                    "~/Script/area/dashboard/jquery.sparkline.min.js",
                                                                    "~/Script/area/dashboard/morris.min.js",
                                                                    "~/Script/area/dashboard/raphael.min.js",
                                                                    "~/Script/area/dashboard/skycons.js"));

            //------------------------------ Login & Register ------------------------------//

            //--- CSS trang Login & Register ---//
            bundle.Add(new StyleBundle("~/bundle/css3").Include("~/Content/login/bootstrap.min.css",
                                                                "~/Content/login/font-awesome.min.css",
                                                                "~/Content/login/nprogress.css",
                                                                "~/Content/login/animate.min.css",
                                                                "~/Content/login/custom.min.css"));

        }
    }
}