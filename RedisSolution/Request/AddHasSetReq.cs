using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedisSolution
{
    /// <summary>
    /// 添加 HasSet 请求参数
    /// </summary>
    public class AddHasSetReq
    {
        /// <summary>
        /// 键
        /// </summary>
        [Required(ErrorMessage = "请求Key不能为空")]
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "请求Value不能为空")]
        public string Value { get; set; }
    }

    /// <summary>
    /// 键值对
    /// </summary>
    public class KeyValues
    {
        [Required(ErrorMessage = "Key不能为空")]
        [DisplayName("Key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Value不能为空")]
        [DisplayName("Value")]
        public string Value { get; set; }

    }
}