using System.Web.Mvc;

namespace RedisSolution.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customer_default",
                "Customer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "RedisSolution.Areas.Customer.Controllers" }
            );
        }
    }
}