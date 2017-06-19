using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataCommTools
{
    //#region 处理特性
    ////特性
    //public class LogAttribute : HandlerAttribute
    //{
    //    public override ICallHandler CreateHandler(IUnityContainer container)
    //    {
    //        ICallHandler handler = new LogCallHandler();
    //        return handler;
    //    }
    //}

    ////句柄
    //public class LogCallHandler : ICallHandler
    //{
    //    public int Order { get; set; }

    //    public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    //    {
    //        Console.WriteLine("打印日志信息");
    //        return getNext()(input, getNext);
    //    }
    //}
    //#endregion
}
