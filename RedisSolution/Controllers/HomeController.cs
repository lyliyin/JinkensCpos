using Newtonsoft.Json;
using Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSolution.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
