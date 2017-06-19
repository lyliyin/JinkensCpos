using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisSolution
{
    /// <summary>
    /// 基本请求  必传参数
    /// </summary>
    public class BaseRequest<T>
    {
        /// <summary>
        /// 世家戳
        /// </summary>
        public int timespace { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 科技编号
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 泛型类
        /// </summary>
        public T Parameter { get; set; }
    }
}