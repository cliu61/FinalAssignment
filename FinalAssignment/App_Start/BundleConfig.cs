﻿using System.Web;
using System.Web.Optimization;

namespace FinalAssignment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            
            //date time picker Bundle
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.min.js"));

            //DataTable Bundle
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js"));

            //google map
            bundles.Add(new ScriptBundle("~/bundles/map").Include(
                "~/Scripts/map.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.min.css"));

            

        }
    }
}
