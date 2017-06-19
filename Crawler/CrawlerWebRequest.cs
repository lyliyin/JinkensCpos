//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using HtmlAgilityPack;
//using DataModel.GeneralModel;
//using IResponsity;
//using Responsity;
//using DataModel;

//namespace Crawler
//{
//    /// <summary>
//    /// 爬虫
//    /// </summary>
//    public class CrawlerWebRequest
//    {
//        public HtmlDocument DownLoadHtmlUTF8(string url)
//        {
//            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
//            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";

//            Encoding encord = Encoding.GetEncoding("utf-8");
//            string result = string.Empty;
//            using (WebResponse response = request.GetResponse())
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream(), encord);
//                result = reader.ReadToEnd();
//            }

//            HtmlDocument doc = new HtmlDocument();
//            doc.LoadHtml(result);
//            return doc;
//        }

//        public HtmlDocument DownLoadHtmlGBK(string url)
//        {
//            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
//            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";


//            string result = string.Empty;
//            using (WebResponse response = request.GetResponse())
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gbk"));
//                result = reader.ReadToEnd();
//            }

//            HtmlDocument doc = new HtmlDocument();
//            doc.LoadHtml(result);
//            return doc;
//        }
//        /// <summary>
//        /// 获取解析对象
//        /// </summary>
//        /// <param name="url">url 地址</param>
//        /// <param name="xpath">元素路径</param>
//        public HtmlNode GetSingleNodeByxpath(HtmlDocument doc, string xpath)
//        {
//            return doc.DocumentNode.SelectSingleNode(xpath);

//        }


//        /// <summary>
//        /// 获取解析对象
//        /// </summary>
//        /// <param name="url">url 地址</param>
//        /// <param name="xpath">元素路径</param>
//        public HtmlNodeCollection GetNodesByxpath(HtmlDocument doc, string xpath)
//        {
//            return doc.DocumentNode.SelectNodes(xpath);
//        }

//        /// <summary>
//        /// 解析html 标签 {手机页面}
//        /// </summary>
//        /// <param name="html"></param>
//        public void AnalysisHtmlDataPhone(string url)
//        {

//            HtmlDocument htmlDocument = DownLoadHtmlUTF8(url);

//            string totalPageCountPath = "//*[@id='J_topPage']/span/i";


//            HtmlNode node = GetSingleNodeByxpath(htmlDocument, totalPageCountPath);
//            int count = int.Parse(node.InnerText);

//            for (int i = 1; i <= count; i++)
//            {
//                string pageUrl = string.Format("https://list.jd.com/list.html?cat=9987,6880,6881&page={0}", i);

//                //list 分页列表数据
//                HtmlDocument html = DownLoadHtmlUTF8(pageUrl);


//                string goodsList = "//*[@id='plist']/ul/li";
//                HtmlNodeCollection nodeCollection = GetNodesByxpath(html, goodsList);

//                for (int j = 0; j < nodeCollection.Count; j++)
//                {
//                    HtmlDocument childrenHtml = new HtmlDocument();
//                    childrenHtml.LoadHtml(nodeCollection[i].OuterHtml);
//                    //在具体解析每个商品信息
//                    string titleXpath = "//*[@class='p-name']/a/em";

//                    HtmlNode title = GetSingleNodeByxpath(childrenHtml, titleXpath);

//                    string detailXpath = "//*[@class='p-name']/a";
//                    HtmlNode detailNode = GetSingleNodeByxpath(childrenHtml, detailXpath);

//                    string href = detailNode.Attributes["href"].Value;
//                    string titleName = title.InnerHtml;

//                    string detailUrl = string.Format("{0}{1}{2}", "http:", href, "#none");

//                    HtmlDocument detailHtml = DownLoadHtmlGBK(detailUrl);

//                    string skusXpath = "//*[@id='choose-attrs']";

//                    HtmlNodeCollection skuCollection = GetNodesByxpath(detailHtml, skusXpath);

//                    foreach (var skuItem in skuCollection)
//                    {
//                        string itemXpath = "//*[@class='li p-choose']";
//                        HtmlDocument SkuHtml = new HtmlDocument();
//                        SkuHtml.LoadHtml(skuItem.OuterHtml);
//                        HtmlNode skuType = SkuHtml.DocumentNode.SelectSingleNode(itemXpath);

//                        string skuName = skuType.Attributes["data-type"].Value;

//                        string itemNodesXpath = "//*[@class='dd']/div";
//                        HtmlNodeCollection skuItemCollection = SkuHtml.DocumentNode.SelectNodes(itemNodesXpath);

//                        foreach (var skuItemSingle in skuItemCollection)
//                        {
//                            string skuIitle = skuItemSingle.Attributes["data-value"].Value;
//                            string skuId = skuItemSingle.Attributes["data-sku"].Value;
//                        }
//                    }
//                }
//            }
//        }

//        public void GetJDAllCategory(string url = "https://www.jd.com/allsort.aspx")
//        {
//            HtmlDocument doc = DownLoadHtmlUTF8(url);
//            string CustomerId = Guid.NewGuid().ToString().Replace("-", "");
//            string categoryItemXpath = "//*[@class='items']/dl";
//            Dictionary<Category, List<Category>> dic = new Dictionary<Category, List<Category>>();
//            HtmlNodeCollection collection = GetNodesByxpath(doc, categoryItemXpath);
//            int Sort = 1;
//            foreach (var Pitem in collection)
//            {
//                HtmlDocument PdocItem = new HtmlDocument();
//                PdocItem.LoadHtml(Pitem.OuterHtml);
//                string pNameXpath = "//dt/a";
//                string pName = GetSingleNodeByxpath(PdocItem, pNameXpath).InnerText;
//                Category pEntity = new Category()
//                {
//                    CatetoryName = pName,
//                    CategoryCode = pName,
//                    CategoryStatus = 1,
//                    CustomerId = CustomerId,
//                    Pid = "0",
//                    Sort = Sort,
//                };

//                List<Category> CategoryLst = new List<Category>();
//                Sort++;

//                HtmlNodeCollection collectionItem = GetNodesByxpath(PdocItem, "//dd/a");
//                int Index = 0;
//                foreach (var item in collectionItem)
//                {
//                    string name = item.InnerText;
//                    string href = item.Attributes["href"].Value;
//                    if (href.Contains("-"))
//                    {
//                        int count = href.LastIndexOf(".") - href.LastIndexOf("/");
//                        string PidAndId = href.Substring(href.LastIndexOf("/") + 1, count - 1);
//                        string Pid = PidAndId.Split('-')[0];
//                        string Id = PidAndId.Split('-')[1];

//                        if (Index == 0)
//                        {
//                            pEntity.Id = Pid;
//                        }


//                        CategoryLst.Add(new Category()
//                        {
//                            CatetoryName = name,
//                            CategoryCode = name,
//                            CategoryStatus = 1,
//                            CustomerId = CustomerId,
//                            Pid = Pid,
//                            Sort = Sort,
//                            Id = Id
//                        });
//                        Index++;
//                    }
//                }
//                dic.Add(pEntity, CategoryLst);
//            }

//            EFDBContext context = new EFDBContext();

//            ICategoryResponsity CategoryService = new CategoryResponsity(context);

//            Dictionary<string, string> dicKeys = new Dictionary<string, string>();
//            //入库操作
//            foreach (var item in dic.Keys)
//            {

//                List<Category> lst = null;

//                if (!String.IsNullOrWhiteSpace(item.Id))
//                {
//                    if (!dicKeys.Keys.Contains(item.Id))
//                    {
//                        lst = dic[item];
//                        CategoryService.Add(item);
//                        dicKeys.Add(item.Id, item.Id);
//                    }
                  
//                }

//                if (lst != null)
//                {
//                    foreach (var Categoryitem in lst)
//                    {
//                        if (!String.IsNullOrWhiteSpace(item.Id))
//                        {
//                            CategoryService.Add(Categoryitem);
//                        }
//                    }
//                }

//            }
//        }

//    }
//}
