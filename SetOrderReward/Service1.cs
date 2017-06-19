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
using System.Linq.Expressions;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DataCommTools;
using System.Threading;

namespace SetOrderReward
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timReward.Enabled = true;
            timReward.Interval = 1000;
            timReward.Start();
            timReward_Tick(null, null);
        }

        protected override void OnStop()
        {

        }

        /// <summary>
        /// 订单上线奖励
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timReward_Tick(object sender, EventArgs e)
        {
            new Action(() =>
            {
                while (true)
                {
                    SetOrderReward();
                }
            }).BeginInvoke(null, null);
        }

        public void SetOrderReward()
        {
            Log4NetExport log = Log4NetExport.Create(typeof(Service1));
            BuinessDBContext context = new BuinessDBContext();
            IOrderRewardRuleResponsity RuleService = new OrderRewardRuleResponsity(context);
            Expression<Func<OrderRewardRule, bool>> predicate = t => t.Id.Length > 0;
            var lst = RuleService.FindList(predicate);
            RedisSetService SetService = new RedisSetService();
            HashSet<string> OrdersList = SetService.GetAllItemsFromSet("OrderReWard");
            if (OrdersList == null || OrdersList.Count == 0)
            {
                Thread.Sleep(60000);
            }
            IVipResponsity VipService = new VipsResponsity(context);
            IAmountDetailResponsity AmountDetailService = new AmountDetailResponsity(context);
            IPointsDetailResponsity PointsDetailService = new PointsDetailResponsity(context);
            IOrderResponsity OrderService = new OrderResponsity(context);
            foreach (var item in OrdersList)
            {
                Orders myorder = item.ToEntity<Orders>();


                foreach (var nodeitem in lst)
                {

                    if (nodeitem.RewardCondition == 0) //0=首单奖励
                    {
                        Expression<Func<Orders, bool>> orderpredicate = t => t.VIpId == myorder.VIpId;
                        var firstorders = OrderService.Get(orderpredicate);
                        if (firstorders != null || String.IsNullOrEmpty(firstorders.Id))
                        {
                            continue;
                        }
                    }


                    if (nodeitem.RewardCondition == 2)  //2=满N元奖励
                    {

                        if (true)
                        {
                            continue;
                        }
                    }

                    if (nodeitem.RewardCategory == 0) //Vip
                    {
                        Expression<Func<Vip, bool>> vippredicate = t => t.Id == myorder.VIpId;
                        Vip vipentity = VipService.Get(vippredicate);

                        if (nodeitem.RewardFunction == 0) //积分
                        {
                            int RewardPoints = Convert.ToInt32(myorder.ActualAmount * Convert.ToInt32(nodeitem.RewardValue)) / 100;
                            string sql = string.Format("UPDATE VIP SET VipPoints =VipPoints+{0} WHERE Id='{1}'", RewardPoints, myorder.VIpId);
                            PointsDetail detail = new PointsDetail()
                            {
                                Id = Guid.NewGuid().ToString(),
                                Points = Convert.ToInt32(myorder.UsePoint),
                                PointsDate = myorder.OrderDate,
                                PointsSourceId = "4",
                                ObjectId = myorder.Id,
                                UnitId = myorder.UnitId,
                                 VipId= myorder.VIpId
                            };
                            PointsDetailService.Add(detail);

                            //添加 积分 详情
                        }
                        else if (nodeitem.RewardFunction == 1) //余额
                        {
                            decimal RewardAmount = Convert.ToDecimal(myorder.ActualAmount * Convert.ToInt32(nodeitem.RewardValue)) / 100;
                            string sql = string.Format("UPDATE VIP SET VipAmount =VipAmount+{0} WHERE Id='{1}'", RewardAmount, myorder.VIpId);

                            //添加 余额 详情
                            AmountDetail detail = new AmountDetail()
                            {
                                Id = Guid.NewGuid().ToString(),
                                Amount = myorder.UseAmount,
                                AmountDate = myorder.OrderDate,
                                AmountSourceId = "4",
                                ObjectId = myorder.Id,
                                UnitId = myorder.UnitId,
                                VipId = myorder.VIpId
                            };
                            AmountDetailService.Add(detail);
                        }
                        else if (nodeitem.RewardFunction == 2) //优惠券
                        {
                            //随机优惠券 添加映射表   暂不支持
                            // SetService.GetRandomItemFromSet("");
                        }
                    }
                }
                log.Info(string.Format("订单奖励处理：", myorder.toJson()));
                SetService.RemoveItemFromSet("OrderReWard", item);
            }
            Thread.Sleep(100);
        }
    }
}
