using Application;
using CPOS.Models;
using DataCommTools;
using DataModel.GeneralModel;
using DTO;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CPOS.Controllers
{
    /// <summary>
    /// 整个商品 的处理 业务逻辑信息
    /// </summary>
    public class ItemController : Controller
    {
        public ItemApplication _ItemApplication = null;
        public ICategoryResponsity CategoryService = null;
        public ItemController(ItemApplication ItemApplication, ICategoryResponsity CategoryService)
        {
            _ItemApplication = ItemApplication;
            this.CategoryService = CategoryService;
        }

        /// <summary>
        /// 首页页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Category model = new Category();
            return View(model);
        }

        /// <summary>
        /// 品牌管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BrandIndex()
        {
            return View(new Brand() { });
        }
        /// <summary>
        /// Post 获取首页列表信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BrandIndex(BaseRequest<ItemReq> request)
        {
            int recordCount = 0;
            List<Brand> lst = _ItemApplication.FindBrandList(request, out recordCount);

            ResponseData data = new ResponseData()
            {
                Code = 200,
                total = recordCount,
                rows = lst
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BrandIndexICreate(BrandReq request)
        {
            if (String.IsNullOrEmpty(request.Id))
            {
                request.Id = Guid.NewGuid().ToString();
                _ItemApplication.AddBrand(request);
            }
            else
            {

                var entity = _ItemApplication.GetBrand(request.Id);
                entity.BrandName = request.BrandName;
                _ItemApplication.SaveBrand();
            }


            ResponseData data = new ResponseData()
            {
                Code = 200,
                Message = "操作成功！"
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }



        public ActionResult IndexICreate()
        {
            return View();
        }



        /// <summary>
        /// Post 获取首页列表信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Index(BaseRequest<CategoryReq> request)
        {
            int totalcount = 0;
            List<Category> lst = _ItemApplication.FindList(out totalcount, request);

            ResponseData data = new ResponseData()
            {
                Code = 200,
                total = totalcount,
                rows = lst
            };

            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 获取树结构
        /// </summary>
        /// <returns></returns>
        public JsonResult GetNodes()
        {
            int total = 0;
            List<Category> lst = _ItemApplication.FindList(out total);
            TreeViewNodesRes node = new TreeViewNodesRes();
            _ItemApplication.Resever(lst, node, "0");
            return Json(node, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 商品展示信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ItemIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ItemIndex(BaseRequest<ItemsReq> request)
        {
            int totalcount = 0;
            List<ItemRes> lst = _ItemApplication.FindItem(request, out totalcount);

            ResponseData data = new ResponseData()
            {
                Code = 200,
                total = totalcount,
                rows = lst
            };
            return Json(data, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 添加  分类信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult IndexICreate(Category model, string pCategoryName)
        {
            ModelState.AddModelError("IsName", "用户名不能为空");
            return Json("200", JsonRequestBehavior.DenyGet);
        }
    }
}