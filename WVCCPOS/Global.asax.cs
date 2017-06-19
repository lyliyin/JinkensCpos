using DataCommTools;
using IResponsity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CPOS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() //应用程序在开始的时候执行方法 在这里可以加载所需要的资源 然后在全局缓存处理
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //QueueHandler<Person>.DoProcess();

            ControllerBuilder.Current.SetControllerFactory(new IOCFactory.UnityFactoryController());//控制器的实例化走UnityControllerFactory

        }

        public void Application_BeginRequest()
        {
            HttpContext context = HttpContext.Current;
            //context.Response.Write("test");
            string userAgent = context.Request.UserAgent; //限制浏览器的类型   防止爬虫
        }

        public void Application_End() //应用程序在停止的时候回执行方法 在这里可以加载所需要的资源 然后在全局缓存处理
        {

        }

        public void Application_Error() //应用程序出错 可以跳转路径{记录错误日志、发送邮件信息}
        {

        }
    }
}
