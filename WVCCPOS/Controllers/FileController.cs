using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace CPOS.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveImages(string filebase)
        {

            string strSource = DateTime.Now.ToString("yyyyMMdd");

            string strDestination = Server.MapPath("~/UploadImages/") + strSource;
            string strPath = Path.GetDirectoryName(strDestination);
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }

            byte[] imageBytes = Convert.FromBase64String(filebase.Split(',')[1]);
            //读入MemoryStream对象
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            //转成图片
            Image image = Image.FromStream(memoryStream);
            string relPath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string filename = strDestination + relPath;
            image.Save(filename);
            return Json(relPath, JsonRequestBehavior.DenyGet);
        }
    }
}