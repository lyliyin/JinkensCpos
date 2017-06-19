using Application;
using AutoMapper;
using CPOS.Models;
using DataModel.GeneralModel;
using DTO;
using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WVCCPOS.Controllers
{
    public class VipController : Controller
    {
        private VipApplication _VipService = null;
        public VipController(VipApplication VipService)
        {
            _VipService = VipService;
        }

        /// <summary>
        /// 会员卡管理
        /// </summary>
        /// <returns></returns>
        public ActionResult CardIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCardTypeList()
        {
            var lst = _VipService.GetCardTypeList();


            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 优惠券列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CouponIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCouponIndex(string CouponCode)
        {
            var lst = _VipService.FindCoupons(CouponCode);

            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddCoupon(CouponInfoRes entity)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CouponInfoRes, CouponCategory>());

            CouponCategory model = Mapper.Map<CouponCategory>(entity);
            model.CouponCategoryId = Guid.NewGuid().ToString();
            _VipService.SaveCouponCategory(model);
            return Json(new ResponseData() { Code = 200, Message = "保存成功！" }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult CreateCoupon(string CouponCategoryId)
        {
            _VipService.CreateCoupons(CouponCategoryId);
            return Json(new ResponseData() { Code = 200, Message = "保存成功！" }, JsonRequestBehavior.DenyGet);
        }

        public ActionResult VipIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetVipIndex(BaseRequest<VipInfoReq> Parameter)
        {
            int RecordCount = 0;
            var lst = _VipService.GetVipList(Parameter, out RecordCount);
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst,
                total = RecordCount
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 获取 会员 详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexII(string Id)
        {
            var model = _VipService.GetVip(Id);
            return View(model);
        }

        /// <summary>
        /// 根据会员获取会员 积分明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetPointsByVipId(string VipId)
        {
            var lst = _VipService.GetVipPoints(VipId);
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst,
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }



        /// <summary>
        /// 根据会员获取会员 积分明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAmountByVipId(string VipId)
        {
            var lst = _VipService.GetVipAmount(VipId);
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst,
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }


        /// <summary>
        /// 根据会员获取会员 积分明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetCouponByVipId(string VipId)
        {
            var lst = _VipService.GetCouoponByVipId(VipId);
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst,
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 调整积分信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult VipPointsCreate(string PointsSourceId, int Points, string VipId)
        {
            _VipService.AddPoints(PointsSourceId, Points, VipId);
            ResponseData data = new ResponseData()
            {
                Code = 200,
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 调整积分信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult VipAmountCreate(string AmountSourceId, decimal Amount, string VipId)
        {
            _VipService.AddAmounts(AmountSourceId, Amount, VipId);
            ResponseData data = new ResponseData()
            {
                Code = 200,
            };
            return Json(data, JsonRequestBehavior.DenyGet);
        }
    }
}