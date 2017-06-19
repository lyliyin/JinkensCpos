using Newtonsoft.Json;
using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisSolution.Areas.Customer.Controllers
{
    /// <summary>
    /// RedisManager帮助文档
    /// </summary>
    public class RedisManagerController : ApiController
    {
        /// <summary>
        ///  向Redis 增加 HasTable
        /// </summary>
        /// <param name="info">请求参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddHasSet([FromBody]BaseRequest<AddHasSetReq> info)
        {
            RedisSetService SetService = new RedisSetService();
            SetService.Add(info.Parameter.Key, info.Parameter.Value);
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        /// <summary>
        /// 获取随机值
        /// </summary>
        /// <param name="Parameter">键</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRandomFromSet([FromBody]BaseRequest<KeyValues> Parameter)
        {
            RedisSetService SetService = new RedisSetService();
            string values = SetService.GetRandomItemFromSet(Parameter.Parameter.Key);
            if (String.IsNullOrEmpty(values))
            {
                return null;
            }

            return Request.CreateResponse(HttpStatusCode.OK, values);
        }


        /// <summary>
        /// 入队列
        /// </summary>
        /// <param name="Parameter">键</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage InLeftQueue([FromBody]BaseRequest<KeyValues> Parameter)
        {
            RedisListService ListService = new RedisListService();
            ListService.LPush(Parameter.Parameter.Key, Parameter.Parameter.Value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// 根据Key 获取队列信息
        /// </summary>
        /// <param name="Parameter">Key</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetListQueueByKey([FromBody]BaseRequest<KeyValues> Parameter)
        {
            RedisListService ListService = new RedisListService();
            List<string> Values = ListService.Get(Parameter.Parameter.Key);
            return Request.CreateResponse(HttpStatusCode.OK,Values);
        }

        /// <summary>
        /// 获取单个信息通过key 适用场景 {异步消息队列之负载均衡} 客户端开启多个示例 即可实现负载均衡了。
        /// </summary>
        /// <param name="Parameter"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEntityQueueBuyKeyFromLoadBalanceing([FromBody]BaseRequest<KeyValues> Parameter)
        {
            RedisListService ListService = new RedisListService();
            string Value=ListService.BlockingPopItemFromList(Parameter.Parameter.Key, null);
            return Request.CreateResponse(HttpStatusCode.OK, Value);
        }
    }
}
