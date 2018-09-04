using System.Web.Mvc;

namespace WebApplication1.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "admin_default",
            //    "admin/{controller}/{action}/{id}",
            //   new { controller = "Home", action = "Index", id = "" },
            ////namespaces: new string[] { "admin.Controllers" }

            //);


            //      context.MapRoute(
            //  "AboutAdd",
            //  "admin/HakkimizdaEkle",
            //defaults: new { controller = "Home", action = "Index2" });

            //      context.MapRoute(
            //                    "admin_default",
            //                    "admin/{controller}/{action}/{id}",
            //                    new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
            //                          constraints: new { lang = @"fr|en" }

            //                );
            //  }


            context.MapRoute(
            name: "Language",
            url: "{lang}/{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            constraints: new { lang = @"fr|en" });




        }
    }
}