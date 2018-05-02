using System.Web.Mvc;

namespace WebApplication1.Areas.admin2
{
    public class admin2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admin2_default",
                "admin2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}