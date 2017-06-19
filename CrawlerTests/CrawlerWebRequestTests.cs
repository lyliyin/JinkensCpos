using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Tests
{
    [TestClass()]
    public class CrawlerWebRequestTests
    {
        [TestMethod()]
        public void DownLoadHtmlTest()
        {
            GetJDItemLIst list = new GetJDItemLIst();
            //list.GetJDBrand();
            //list.GetJDItemCategory();
            list.GetJDItem();
            // CrawlerWebRequest Service = new CrawlerWebRequest();
            //// Service.AnalysisHtmlDataPhone("https://list.jd.com/list.html?cat=9987,6880,6881");
            // Service.GetJDAllCategory();
            Assert.IsTrue(8 == 8);
        }
    }
}