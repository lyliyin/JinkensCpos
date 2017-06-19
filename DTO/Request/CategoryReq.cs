using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    /// <summary>
    /// 商品类别
    /// </summary>
    public class CategoryReq
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string nodeName { get; set; }
    }

    public class BrandReq
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
        public string BrandCode { get; set; }
        public string images { get; set; }
    }
}