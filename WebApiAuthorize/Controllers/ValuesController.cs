using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WebApiAuthorize.Comm;
using static WebApiAuthorize.Comm.posBase;

namespace WebApiAuthorize.Controllers
{



    [Customer]
    [Authorize]
    [xiaoyinziHandlerError]
    public class ValuesController : BaseApi
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            Request.GetQueryNameValuePairs();
            return new string[] { "value1", "value2", "注册Id" + UserId, "初始化" + CustomerId, "船只" + Name };
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            Response result = new Response()
            {
                Data = id,
                Message = "请求成功",
                State = "200"
            };
            return Request.CreateResponse(HttpStatusCode.OK, result.ToJson());
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
