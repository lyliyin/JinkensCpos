using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using DataModel.GeneralModel;
using IResponsity;
using Responsity;
using DataModel;
using DTO;
using Application;
using AutoMapper;
using DataCommTools;

namespace Crawler
{
    public class GetJDItemLIst
    {

        public List<myItem> reqslst = new List<myItem>();

        public string DownLoadHtml(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";


            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }

        public HtmlDocument GetJDDataByUrl(string url)
        {
            string down = DownLoadHtml(url);
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(down);
            return html;
        }

        public HtmlDocument GetJDDataByHtml(string html)
        {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }
        public object AnalysisDB(string xpath, string url = null, HtmlDocument doc = null, bool SingleNode = true, string children = null)
        {
            HtmlDocument _doc = null;
            if (!String.IsNullOrEmpty(url))
            {
                _doc = GetJDDataByUrl(url);
            }
            else
            {
                if (!String.IsNullOrEmpty(children))
                {
                    _doc = GetJDDataByHtml(children);
                }
                else
                {
                    _doc = doc;
                }

            }

            if (_doc != null)
            {
                if (SingleNode)
                {
                    return _doc.DocumentNode.SelectSingleNode(xpath);
                }
                else
                {
                    return _doc.DocumentNode.SelectNodes(xpath);
                }
            }
            return null;
        }


        #region GBK编码


        public string DownLoadHtmlGBK(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:53.0) Gecko/20100101 Firefox/53.0";


            string result = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gbk"));
                result = reader.ReadToEnd();
            }
            return result;
        }
        public HtmlDocument GetJDDataByUrlGBK(string url)
        {
            string down = DownLoadHtmlGBK(url);
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(down);
            return html;
        }

        public object AnalysisDBGBK(string xpath, string url = null, HtmlDocument doc = null, bool SingleNode = true, string children = null)
        {
            HtmlDocument _doc = null;
            if (!String.IsNullOrEmpty(url))
            {
                _doc = GetJDDataByUrlGBK(url);
            }
            else
            {
                if (!String.IsNullOrEmpty(children))
                {
                    _doc = GetJDDataByHtml(children);
                }
                else
                {
                    _doc = doc;
                }

            }

            if (_doc != null)
            {
                if (SingleNode)
                {
                    return _doc.DocumentNode.SelectSingleNode(xpath);
                }
                else
                {
                    return _doc.DocumentNode.SelectNodes(xpath);
                }
            }
            return null;
        }

        #endregion

        #region 获取品牌
        //public void GetJDBrand(string url = "http://list.jd.com/list.html?cat=9987,653,655")
        //{
        //    string xpath = "//*[@id='brandsArea']/*";
        //    HtmlNodeCollection nodes = AnalysisDB(xpath, url, null, false, null) as HtmlNodeCollection;
        //    List<Brand> lst = new List<Brand>();
        //    foreach (var item in nodes)
        //    {
        //        Brand brand = new Brand();
        //        brand.Id = Guid.NewGuid().ToString();
        //        brand.BrandStatus = 1;
        //        string BrandName = item.InnerText.Trim();

        //        brand.BrandName = BrandName;
        //        brand.BrandCode = BrandName;
        //        HtmlNode node1 = item.ChildNodes.FirstOrDefault();
        //        HtmlNodeCollection node = AnalysisDB("//*", null, null, false, item.OuterHtml) as HtmlNodeCollection;
        //        foreach (var imgNode in node)
        //        {
        //            if (imgNode.Name == "img")
        //            {
        //                brand.logoImages = imgNode.Attributes["src"].Value.Trim();
        //            }
        //        }

        //        lst.Add(brand);
        //    }

        //    BuinessDBContext context = new BuinessDBContext();
        //    IBrandResponsity responsity = new BrandResponsity(context);

        //    //foreach (var item in lst)
        //    //{
        //    //    responsity.Add(item);
        //    //}
        //}
        #endregion

        #region 获取 类别
        //public void GetJDItemCategory(string url = "https://www.jd.com/allsort.aspx")
        //{

        //    string xpath = "//*[@class='clearfix']";
        //    HtmlNodeCollection nodes = AnalysisDB(xpath, url, null, false, null) as HtmlNodeCollection;
        //    List<Category> categoryList = new List<Category>();
        //    foreach (var item in nodes)
        //    {
        //        Category category = new Category();
        //        category.Id = Guid.NewGuid().ToString();

        //        HtmlNode mynodes = AnalysisDB("//dt", null, null, true, item.InnerHtml) as HtmlNode;
        //        category.CategoryName = mynodes.InnerText.Trim();
        //        category.CategoryStatus = 1;
        //        category.CategoryCode = mynodes.InnerText.Trim();
        //        category.Pid = "0";
        //        HtmlNodeCollection ddnodes = AnalysisDB("//dd/a", null, null, false, item.InnerHtml) as HtmlNodeCollection;

        //        foreach (var dditem in ddnodes)
        //        {
        //            Category nodecategory = new Category();
        //            nodecategory.Id = Guid.NewGuid().ToString();
        //            nodecategory.CategoryName = dditem.InnerText.Trim();
        //            nodecategory.CategoryStatus = 1;
        //            nodecategory.CategoryCode = dditem.InnerText.Trim();
        //            nodecategory.Pid = category.Id;
        //            categoryList.Add(nodecategory);
        //        }
        //        categoryList.Add(category);
        //    }

        //    BuinessDBContext context = new BuinessDBContext();
        //    ICategoryResponsity responsity = new CategoryResponsity(context);

        //    foreach (var item in categoryList)
        //    {
        //        try
        //        {
        //            responsity.Add(item);
        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    }

        //}

        #endregion

        public void GetJDItem(string url = "https://list.jd.com/list.html?cat=9987,653,655")
        {
            string xpath = "//*[@id='brandsArea']";
            HtmlNode node = AnalysisDB(xpath, url, null, true, null) as HtmlNode;

            HtmlNodeCollection BrandNodes = AnalysisDB("//li/a", null, null, false, node.InnerHtml) as HtmlNodeCollection;
            TaskFactory factory = new TaskFactory();
            List<Task> task = new List<Task>();

            foreach (var item in BrandNodes)
            {
                string href = "http://list.jd.com" + item.Attributes["href"].Value;

                string BrandName = item.Attributes["title"].Value;
                string PagesXpath = "//*[@id='J_topPage']/span/i";
                HtmlNode ItemListPaged = AnalysisDB(PagesXpath, href, null, true, null) as HtmlNode;
                int TotalCoun = int.Parse(ItemListPaged.InnerText);

                Action action = new Action(() =>
                {
                    StartNew(TotalCoun, href, BrandName);
                });

                Task tasks = factory.StartNew(action);
                task.Add(tasks);
            }
            Task.WaitAll(task.ToArray());
            Console.WriteLine("总共抓取到数据条数：" + reqslst.Count);
        }

        public void StartNew(int TotalCoun, string href, string BrandName)
        {
            for (int i = 0; i < TotalCoun; i++) //具体商品信息
            {
                string ItemListHref = href + "&page=" + (i + 1);
                HtmlNodeCollection ItemList = AnalysisDB("//*[@id='plist']/ul/li", ItemListHref, null, false, null) as HtmlNodeCollection;
                foreach (var childrenitem in ItemList)
                {
                    HtmlNode ItemNameNode = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a/em", null, null, true, childrenitem.InnerHtml) as HtmlNode;
                    string ItemName = ItemNameNode.InnerText.Trim();
                    myItem myitem = SetMyItem(ItemName, BrandName);
                    HtmlNode ItemDetailNodes = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a", null, null, true, childrenitem.InnerHtml) as HtmlNode;
                    string itemDetailHref = "http:" + ItemDetailNodes.Attributes["href"].Value;
                    myitem.ItemCode = itemDetailHref.Substring(itemDetailHref.LastIndexOf('/') + 1, itemDetailHref.LastIndexOf('.') - itemDetailHref.LastIndexOf('/') - 1);
                    HtmlNodeCollection ItemDetailImagesNode = AnalysisDBGBK("//*[@id='spec-list']/ul/li/img", itemDetailHref, null, false, null) as HtmlNodeCollection;
                    HtmlNode ItemDetailSkuNodeName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[1]", itemDetailHref, null, true, null) as HtmlNode;
                    HtmlNodeCollection ItemDetailSkuNodeDetailName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[2]/div/a", itemDetailHref, null, false, null) as HtmlNodeCollection;
                    SetMyItemSku(ref myitem, ItemDetailSkuNodeDetailName);
                    SetMyItemImages(ref myitem, ItemDetailImagesNode);
                    reqslst.Add(myitem);
                }
                Console.WriteLine("品牌：" + BrandName + "共" + (TotalCoun) + "页，第" + (i + 1) + "页,抓取到" + ItemList.Count + "条数据信息");
            }
        }


        //public void StartNew(int TotalCoun, string href, string BrandName)
        //{
        //    try
        //    {
        //        //TaskFactory factory = new TaskFactory();
        //        Console.WriteLine("*****************开始************************");
        //        for (int i = 0; i < TotalCoun; i++) //具体商品信息
        //        {
        //            CreateNewTask(href, i, BrandName, TotalCoun);
        //            //Action action = new Action(() =>
        //            //{
        //            //    CreateNewTask(href, i, BrandName);
        //            //});
        //            //task.Add(factory.StartNew(action));
        //        }
        //        //Task.WaitAll(task.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Log4NetExport log = Log4NetExport.Create(typeof(GetJDItemLIst));
        //        log.Error(string.Format("错误信息 ", ex.Message));
        //    }

        //}

        //public void CreateNewTask(string href, int i, string BrandName, int TotalCoun)
        //{

        //    TaskFactory factory = new TaskFactory();
        //    factory.StartNew(new Action(() =>
        //    {
        //        NewStart(href, i, BrandName);
        //    }));


        //    string ItemListHref = href + "&page=" + (i + 1);
        //    HtmlNodeCollection ItemList = AnalysisDB("//*[@id='plist']/ul/li", ItemListHref, null, false, null) as HtmlNodeCollection;
        //    foreach (var childrenitem in ItemList)
        //    {
        //        HtmlNode ItemNameNode = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a/em", null, null, true, childrenitem.InnerHtml) as HtmlNode;
        //        string ItemName = ItemNameNode.InnerText.Trim();
        //        myItem myitem = SetMyItem(ItemName, BrandName);
        //        HtmlNode ItemDetailNodes = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a", null, null, true, childrenitem.InnerHtml) as HtmlNode;
        //        string itemDetailHref = "http:" + ItemDetailNodes.Attributes["href"].Value;
        //        myitem.ItemCode = itemDetailHref.Substring(itemDetailHref.LastIndexOf('/') + 1, itemDetailHref.LastIndexOf('.') - itemDetailHref.LastIndexOf('/') - 1);
        //        HtmlNodeCollection ItemDetailImagesNode = AnalysisDBGBK("//*[@id='spec-list']/ul/li/img", itemDetailHref, null, false, null) as HtmlNodeCollection;
        //        HtmlNode ItemDetailSkuNodeName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[1]", itemDetailHref, null, true, null) as HtmlNode;
        //        HtmlNodeCollection ItemDetailSkuNodeDetailName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[2]/div/a", itemDetailHref, null, false, null) as HtmlNodeCollection;
        //        SetMyItemSku(ref myitem, ItemDetailSkuNodeDetailName);
        //        SetMyItemImages(ref myitem, ItemDetailImagesNode);
        //        reqslst.Add(myitem);

        //        //BuinessDBContext context = new BuinessDBContext();
        //        //IItemResponsity Service = new ItemResponsity(context);
        //        //IItemPriceResponsity ServicePrice = new ItemPriceResponsity(context);
        //        //IItemImagesResponsity ServiceImages = new ItemImagesResponsity(context);
        //        //ISkuResponsity ServiceSku = new SkuResponsity(context);
        //        //IPriceSkuResponsity ServicePriceSku = new PriceSkuResponsity(context);

        //        //Mapper.Initialize(cfg => cfg.CreateMap<myItem, Item>());

        //        //Service.Add(Mapper.Map<Item>(myitem));

        //        //foreach (var item in myitem.imagesList)
        //        //{
        //        //    Mapper.Initialize(cfg => cfg.CreateMap<myImages, ItemImages>());
        //        //    ItemImages images = Mapper.Map<ItemImages>(item);
        //        //    ServiceImages.Add(images);
        //        //}

        //        //foreach (var item in myitem.info)
        //        //{
        //        //    Mapper.Initialize(cfg => cfg.CreateMap<SkuInfo, Sku>());
        //        //    Sku images = Mapper.Map<Sku>(item);
        //        //    ServiceSku.Add(images);
        //        //}

        //        //foreach (var item in myitem.priceList)
        //        //{
        //        //    Mapper.Initialize(cfg => cfg.CreateMap<myPrice, ItemPrice>());
        //        //    ItemPrice myprices = Mapper.Map<ItemPrice>(item);
        //        //    ServicePrice.Add(myprices);
        //        //    Mapper.Initialize(cfg => cfg.CreateMap<mySku, Sku>());
        //        //    foreach (var skuitem in item.skuList)
        //        //    {
        //        //        ServicePriceSku.Add(new PriceSku()
        //        //        {
        //        //            Id = Guid.NewGuid().ToString(),
        //        //            PriceId = skuitem.PriceId,
        //        //            SkuId = skuitem.SkuId
        //        //        });
        //        //    }
        //        //}
        //        //Console.WriteLine(myitem.toJson());

        //    }
        //    Console.WriteLine(href + "获取总条数：" + ItemList.Count() + ",名牌：" + BrandName + ",第" + (i + 1) + "页,总页数：" + TotalCoun);
        //}

        //public void NewStart(string href, int i, string BrandName)
        //{
        //    Console.WriteLine("开始第" + (i + 1) + "页," + BrandName);
        //    string ItemListHref = href + "&page=" + (i + 1);
        //    HtmlNodeCollection ItemList = AnalysisDB("//*[@id='plist']/ul/li", ItemListHref, null, false, null) as HtmlNodeCollection;
        //    foreach (var childrenitem in ItemList)
        //    {
        //        HtmlNode ItemNameNode = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a/em", null, null, true, childrenitem.InnerHtml) as HtmlNode;
        //        string ItemName = ItemNameNode.InnerText.Trim();
        //        myItem myitem = SetMyItem(ItemName, BrandName);
        //        HtmlNode ItemDetailNodes = AnalysisDB("//*[@class='gl-i-wrap j-sku-item']/div[4]/a", null, null, true, childrenitem.InnerHtml) as HtmlNode;
        //        string itemDetailHref = "http:" + ItemDetailNodes.Attributes["href"].Value;
        //        myitem.ItemCode = itemDetailHref.Substring(itemDetailHref.LastIndexOf('/') + 1, itemDetailHref.LastIndexOf('.') - itemDetailHref.LastIndexOf('/') - 1);
        //        HtmlNodeCollection ItemDetailImagesNode = AnalysisDBGBK("//*[@id='spec-list']/ul/li/img", itemDetailHref, null, false, null) as HtmlNodeCollection;
        //        HtmlNode ItemDetailSkuNodeName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[1]", itemDetailHref, null, true, null) as HtmlNode;
        //        HtmlNodeCollection ItemDetailSkuNodeDetailName = AnalysisDBGBK("//*[@id='choose-attr-1']/div[2]/div/a", itemDetailHref, null, false, null) as HtmlNodeCollection;
        //        SetMyItemSku(ref myitem, ItemDetailSkuNodeDetailName);
        //        SetMyItemImages(ref myitem, ItemDetailImagesNode);
        //        reqslst.Add(myitem);
        //    }
        //}

        public myItem SetMyItem(string ItemName, string BrandName)
        {
            myItem myitem = new myItem()
            {
                ItemDescription = ItemName,
                BrandId = BrandName,
                ItemStatus = 1,
                SourcesId = 1, //爬虫 京东来源,
                IsUseCoupon = 0,
                Id = Guid.NewGuid().ToString(),
                CategoryId = "9a8b0fd4-515c-4202-ba74-9c1de7590fc8", //手机
                IsGift = 0,
                ItemName = ItemName
            };
            return myitem;
        }

        public void SetMyItemImages(ref myItem myitem, HtmlNodeCollection collection)
        {
            if (collection != null)
            {
                foreach (var imagesItem in collection)
                {
                    string src = "http:" + imagesItem.Attributes["src"].Value;
                    myitem.imagesList.Add(new myImages()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ImagesUrl = src,
                        ItemId = myitem.Id
                    });
                }
            }

        }

        public void SetMyItemSku(ref myItem myitem, HtmlNodeCollection collection)
        {
            if (collection != null)
            {
                foreach (var skuNameItem in collection)
                {

                    Random ran = new Random();
                    decimal price = ran.Next(1000, 50000);
                    string skuName = skuNameItem.InnerText.Trim();

                    SkuInfo skuchildren = new SkuInfo()
                    {
                        SkuName = skuName,
                        Id = Guid.NewGuid().ToString(),
                        SkuCode = skuName,
                        pid = "0"
                    };

                    myPrice myprice = new myPrice()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ItemId = myitem.Id,
                        Price = price,
                        StoreCount = 999,

                    };

                    myprice.skuList.Add(new mySku()
                    {
                        Id = Guid.NewGuid().ToString(),
                        PriceId = myprice.Id,
                        SkuId = skuchildren.Id,

                    });

                    myitem.priceList.Add(myprice);
                    myitem.info.Add(skuchildren);
                }
            }

        }
    }
}
