using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using WebApiAuthorize.Comm;

namespace WebApiAuthorize
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

        }
    }

    public class xiaoyinziHandlerErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK);

            Response result = new Response()
            {
                Data = "请求错误",
                Message = actionExecutedContext.Exception.Message,
                State = "500"
            };

            actionExecutedContext.Response.Content = new StringContent(result.ToJson(), Encoding.UTF8);
        }
    }
}
