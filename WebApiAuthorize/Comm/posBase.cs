using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiAuthorize.Comm
{

    public class BaseApi : ApiController
    {

        public string CustomerId
        {
            get
            {
                var caller = User as ClaimsPrincipal;
                return caller.FindFirst("CustomerId").Value.ToString();
            }
        }


        public string UserId
        {
            get
            {
                var caller = User as ClaimsPrincipal;
                return caller.FindFirst("UserId").Value.ToString();
            }
        }


        public string Name
        {
            get
            {
                var caller = User as ClaimsPrincipal;
                return caller.FindFirst("name").Value.ToString();
            }
        }
    }

    public class Response
    {
        public string State { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }


    public static class JsonTools
    {
        public static string ToJson(this Response result)
        {
            return JsonConvert.SerializeObject(result);
        }
    }


    public class posBase
    {
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        public class CustomerAttribute : ActionFilterAttribute
        {
            public string CustomerID { get; set; }


            public override void OnActionExecuting(HttpActionContext actionContext)
            {

                // 0011 
                //CustomerID = "b40cde63be3240f18302e001111a9cfb";
                actionContext.ActionArguments.Add("ClientId", CustomerID);
                //
                try
                {
                    CustomerID = actionContext.ActionArguments.ToList().First().Value + "";
                }
                catch (Exception ex)
                {

                }

                //
                base.OnActionExecuting(actionContext);
            }

        }
    }
}