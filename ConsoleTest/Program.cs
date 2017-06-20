using AutoMapper;
using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using Newtonsoft.Json;
using Redis;
using Responsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq.Expressions;
using DataCommTools;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Xml;
using System.ComponentModel;

namespace ConsoleTest
{
    public class ItemTest
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemStore { get; set; }
        public string ItemPrice { get; set; }
    }
    class Program
    {
        public static int count = 0;

        public static void CallBack(List<ItemTest> lst)
        {
            foreach (var item in lst)
            {
                try
                {
                    BuinessDBContext context = new BuinessDBContext();
                    IItemResponsity Service = new ItemResponsity(context);
                    IItemPriceResponsity ServicePrice = new ItemPriceResponsity(context);
                    IItemImagesResponsity ServiceImages = new ItemImagesResponsity(context);
                    ISkuResponsity ServiceSku = new SkuResponsity(context);
                    IPriceSkuResponsity ServicePriceSku = new PriceSkuResponsity(context);
                    Mapper.Initialize(cfg => cfg.CreateMap<ItemTest, Item>());
                    Item entity = Mapper.Map<Item>(item);
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CategoryId = "9a8b0fd4-515c-4202-ba74-9c1de7590fc8";
                    entity.BrandId = "e07115a3-7563-4435-8622-ff2e089c454f";
                    entity.ItemStatus = 1;
                    entity.SourcesId = 9;
                    Service.Add(entity);

                    ItemPrice itemprice = new ItemPrice()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ItemId = entity.Id,
                        Price = Decimal.Parse(item.ItemPrice),
                        StoreCount = Convert.ToInt32(item.ItemStore)
                    };

                    ServicePrice.Add(itemprice);

                    ServicePriceSku.Add(new PriceSku()
                    {
                        Id = Guid.NewGuid().ToString(),
                        PriceId = itemprice.Id,
                        SkuId = "17031031-6397-4B81-8EAE-47A4CAE1E3A6"
                    });
                }
                catch (Exception)
                {
                    Console.WriteLine(item.ItemStore + ":" + item.ItemPrice);
                }
            }
            count += lst.Count();
        }

        public static void InsertToRedisSetList(string FirstCode, int Start, int End, string CouponCategoryId)
        {
            RedisSetService _RedisSetService = new RedisSetService();
            for (int i = Start; i < End; i++)
            {
                try
                {
                    _RedisSetService.Add("CouponCategory" + CouponCategoryId, FirstCode + i);

                }
                catch (Exception ex)
                {

                    Console.WriteLine("处理数据失败{0},{1}", i, ex.Message);
                }

            }
        }

        public static void GetList(int Index, ConcurrentBag<User> lst)
        {
            for (int i = 0; i < 100000; i++)
            {
                User user = new User()
                {
                    Id = ((i + 1) * Index).ToString(),
                    UserName = "小银子" + ((i + 1) * Index)
                };

                lst.Add(user);
            }
        }


        public class GenericCache<T> where T : new()
        {
            private static T Instances = default(T);

            static GenericCache()
            {
                Instances = new T();
            }

            public static T GetInstances()
            {
                return Instances;
            }
        }

        static void Run1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("小银子");
        }
        static void Run2()
        {
            Thread.Sleep(5000);
            Console.WriteLine("小俊子");
        }
     
        public bool IsEnabled { get; set; } = false;


        public enum MessageLevelEnum
        {
            [Description("成功提示")]
            Success = 0,
            [Description("错误提示")]
            Error = 1,
            [Description("警告提示")]
            Warming = 2,
            [Description("感叹号提示")]
            Advisory = 3,
            [Description("问号提示")]
            Question = 4
        }

        public static void JsonToXml()
        {


            string a = ((int)MessageLevelEnum.Error).ToString();
            Console.WriteLine(a);

            string json = @"{'root': {
                                'person': [
                                  {
                                    '@id': '1',
                                    '小银子': 'Alan',
                                    '性别': 'http://www.google.com'
                                  },
                                  {
                                    '@id': '2',
                                    '小银子': 'Louis',
                                    '性别': 'http://www.yahoo.com'
                                  }
                                ]
                              }
                            }";


            XmlDocument doc1 = JsonConvert.DeserializeXmlNode(json);
            Console.WriteLine(doc1.OuterXml);
        }


        static void Main(string[] args)
        {







            //JsonToXml();
            //Console.ReadLine();

            //while (true)
            //{
            //    string test = Console.ReadLine();

            //    string a = JsonConvert.DeserializeObject<string>(test);

            //    Console.WriteLine(a);
            //    Console.ReadLine();
            //}
          

            //Program p = null; new Program();
            //bool? b = p?.IsEnabled;   //可空
            //Console.WriteLine(b);
            Console.ReadLine();
            //Stopwatch st = new Stopwatch();
            ////st.Start();
            ////List<Action> actionlist = new List<Action>();
            ////actionlist.Add(Run1);
            ////actionlist.Add(Run2);

            ////Parallel.Invoke(Run1,Run2);
            ////st.Stop();
            ////Console.WriteLine("运行毫秒数{0}", st.ElapsedMilliseconds);

            ////st.Restart();
            ////Run1();
            ////Run2();
            ////st.Stop();
            ////Console.WriteLine("运行毫秒数{0}", st.ElapsedMilliseconds);
            ////Console.ReadLine();
            //List<User> users = new List<User>();
            //users.Add(new User() { Id = "123", UserEmail = "15221091317@163.com" });
            //users.Add(new User() { Id = "小银子1", UserEmail = "18317163623@163.com" });
            //users.Add(new User() { Id = "小银子2", UserEmail = "15221091317@163.com" });
            //users.Add(new User() { Id = "小银子3", UserEmail = "15221091317@163.com" });
            //users.Add(new User() { Id = "小银子4", UserEmail = "15221091317@163.com" });
            //users.Add(new User() { Id = "小银子5", UserEmail = "15221091317@163.com" });
            //users.Add(new User() { Id = "小银子6", UserEmail = "15221091317@163.com" });
            //SpinLock locks = new SpinLock();
            //bool Flag = false;
            //locks.Enter(ref Flag);
            //// Parallel.ForEach(users, t =>
            ////   {
            ////       Console.WriteLine(t.Id);
            ////   });
            ////// st.Stop();
            //// Console.WriteLine("运行毫秒数{0}", st.ElapsedMilliseconds);
            //// st.Start();
            //// foreach (var item in users)
            //// {
            ////     Console.WriteLine(item.Id);
            //// }
            //// st.Stop();
            //// Console.WriteLine("运行毫秒数{0}", st.ElapsedMilliseconds);
            //// Console.ReadLine();


            ////List<int> list = new List<int>();
            ////Parallel.For(0, 10000, item =>
            ////{
            ////    list.Add(item);
            ////});
            ////Console.WriteLine("List's count is {0}", list.Count());

            //ConcurrentBag<int> list = new ConcurrentBag<int>();
            //Parallel.For(0, 100000, item =>
            //{
            //    list.Add(item);
            //});
            //Console.WriteLine("ConcurrentBag's count is {0}", list.Count());

            //List<Task> tasklist = new List<Task>();

            //var task1 = Task.Factory.StartNew(() =>
            //  {
            //      Console.WriteLine("父线程");
            //      var task2 = Task.Factory.StartNew(() =>
            //        {
            //            Thread.Sleep(3000);
            //            Console.WriteLine("子线程");
            //        }, TaskCreationOptions.AttachedToParent);
            //  });
            //tasklist.Add(task1);
            //Task.WaitAll(tasklist.ToArray(), 5000);
            //Console.WriteLine("小银子");
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + ".xls");
            Console.ReadLine();
            ////st.Start();
            ////var result1=list.Where(m => m > 1000);
            ////st.Stop();
            ////Console.WriteLine("Linq 耗时："+st.ElapsedMilliseconds);
            //st.Start();
            //var result2 = list.AsParallel().Where(m => m > 1000);
            //st.Stop();
            //Console.WriteLine("Linq AsParallel 多线程耗时：" + st.ElapsedMilliseconds);
            //Console.ReadLine();
            ////BuinessDBContext context = new BuinessDBContext();
            ////VipCouponMapResponsity VipCouponService = new VipCouponMapResponsity(context);
            ////VipCouponService.FindJoinByVipId();




            //ILookup<string, string> test = users.ToLookup(cfg => cfg.Id, cfg => cfg.UserEmail);
            //foreach (var item in test)
            //{
            //    //foreach (var i in item)
            //    //{
            //    //    Console.WriteLine(item.Key + "---" + i);
            //    //}
            //    Console.WriteLine(item.Key + "---" + item.FirstOrDefault());
            //}
            //Console.ReadLine();

            //Stopwatch watch = new Stopwatch();

            //watch.Start();
            //ConcurrentBag<User> lst = new ConcurrentBag<User>();
            //List<Task> tasklist = new List<Task>();
            //TaskFactory factory = new TaskFactory();
            //int Index = 0;
            //while (Index <= 10)
            //{
            //    Action action = new Action(() =>
            //    {
            //        GetList(Index, lst);
            //    });

            //    Task mytask = factory.StartNew(action);
            //    tasklist.Add(mytask);
            //    Index++;
            //}
            //watch.Stop();

            //Task.WaitAll(tasklist.ToArray());
            //Console.WriteLine("共耗时：{0}",watch.ElapsedMilliseconds);
            //Console.WriteLine("线程安全集合数量：{0}", lst.Count);
            //Console.ReadLine();

            ////foreach (var item in lst)
            ////{
            ////    Console.WriteLine(item.UserName);
            ////}

            //watch.Stop();
            //Console.WriteLine(lst.Count + "-----" + Index + "---ss--" + watch.Elapsed.Milliseconds);

            Console.ReadLine();


            //  Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss")+DateTime.Now.Millisecond);

            //根据某个字段去重
            // UserList=vipList.Where((x, z) => vipList.FindIndex(i => i.VipCardLevel == x.VipCardLevel) == z).ToList();
            //BuinessDBContext context = new BuinessDBContext();
            //IUserResponsity UserService = new UserResponsity(context);
            //IVipResponsity VipService = new VipsResponsity(context);
            //Expression<Func<User, bool>> fun = t => t.Id.Length > 0;

            //var lst = UserService.FindList(fun);
            //RedisSetService SetService = new RedisSetService();
            //foreach (var item in lst)
            //{
            //    string VipIdPhone = SetService.GetRandomItemFromSet("Vip");
            //    string VipIdEmail = SetService.GetRandomItemFromSet("Vip");

            //    Expression<Func<Vip, bool>> vipPhone = t => t.Id == VipIdPhone;
            //    Vip vipPhoneEntity = VipService.Get(vipPhone);


            //    Expression<Func<Vip, bool>> vipEmail = t => t.Id == VipIdEmail;
            //    Vip vipEmailEntity = VipService.Get(vipEmail);

            //    string sql = string.Format("UPDATE [User] SET UserPhone = '{0}', UserEmail = '{1}' WHERE Id='{2}'", vipPhoneEntity.VipPhone, vipEmailEntity.VipEmail, item.Id);
            //    VipService.Excutes(sql);

            //    SetService.Add("User", item.Id);
            //}
            Console.WriteLine("随机完成");
            //{
            //    //订单 奖励规则还没设计呢
            //    BuinessDBContext context = new BuinessDBContext();
            //    IOrderRewardRuleResponsity RuleService = new OrderRewardRuleResponsity(context);
            //    Expression<Func<OrderRewardRule, bool>> predicate = t => t.Id.Length > 0;
            //    var lst = RuleService.FindList(predicate);
            //    RedisSetService SetService = new RedisSetService();
            //    HashSet<string> OrdersList = SetService.GetAllItemsFromSet("OrderReWard");
            //    IVipResponsity VipService = new VipsResponsity(context);
            //    IAmountDetailResponsity AmountDetailService = new AmountDetailResponsity(context);
            //    IPointsDetailResponsity PointsDetailService = new PointsDetailResponsity(context);
            //    IOrderResponsity OrderService = new OrderResponsity(context);
            //    foreach (var item in OrdersList)
            //    {
            //        Orders myorder = item.ToEntity<Orders>();


            //        foreach (var nodeitem in lst)
            //        {

            //            if (nodeitem.RewardCondition == 0) //0=首单奖励
            //            {
            //                Expression<Func<Orders, bool>> orderpredicate = t => t.VIpId == myorder.VIpId;
            //                var firstorders = OrderService.Get(orderpredicate);
            //                if (firstorders != null || String.IsNullOrEmpty(firstorders.Id))
            //                {
            //                    continue;
            //                }
            //            }


            //            if (nodeitem.RewardCondition == 2)  //2=满N元奖励
            //            {

            //                if (true)
            //                {
            //                    continue;
            //                }
            //            }

            //            if (nodeitem.RewardCategory == 0) //Vip
            //            {
            //                Expression<Func<Vip, bool>> vippredicate = t => t.Id == myorder.VIpId;
            //                Vip vipentity = VipService.Get(vippredicate);

            //                if (nodeitem.RewardFunction == 0) //积分
            //                {
            //                    int RewardPoints = Convert.ToInt32(myorder.ActualAmount * Convert.ToInt32(nodeitem.RewardValue)) / 100;
            //                    string sql = string.Format("UPDATE VIP SET VipPoints =VipPoints+{0} WHERE Id='{1}'", RewardPoints, myorder.VIpId);
            //                    PointsDetail detail = new PointsDetail()
            //                    {
            //                        Id = Guid.NewGuid().ToString(),
            //                        Points = Convert.ToInt32(myorder.UsePoint),
            //                        PointsDate = myorder.OrderDate,
            //                        PointsSourceId = "4",
            //                        ObjectId = myorder.Id,
            //                        UnitId = myorder.UnitId,
            //                    };
            //                    PointsDetailService.Add(detail);

            //                    //添加 积分 详情
            //                }
            //                else if (nodeitem.RewardFunction == 1) //余额
            //                {
            //                    decimal RewardAmount = Convert.ToDecimal(myorder.ActualAmount * Convert.ToInt32(nodeitem.RewardValue)) / 100;
            //                    string sql = string.Format("UPDATE VIP SET VipAmount =VipAmount+{0} WHERE Id='{1}'", RewardAmount, myorder.VIpId);

            //                    //添加 余额 详情
            //                    AmountDetail detail = new AmountDetail()
            //                    {
            //                        Id = Guid.NewGuid().ToString(),
            //                        Amount = myorder.UseAmount,
            //                        AmountDate = myorder.OrderDate,
            //                        AmountSourceId = "4",
            //                        ObjectId = myorder.Id,
            //                        UnitId = myorder.UnitId,
            //                    };
            //                    AmountDetailService.Add(detail);
            //                }
            //                else if (nodeitem.RewardFunction == 2) //优惠券
            //                {
            //                    //随机优惠券 添加映射表   暂不支持
            //                    // SetService.GetRandomItemFromSet("");
            //                }
            //            }
            //        }
            //        SetService.RemoveItemFromSet("OrderReWard",item);
            //    }
            //    Thread.Sleep(100);
            //}
            //Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHMMss"));
            //return;
            //BuinessDBContext context = new BuinessDBContext();
            //RedisSetService _RedisSetService = new RedisSetService();

            //IVipCouponMapResponsity MA = new VipCouponMapResponsity(context);
            //Expression<Func<VipCouponMap, bool>> fun = t => t.Id.Length > 0;

            //var lst = MA.FindList(fun);
            //foreach (var item in lst)
            //{
            //    _RedisSetService.Add("Vip", item.VipId);
            //}

            //Console.WriteLine("随机完成");
            //int TaskCount = 5;
            //int PageSize = Convert.ToInt32(1000 % TaskCount == 0 ? 1000 / TaskCount : (1000 / TaskCount) + 1);
            //TaskFactory factory = new TaskFactory();
            //List<Task> tasklist = new List<Task>();
            //string Key = Guid.NewGuid().ToString();
            //RedisSetService _RedisSetService = new RedisSetService();
            //for (int i = 0; i < 1000; i++)
            //{
            //    _RedisSetService.Add("CouponCategory" + Key, "XiaoYinZi" + i);
            //}
            //BuinessDBContext context = new BuinessDBContext();
            //IVipResponsity Service = new VipsResponsity(context);
            //RedisSetService RedisServer = new RedisSetService();
            //int Index = 0;
            //while (Index < 6000)
            //{
            //    string VipId = RedisServer.GetRandomItemFromSet("Vip");

            //    string VipId1 = RedisServer.GetRandomItemFromSet("Vip");

            //    if (VipId != VipId1)
            //    {
            //        string sql = string.Format("UPDATE VIP SET VipOnLineId = '{0}', VipOnLineCategory = 1 WHERE Id='{1}'", VipId, VipId1);
            //        Service.Test(sql);
            //    }
            //}

            //int Index = 0;
            //int CouponCount = RedisServer.GetRandomItemFromSet("CouponCategoryfcda2b80-f9e1-4e98-9853-2697846ebf8d").Count();
            //while (Index < 6000 && CouponCount==0)
            //{
            //    string VipId = RedisServer.GetRandomItemFromSet("Vip");
            //    string CouponCode = RedisServer.GetRandomItemFromSet("CouponCategoryfcda2b80-f9e1-4e98-9853-2697846ebf8d");
            //    if (String.IsNullOrEmpty(CouponCode))
            //    {
            //        Console.WriteLine("优惠券已经领取完毕啦，");
            //        Console.ReadLine();
            //    }
            //    BuinessDBContext context = new BuinessDBContext();
            //    ICouponResponsity couponsity = new CouponResponsity(context);
            //    IVipCouponMapResponsity VipCouponMapService = new VipCouponMapResponsity(context);
            //    Coupon couponentity = new Coupon()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        CouponCategoryId = "fcda2b80-f9e1-4e98-9853-2697846ebf8d",
            //        CouponCode = CouponCode
            //    };
            //    RedisServer.RemoveItemFromSet("CouponCategoryfcda2b80-f9e1-4e98-9853-2697846ebf8d", CouponCode);
            //    VipCouponMap entitymap = new VipCouponMap()
            //    {
            //        CouponId = couponentity.Id,
            //        Id = Guid.NewGuid().ToString(),
            //        IsUse = 0,
            //        OrderId = "",
            //        VipCouponStatus = 0,
            //        VipId = VipId
            //    };
            //    couponsity.Add(couponentity);
            //    VipCouponMapService.Add(entitymap);

            //    RedisServer.RemoveItemFromSet("Vip",VipId);

            //    Console.WriteLine("随机完成");
            //    Index++;
            //}
            Console.WriteLine("全部随机完成");



            //for (int i = 0; i < TaskCount; i++)
            //{
            //    int Start = i * PageSize;
            //    int End = (i + 1) * PageSize;

            //    Action action = () =>
            //    {
            //        InsertToRedisSetList("XiaoYinZi", Start, End, Key);
            //    };
            //    tasklist.Add(factory.StartNew(action));
            //    Console.WriteLine("线程{0} 启动成功，数据分段为 {1}-{2}", i + 1, Start, End);
            //}

            //Task.WaitAll(tasklist.ToArray());
            //Console.WriteLine("全部完成");
            Console.ReadLine();
            //int taskCount = 20;
            //DateTime dtStart = DateTime.Now;
            //DataTable dt = Tools.ToDataTable().Tables[0];
            //List<ItemTest> lst = Tools.GetEntities<ItemTest>(dt).ToList();
            //int PageSize = lst.Count % taskCount == 0 ? lst.Count / taskCount : (lst.Count / taskCount) + 1;
            //TaskFactory factory = new TaskFactory();
            //List<Task> lsttask = new List<Task>();
            //for (int i = 0; i < taskCount; i++)
            //{
            //    var lsts = lst.Skip(i * PageSize).Take(PageSize).ToList();

            //    Action action = () =>
            //    {
            //        CallBack(lsts);
            //    };
            //    Task task = factory.StartNew(action);
            //    lsttask.Add(task);
            //}

            //Task.WaitAll(lsttask.ToArray());
            //DateTime dtSop = DateTime.Now;
            //Console.WriteLine(count + "共耗时：" + dtSop + "," + dtStart);

            //GetJDItemLIst list = new GetJDItemLIst();
            ////list.GetJDBrand();
            ////list.GetJDItemCategory();
            //list.GetJDItem();
            //Console.ReadLine();
            //myItem myItem = new myItem()
            //{
            //     ItemName="小银子"
            //};
            //Mapper.Initialize(cfg => cfg.CreateMap<myItem, Item > ());
            //Item entity = Mapper.Map<Item>(myItem);

            //var imgData = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAYEBQYFBAYGBQYHBwYIChAKCgkJChQODwwQFxQYGBcUFhYaHSUfGhsjHBYWICwgIyYnKSopGR8tMC0oMCUoKSj/2wBDAQcHBwoIChMKChMoGhYaKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCj/wAARCADwAPADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD5UooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACip7azubpsWtvNMfSNC38q2LXwf4guTiLSrgH/poAn/oRFRKpCPxOxtTw1ar/AA4N+ibMCiuwi+HPiJhmS3hiH+3Mv9M1Yi+GeuyDO+yUe8jf/E1k8VRX2kdccoxstqUvuOHoru2+F+ugcS2J+krf/E1TuPh54hhHFtDJ/uTL/XFCxVF/aQSyjGx3pS+45City78J69aLmbSror6xp5g/8dzWNLFJC5SVGjcdVYYNbRnGXwu5x1KFSlpUi16qwyiiiqMgop8cbyuEjRnY9AoyafdW09pJ5d1BLDJgNtkQqcHocGldbD5Xa9tCGiiimIKKKKACiiigAooooAKKKKACiiigAooooAKKKKACvePCOh6PFoem3P8AZdsZpbeORpHTeSxUEnJzjn0rwevorwTIsvhLSeQcWyKR9BivMzOTjBWfU+q4VpwnXnzxT0/U2CkflYVVCAcADGKS2XEfuabIDECV+6eo9KktzmIYrwz7/oMb95Lt/hXrUjuI15/AUyH77/WibiVGb7tAB5xHLIQKkBV145BoBDDgg1GBsmAHRu1IBE/dybD909KbeW8VxFiaNJAOcOoIp9wMKG9Dmpeop36iavuZEuiaO6Bn0nT3Y+tsh/pTrfw9pEXI0uwDeot0GP0q5bgs5z0Sp5H2IT+VVzy2uZfV6V/hX3IjRILVdsESJn+FFAryP4zwY1iwuSu1pYCh99rf/ZV69EmPmbljXl3xwA8zR2HpMP8A0D/GuvL3/tC+f5Hj8RQX9nz02t+aPLqKKK+iPzQKKKKACiiigAooooAKKKKACiiigAooooAKKKKACvonwlYzWXhfTYZxsuEhG4emecH868d+HeinWPEcIdd1vb/vpPQ46D8T+gNe/wDavGzSqrqmvU+34Twkoxnin10X6/16jEIkjye/WorY7WaI9jxUlv8Adb0zUbITMxX7wryT7Ic/7uTf/CeDU3DD1FRo6uMMMHuDSeTj7jFfagCQKqfdAFRg+ZMCOi96PJLffckelSAKi4HAFICO4OVA9Tipe1QofNk3fwr096lc7VJPagCK3x85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";
            ////过滤特殊字符即可   
            //string dummyData = imgData.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
            //if (dummyData.Length % 4 > 0)
            //{
            //    dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
            //}
            //byte[] byteArray = Convert.FromBase64String(dummyData);


            //string pic = @"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IPUrnthpZjiSGMWZfg0IGIJiEnN1GSmv9wcXDUMSYSSSSXNEe2pKAaezJJJxbwr43NiE1ddTzJaMZrr4HkZXhpCk5Gqls+yBE9L8GCNV0Y0tO5DGi4ShdUnYhisESufiJSEozoK9H7BJoxwJJ0EySF4CEjGryWE8jQK7Wxck2vOrjlOHckkQIPUcTuPYylLe9QkVs56r8BlsZikFFCQ1uonokVB1edPg4ESK0EBvukRYUSBEiRxJyZJIECjE2aIrmJqVMIrESBAiIWNqI6D6a3KRYkiSEhEknMlDTcv1HuOqAYJNI7ZH/oP3hCWoJrYgTmseIxjweCEIXgELJYx4GMYxk4rAhYEIWW8DGGe429yXuS9xNjMbEWT/AP/aAAwDAQACAAMAAAAQA84S2imEQ0www0w0Qk4wBLQ40w4ww0wwgw4w02w0wM8cFC69UWM8c8cc88soeJDcI88sss44g88sssdOssYcoVYU5yIEc88888ohmjLi888s884YaIzi080bf88c8oFCPhD2c888888oZLpgwU888888q08T7eqyaf8APPPI1bGwTGelPPPPPLHpfk0EPPPLDdMcMWXWs+5JHPPONgoHMeTYX/PPPPKO7APht9PPLDYRXQBD/mt6EnPPEeWz4Ul0Ow/PPPPIspCeluifLPG+dK++sLszIc8dfB1qcIiBQV4/PPPPAPBqYoF3lPPOJ3fFSrBr7nifzvBLnXdvtidQ/PPPLm/fz6dq+/PPKDHoQmg7YNX3PPPAN4BpeFkeSvPPPN+TrTpKUm//ADyzHKV5z+sb6fzzzxI1n6Y3EVrTzzyjPnWYzNx1r3zzTIYSln+k+BTzzjzwqJjKdU/xzzzywRXg1qFmeHTzzwzy+TX8JVbTzzjyi5Y2u7YIvzjzzgXFBL7/APuFT0847RZooBu77L088skL6esCtJs3D88oJP4+o93yf3k847aZQG1EbUP08888oM8UMFO8888888sMMMMMMs88888McMccMcc8c888888cT8Qf+88888840448wt88888888s4imS888888884pS4SK88888884ggA7+0z088888w4EiCE88888884fmwAepcS8w0440jL7t9uzj88448hJ+QZ2e88088wEhBiyAJEWM888sVQMLAALoM888KwqqZi5r/FU8s8DZBa7WqtXK+88884R1ZJ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";

            //pic = pic.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
            //if (pic.Length % 4 > 0)
            //{
            //    pic = pic.PadRight(pic.Length + 4 - pic.Length % 4, '=');
            //}

            //base64string到byte[]再到图片的转换：



            #region 完整版
            //第三方授权
            //const string url = "http://localhost:65180/";    /*--授权服务器*/
            //const string newurl = "http://localhost:63009/";  /*需要授权的资源信息*/
            //var client = new HttpClient();

            //string content = "grant_type=client_credentials&name=小银子&password=#123%";
            //var rst = client.PostAsync(url + "conntection/gettoken", new StringContent(content)).Result.Content.ReadAsStringAsync().Result;
            //var obj = JsonConvert.DeserializeObject<Token>(rst);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            //Console.WriteLine(obj.AccessToken);
            //Console.WriteLine(DateTime.Now);

            //while (true)
            //{
            //    Console.WriteLine("*********************************开始测试******************************");
            //    rst = client.GetStringAsync(newurl + "api/values").Result;
            //    Console.WriteLine(rst + " " + obj.AccessToken + " 过期时间：" + obj.expires_in);
            //    Console.ReadLine();
            //    Console.WriteLine("*********************************结束测试******************************");
            //    Console.WriteLine("*********************************按下任意键 重新开始测试******************************");
            //}
            //Console.ReadLine();
            #endregion



            ////第三方授权
            //const string url = "http://localhost:65180/";
            //// var client = new HttpClient();
            //Encoding encoding = Encoding.UTF8;
            //WebClient client = new WebClient();

            //client.Headers.Add("grant_type:client_credentials");
            //string content = "";

            //Uri urls = new Uri(url + "token");

            //string paramStr = "name=张三";

            //byte[] postData = encoding.GetBytes(paramStr);

            //byte[] responseData = client.UploadData(urls, postData);
            //string result = encoding.GetString(responseData);// 解码      

            //var obj = JsonConvert.DeserializeObject<Token>(rst);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", obj.AccessToken);
            //rst = client.GetStringAsync(url + "api/values").Result;
            //Console.WriteLine(rst);
            //Console.ReadLine();


            //    List<Category> lst = new Category().Initial();
            //    Action<object> action = Test;
            //    //int count = lst.Count;
            //    //int totalPage = count % 1 == 0 ? count / 1 : count / 1 + 1;

            //    BigDataTask.TaskStartNew<Category>(lst, action, 3, 1);


            //List<Task> lstTask = new List<Task>();
            //TaskFactory taskFactory = new TaskFactory();

            //for (int i = 0; i < 100; i++)
            //{

            //    Task task = taskFactory.StartNew(Test);
            //    lstTask.Add(task);
            //    if (i > 10)
            //    {
            //        lstTask = lstTask.Where(m => !m.IsCanceled && !m.IsCompleted && !m.IsFaulted).ToList();
            //        Console.WriteLine("线程等待中 {0}", lstTask.Count);
            //        Task.WaitAny(lstTask.ToArray());
            //    }
            //}

            //Task.WaitAll(lstTask.ToArray());


            //List<Task> lstTask = new List<Task>();
            //TaskFactory factory = new TaskFactory();
            //foreach (var item in lst)
            //{
            //    Action action = new Action(() =>
            //    {
            //        Test(item);
            //    });

            //    Task task = factory.StartNew(action);
            //    lstTask.Add(task);
            //    if (lstTask.Count > 3)
            //    {
            //        lstTask = lstTask.Where(m => !m.IsCompleted && !m.IsFaulted && !m.IsCanceled).ToList();
            //        Console.WriteLine("------------------------线程等待中。。。未完成线程数量{0}--------------------", lstTask.Count);
            //        Task.WaitAny(lstTask.ToArray());
            //    }
            //}
            //Task.WaitAll(lstTask.ToArray());
            //Console.WriteLine("全部线程完成 - -", DateTime.Now);
            Console.ReadLine();
        }

        public static void Test(object obj)
        {
            //Thread.Sleep(3000);
            List<Category> item = obj as List<Category>;
            Console.WriteLine("*****************当前线程为{0}***********类别名称 {1}，类别编号{2}*********", Thread.CurrentThread.ManagedThreadId, item.FirstOrDefault().Name, item.FirstOrDefault().Code);

            //Console.WriteLine("*****************当前线程为{0}*********", Thread.CurrentThread.ManagedThreadId);
        }
    }

    public class Token
    {
        [JsonProperty("Access_Token")]
        public string AccessToken { get; set; }

        public string expires_in { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<Category> Initial()
        {
            return new List<Category>()
            {
                new Category() { Id=1, Name="电子产品", Code="ZK1001" },
                new Category() { Id=2, Name="手机", Code="ZK1002" },
                 new Category() { Id=3, Name="数码产品",  Code="ZK1003" },
                 new Category() { Id=3, Name="服装设计",  Code="ZK1004" },
                 new Category() { Id=3, Name="男装",  Code="ZK1005" },
                 new Category() { Id=3, Name="女装",  Code="ZK1006" },
                 new Category() { Id=3, Name="童装",  Code="ZK1007" }
            };
        }
    }
}
