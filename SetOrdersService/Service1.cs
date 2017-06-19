using DataCommTools;
using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using Redis;
using Responsity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq.Expressions;

namespace SetOrdersService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {

            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            timSchedule.Enabled = true;
            timSchedule.Interval = 1000;
            timSchedule.Start();
            timSchedule_Tick(null, null);
        }



        protected override void OnStop()
        {

        }

        //调度
        private void timSchedule_Tick(object sender, EventArgs e)
        {
            new Action(() =>
            {
                while (true)
                {
                    SetOrder();
                    Thread.Sleep(3000);
                }
            }).BeginInvoke(null, null);
        }

        public void SetOrder()
        {

            RedisSetService SetService = new RedisSetService();


            Log4NetExport log = Log4NetExport.Create(typeof(Service1));

            string VipId = SetService.GetRandomItemFromSet("Vip");   //会员
            string UserId = SetService.GetRandomItemFromSet("User");   //员工
            string UnitId = SetService.GetRandomItemFromSet("Unit");  //门店
            List<ItemInfos> ItemList = new List<ItemInfos>();
            Random ran = new Random();
            int Index = ran.Next(1, 5);
            BuinessDBContext context = new BuinessDBContext();
            IVipResponsity VipService = new VipsResponsity(context);
            IAmountDetailResponsity AmountDetailService = new AmountDetailResponsity(context);
            IPointsDetailResponsity PointsDetailService = new PointsDetailResponsity(context);
            IItemResponsity ItemService = new ItemResponsity(context);
            IItemPriceResponsity ItemPriceService = new ItemPriceResponsity(context);

            while (Index < 5)
            {
                string ItemPriceId = SetService.GetRandomItemFromSet("ItemPrice");
                string ItemSql = string.Format(@"SELECT i.Id AS ItemId,ip.Id AS ItemPriceId,i.ItemName,i.ItemCode,ip.Price,ip.StoreCount,s.SkuName,s.SkuCode
                                                FROM ItemPrice AS ip
                                                INNER JOIN Item AS i ON ip.ItemId = i.Id
                                                INNER JOIN PriceSku AS ps ON ps.PriceId = ip.Id
                                                INNER JOIN  Sku AS s ON s.Id = ps.SkuId
                                                WHERE ps.PriceId = '{0}'", ItemPriceId);
                ItemInfos item = ItemService.GetItemBySql<ItemInfos>(ItemSql);
                ItemList.Add(item);
                Index++;
            }

            string sql = string.Format(@"SELECT * FROM (SELECT v.Id,
                                           v.VipName,
                                           v.VipOnLineId,
                                           ISNULL(v.VipOnLineCategory,0) AS VipOnLineCategory,
                                           isnull(v.VipPoints,0) AS VipPoints,
                                           isnull(v.VipAmount,0) AS VipAmount,
                                           (isnull(sct.DisCount,1.00)) AS DisCount,
                                           sct.Id as SysCardId,
                                           sct.SysCardName,
                                           (SELECT COUNT(*) FROM Orders AS o WHERE o.VIpId='{0}') AS OrderCount,
                                           ISNULL((SELECT SUM(O.TotalAmount) FROM Orders AS o WHERE o.VIpId='{0}'),0.00) AS OrderAmount,
                                           (
                                               SELECT TOP 1 ISNULL(sct2.IsSaleUpgrade,0) FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)+1
                                           ) AS NextIsSaleUpgrade,
                                           (
                                               SELECT TOP 1 ISNULL(sct2.SaleMinMoney,0.00) FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)+1
                                           )AS NextSaleMinMoney, 
                                           (
                                               SELECT TOP 1 ISNULL(sct2.SaleTotalUpgradeMinMOney,0.00) FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)+1
                                           )AS NextSaleTotalUpgradeMinMOney, 
                                           (
                                               SELECT TOP 1 ISNULL(sct2.RechargeMinMoney,0.00) FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)+1
                                           )AS NextRechargeMinMoney, 
                                            (
                                               SELECT TOP 1 ISNULL(sct2.IsFirstRechargeUpgrade,0) FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)+1
                                           )AS NextIsFirstRechargeUpgrade, 
                                           (
                                               SELECT TOP 1 sct2.SysCardName FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)
                                           )AS NextSysCardName,
                                           (
                                               SELECT TOP 1 sct2.SysCardLevel FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)
                                           )AS NextSysCardLevel,
                                           (
                                               SELECT TOP 1 sct2.Id FROM   SysCardType AS sct2
                                               WHERE  sct2.SysCardLevel = ISNULL(sct.SysCardLevel,1)
                                           )AS NextSysCardId
                                    FROM   Vip                    AS v
                                           LEFT JOIN SysCardType  AS sct ON  v.VipCardLevel = sct.Id
                                    WHERE v.Id='{0}' ) as t", VipId);

            VipInfo entity = VipService.GetVipByVipId<VipInfo>(sql); ;

            IVipCouponMapResponsity VipCouponMappingService = new VipCouponMapResponsity(context);

            CouponCategory CouponCategory = VipCouponMappingService.GetByVipId(VipId);


            Orders myorder = new Orders()
            {
                Id = Guid.NewGuid().ToString(),
                TotalAmount = ItemList.Sum(m => m.Price),
                ItemCount = ItemList.Count(),
                Discount = entity.DisCount.ToString(),
                OrderDate = DateTime.Now,
                UnitId = UnitId,
                OrderNo = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond,
                ActualAmount = (ItemList.Sum(m => m.Price) * Convert.ToDecimal(entity.DisCount)),
                OrderStatus = "1", //未发货状态
                UseAmount = ran.Next(0, 10),
                UsePoint = ran.Next(0, 8),
                UserId = UserId,
                VIpId = VipId,
                VipName = entity.VipName,
                SysCardTypeName = entity.SysCardName,
                SysCardTypeLevelBef = entity.SysCardId,
                SourcesId = ran.Next(14, 19).ToString(),
                PayMethod = ran.Next(10, 13).ToString(),
            };

            if (CouponCategory != null && !String.IsNullOrEmpty(CouponCategory.CouponId))
            {
                myorder.CouponId = CouponCategory.CouponId;
                myorder.ActualAmount = myorder.ActualAmount - CouponCategory.CouponMoney/100;
            }

            if (myorder.UseAmount != null)
            {
                myorder.ActualAmount = myorder.ActualAmount - myorder.UseAmount;
            }


            if (myorder.UsePoint != null)
            {
                myorder.ActualAmount = myorder.ActualAmount - myorder.UsePoint/10;
            }

            if (entity.NextIsSaleUpgrade == 1) //消费升级
            {
                if (!String.IsNullOrEmpty(entity.NextSaleTotalUpgradeMinMOney + "")) //累计消费
                {
                    if (Convert.ToDecimal(entity.NextSaleMinMoney) > myorder.TotalAmount + entity.OrderAmount) //累次消费升级
                    {
                        myorder.SysCardTypeLevelAfe = entity.NextSysCardId;
                    }
                }
                else   //首次消费升级
                {
                    if (entity.OrderCount == 0 && Convert.ToDecimal(entity.NextSaleMinMoney) <= myorder.TotalAmount)
                    {
                        myorder.SysCardTypeLevelAfe = entity.NextSysCardId;
                    }
                }
            }

            //入库  这一定要使用事物入库

            IOrderResponsity OrderService = new OrderResponsity(context);
            IOrderDetailResponsity OrderDetailService = new OrderDetailResponsity(context);

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    OrderService.Add(myorder);
                    foreach (var item in ItemList)
                    {
                        OrdersDetail detail = new OrdersDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ActualAmount = item.Price,
                            Discount = Convert.ToDecimal(entity.DisCount),
                            BuyCount = 1,
                            BuyPrice = item.Price,
                            ItemId = item.ItemId,
                            OrderId = myorder.Id,
                            PriceId = item.ItemPriceId,
                            TotalAmount = item.Price
                        };
                        OrderDetailService.Add(detail);
                        ItemPriceService.ExcuteSqls(string.Format(@"UPDATE itemprice SET StoreCount =StoreCount-1 WHERE Id='{0}'", item.ItemPriceId));
                    }

                    VipService.Excutes(string.Format("Update Vip set VipPoints=VipPoints-{0},VipAmount=VipAmount-{1} where Id='{2}'", myorder.UsePoint, myorder.UseAmount, VipId));

                    if (CouponCategory != null && !String.IsNullOrEmpty(CouponCategory.CouponId))
                    {
                        VipCouponMappingService.Excutes(string.Format(@"UPDATE VipCouponMap SET IsUse = 1, OrderId = '{0}' WHERE VipId = '{1}' AND CouponId = '{2}'", myorder.Id, VipId, CouponCategory.CouponId));
                    }

                    AmountDetailService.Add(new AmountDetail()
                    {
                        Amount = -myorder.UseAmount,
                        AmountDate = myorder.OrderDate,
                        AmountSourceId = "9",
                        Id = Guid.NewGuid().ToString(),
                        ObjectId = myorder.Id,
                        VipCurrentLevelId = myorder.SysCardTypeLevelBef,
                        VipAfterLevelId = myorder.SysCardTypeLevelAfe,
                        UnitId = myorder.UnitId,
                        VipId = VipId
                    });

                    PointsDetailService.Add(new PointsDetail()
                    {
                        Points = -Convert.ToInt32(myorder.UsePoint),
                        PointsDate = myorder.OrderDate,
                        PointsSourceId = "9",
                        Id = Guid.NewGuid().ToString(),
                        ObjectId = myorder.Id,
                        VipCurrentLevelId = myorder.SysCardTypeLevelBef,
                        VipAfterLevelId = myorder.SysCardTypeLevelAfe,
                        UnitId = myorder.UnitId,
                        VipId = VipId
                    });
                    scope.Complete();
                    SetService.Add("OrderReWard", myorder.toJson());   //添加订单奖励信息
                    log.Info(string.Format("接口请求信息", myorder.toJson()));
                }
                catch (Exception ex)
                {
                    log.Error(string.Format("接口 错误  错误 消息", ex.Message));
                    scope.Dispose();
                }
            }
        }
    }
}



/// <summary>
/// 商品基本信息
/// </summary>
public class ItemInfos
{
    public string ItemPriceId { get; set; }
    public string ItemId { get; set; }
    public string ItemName { get; set; }
    public string ItemCode { get; set; }
    public decimal Price { get; set; }
    public int StoreCount { get; set; }
    public string SkuName { get; set; }
    public string SkuCode { get; set; }
}

/// <summary>
/// 会员基本信息
/// </summary>
public class VipInfo
{
    /// <summary>
    /// VipId
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 会员名称
    /// </summary>
    public string VipName { get; set; }
    /// <summary>
    /// 会员上线
    /// </summary>
    public string VipOnLineId { get; set; }
    /// <summary>
    /// 会员上线名称
    /// </summary>
    public int VipOnLineCategory { get; set; }
    /// <summary>
    /// 会员积分
    /// </summary>
    public int VipPoints { get; set; }
    /// <summary>
    /// 会员余额
    /// </summary>
    public decimal VipAmount { get; set; }
    /// <summary>
    /// 当前享受折扣
    /// </summary>
    public decimal DisCount { get; set; }
    /// <summary>
    /// 下级卡 是否销售升级
    /// </summary>
    public int NextIsSaleUpgrade { get; set; }
    /// <summary>
    /// 下级 首次销售升级金额
    /// </summary>
    public decimal NextSaleMinMoney { get; set; }
    /// <summary>
    /// 下级 销售总金额
    /// </summary>
    public decimal NextSaleTotalUpgradeMinMOney { get; set; }
    /// <summary>
    /// 下级充值金额
    /// </summary>
    public decimal NextRechargeMinMoney { get; set; }
    /// <summary>
    /// 下级首次充值金额
    /// </summary>
    public int NextIsFirstRechargeUpgrade { get; set; }
    /// <summary>
    /// 下级卡名称
    /// </summary>
    public string NextSysCardName { get; set; }
    /// <summary>
    /// 下级卡等级
    /// </summary>
    public int NextSysCardLevel { get; set; }
    /// <summary>
    /// 下级卡Id
    /// </summary>
    public string NextSysCardId { get; set; }
    /// <summary>
    /// 当前卡等级Id
    /// </summary>
    public string SysCardId { get; set; }
    /// <summary>
    /// 当前卡名称
    /// </summary>
    public string SysCardName { get; set; }
    /// <summary>
    /// 消费 次数
    /// </summary>
    public int OrderCount { get; set; }
    /// <summary>
    /// 消费总金额
    /// </summary>
    public decimal OrderAmount { get; set; }
}
