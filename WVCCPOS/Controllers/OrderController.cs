using Application;
using CPOS.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WVCCPOS.Controllers
{
    public class OrderController : Controller
    {
        private OrderApplication _OrderApplication = null;
        public OrderController(OrderApplication OrderApplication)
        {
            _OrderApplication = OrderApplication;
        }
        // 订单统计 信息
        public ActionResult OrderStatistiscIndex()
        {
            return View();
        }

        /// <summary>
        /// 获取 订单月季销售数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetOrderStatistiscData()
        {
            ResponseData data = new ResponseData()
            {
                rows = _OrderApplication.GetList(),
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取 会员的订单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetOrderByVip(string VipId)
        {
            ResponseData data = new ResponseData()
            {
                rows = _OrderApplication.GetOrderByVipId(VipId),
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 订单主页信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetOrdersByOrderNo(BaseRequest<GetOrderReq> Parameter)
        {
            int RecordCount = 0;
            ResponseData data = new ResponseData()
            {
                rows = _OrderApplication.GetOrders(Parameter,out RecordCount),
                total = RecordCount
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}