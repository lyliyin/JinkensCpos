using Application;
using CPOS.Models;
using DataModel.GeneralModel;
using DTO;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WVCCPOS.Controllers
{
    public class RoleController : Controller
    {
        private UserApplication _UserService = null;
        public RoleController(UserApplication UserService)
        {
            _UserService = UserService;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RoleIndex()
        {
            List<Role> lst = _UserService.FindRoleList();
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst
            };
            return Json(data, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UsersIndex(BaseRequest<UserRoleReq> Parameter)
        {
            int RecordCount = 0;
            List<User> lst = _UserService.FindUserList(Parameter, out RecordCount);
            ResponseData data = new ResponseData()
            {
                Code = 200,
                rows = lst,
                total = RecordCount
            };
            return Json(data, JsonRequestBehavior.DenyGet);
        }
    }
}