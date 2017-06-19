using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WVCCPOS.Controllers
{
    public class MessageCalendarController : Controller
    {
        // GET: MessageCalendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCalendar()
        {
            BaseResponse<GetCalendarRes> data = new BaseResponse<GetCalendarRes>()
            {
                rows = new List<GetCalendarRes>()
                {
                    new GetCalendarRes() { end="2017-6-5 9:00:00", Remark="周一例会", start="2017-6-5 7:00:00", title="周一例会",UserNames="全体员工"},
                    new GetCalendarRes() { end="2017-6-6 12:30:00", Remark="项目进度会", start="2017-6-6 10:00:00", title="周二项目会",UserNames="研发员工"},
                    new GetCalendarRes() { end="2017-6-8 1:30:00", Remark="项目进度会", start="2017-6-8 12:00:00", title="周三技术研讨会",UserNames="研发员工"},
                    new GetCalendarRes() { end="2017-6-9 17:30:00", Remark="项目进度会", start="2017-6-9 15:00:00", title="周四产品培训会",UserNames="研发员工"},
                    new GetCalendarRes() { end="2017-6-10 18:30:00", Remark="周五周会", start="2017-6-10 17:30:00", title="周五周会",UserNames="研发员工"}
                }
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}