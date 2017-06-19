using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 基础请求
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRequest<T> where T : class
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int pageNumber { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string sortOrder { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sortName { get; set; }
        /// <summary>
        /// 泛型类
        /// </summary>
        public T Paramter { get; set; }
    }
}
