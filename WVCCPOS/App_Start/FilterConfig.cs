using CPOS.Models;
using DataCommTools;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CPOS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorsAttribute());   //错误异常
            filters.Add(new ActionFiltersAttribute());   //Action 过滤器
            //filters.Add(new AuthorizeAttribute());  //增加权限验证信息    最后添加接口信息
        }
    }

    /// <summary>
    /// 错误 异常信息
    /// </summary>
    public class ErrorsAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Type type = filterContext.Controller.GetType();
            Log4NetExport log = Log4NetExport.Create(type);
            log.Error(string.Format("接口{0} 请求参数：{1}", filterContext.Exception.Message, filterContext.RequestContext.HttpContext.Request.Params.toJson()));
        }
    }

    public class ActionFiltersAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行前
        /// </summary>
        /// <param name="filterContext">当前上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionparamerer = filterContext.ActionParameters.toJson();

            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                ModelStateDictionary dic = filterContext.Controller.ViewData.ModelState;
                string Message = string.Empty;
                foreach (var item in dic.Keys)
                {
                    foreach (var error in dic[item].Errors)
                    {
                        Message += error.ErrorMessage;
                    }
                }
                filterContext.Result = new JsonResult() { Data = new ResponseData() { Code = 502, Message = Message } };
            }
            else
            {
                Action action = new Action(() =>
                {
                    Type type = filterContext.Controller.GetType();
                    Log4NetExport log = Log4NetExport.Create(type);
                    log.Info(string.Format("接口{0} 请求参数：{1}", filterContext.ActionDescriptor.ActionName, actionparamerer));
                });
                action.BeginInvoke(null, null);
            }
        }

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="filterContext">当前上下文</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionparamerer = filterContext.ActionDescriptor.GetParameters().toJson();

            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                ModelStateDictionary dic = filterContext.Controller.ViewData.ModelState;
                string Message = string.Empty;
                foreach (var item in dic.Keys)
                {
                    foreach (var error in dic[item].Errors)
                    {
                        Message += error.ErrorMessage;
                    }
                }

                filterContext.Result = new JsonResult() { Data = new ResponseData() { Code = 502, Message = Message } };
            }
        }
    }
}
