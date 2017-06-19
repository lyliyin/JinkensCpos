using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using CPOS.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CPOS.Models
{
    /// <summary>
    /// 返回数据格式信息
    /// </summary>
    public class ResponseData
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public int total { get; set; }
        public object rows { get; set; }
        public object Extended { get; set; }
    }
}



