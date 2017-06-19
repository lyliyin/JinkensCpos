using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IResponsity;
using System.Linq.Expressions;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity.Configuration;
using DataModel.GeneralModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using CPOS.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Configuration;

namespace CPOS.Controllers
{
    public class UserInfo
    {
        public int Id { get; set; }
    }

    [AllowAnonymous]
    public class HomeController : Controller
    {

        /// <summary>
        /// 测试图片信息
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] //遇着富文本框的时候需要关闭
        public ActionResult BeginForm(string[] images)
        {
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(AccountUserInfo model, string ReturnUrl)
        {
            string tokenurl = ConfigurationManager.AppSettings["IdStrServer"];
            var client = new HttpClient();
            string content = string.Format("grant_type=client_credentials&name={0}&password={1}", model.UserName, model.Password);
            var rst = client.PostAsync(tokenurl, new StringContent(content)).Result.Content.ReadAsStringAsync().Result;
            var obj = JsonConvert.DeserializeObject<Token>(rst);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);

            if (!String.IsNullOrEmpty(obj.AccessToken))
            {
                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    //成功
                    return RedirectToAction("VipIndex", "Vip");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            return View();
        }
    }

    public class AccountUserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class Token
    {
        [JsonProperty("Access_Token")]
        public string AccessToken { get; set; }

        public string expires_in { get; set; }
    }
}