using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Responsity
{
    public class VipCouponMapResponsity : BaseService, IVipCouponMapResponsity
    {
        public VipCouponMapResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(VipCouponMap entity)
        {
            base.Add(entity);
        }

        public void Delete(VipCouponMap entity)
        {
            base.Delete(entity);
        }

        public void Excutes(string sql)
        {
            ExcuteSql(sql);
        }

        public List<T> FindByVipId<T>(string VipId) where T : class
        {
            string sql = string.Format(@"SELECT cc.CouponMoney,cc.CouponName,vcm.IsUse,(CASE
                                        WHEN vcm.IsUse =1 THEN '-2'  --已使用
                                        WHEN cc.EndTime<GETDATE() THEN '-1'  --已过期
                                        ELSE '0'  --未过期
                                        END) AS CouponStatus FROM VipCouponMap AS vcm
                                        INNER JOIN  Coupon AS c ON c.Id=vcm.CouponId
                                        INNER JOIN CouponCategory AS cc ON cc.CouponCategoryId=c.CouponCategoryId
                                        WHERE vcm.VipId='{0}'", VipId);
            return QueryBySql<T>(sql);
        }

        public void FindJoinByVipId()
        {


            var list = FindAll<VipCouponMap>().Join(FindAll<Vip>(), t => t.VipId, s => s.Id, (t, s) => new
            {
                s.VipName,
                t.Id,
                t.CouponId
            }).DefaultIfEmpty();
            Console.WriteLine();
            //}).DefaultIfEmpty().Join(FindAll<Coupon>(), t => t.CouponId, s => s.Id, (t, s) => new
            //{
            //    t.VipName,
            //    s.CouponCategoryId,
            //    s.CouponCode,
            //}).DefaultIfEmpty().Select(t => new { t.VipName, t.CouponCode });

            //var list = FindAll<VipCouponMap>().Join(FindAll<Vip>(), t => t.VipId, s => s.Id, (t, s) => new
            //{
            //    t.VipCouponStatus,
            //    s.VipAmount,
            //    t.CouponId,
            //    s.VipName,
            //    t.Id,
            //}).Join(FindAll<Coupon>(), t => t.CouponId, s => s.Id, (t, s) => new
            //{
            //    t.VipName,
            //    s.CouponCategoryId,
            //    s.CouponCode
            //}).Join(FindAll<CouponCategory>(), t => t.CouponCategoryId, s => s.CouponCategoryId, (t, s) => new
            //{
            //    t.VipName,
            //    t.CouponCode,
            //    s.CouponName,
            //    s.CouponMoney,
            //    s.StartTime,
            //    s.EndTime,
            //    s.HaveCouponCount
            //});//.OrderByDescending(t => t.StartTime).Skip(5).Take(10).ToList();

            //bool Flag = list.Any(t => t.CouponName.Contains("现"));
            // Console.WriteLine(Flag);
            //var maplist = FindAll<VipCouponMap>();
            //var viplist = FindAll<Vip>();
            //var list = from c in maplist
            //           join s in viplist on c.VipId equals s.Id
            //           into scList
            //           from sc in scList.DefaultIfEmpty()
            //           orderby sc.VipCardLevel descending
            //           where sc.VipName.Length > 0 
            //           select new { sc.VipCardLevel,sc.VipPhone };


            //var list = db.Order_Details
            //    .GroupBy(o => o.OrderID)
            //    .Select(g => new { key = g.Key, avg = g.Average(x => x.UnitPrice) })
            //    .ToList();
        }

        public List<VipCouponMap> FindList(Expression<Func<VipCouponMap, bool>> predicate)
        {
            return base.FindByWhere<VipCouponMap>(predicate).ToList();
        }

        public List<VipCouponMap> FindList(Expression<Func<VipCouponMap, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<VipCouponMap>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public VipCouponMap Get(Expression<Func<VipCouponMap, bool>> predicate)
        {
            return base.Get<VipCouponMap>(predicate);
        }

        public CouponCategory GetByVipId(string VipId)
        {
            string sql = string.Format(@"SELECT top 1 cc.*,c.Id as CouponId FROM VipCouponMap AS vcm
                                        INNER JOIN Coupon AS c ON c.Id=vcm.CouponId
                                        INNER JOIN CouponCategory AS cc ON cc.CouponCategoryId=c.CouponCategoryId
                                        WHERE vcm.VipId='{0}' AND vcm.IsUse=0 AND ISNULL(vcm.OrderId,'')=''
                                        AND cc.StartTime<=GETDATE() AND cc.EndTime>=GETDATE() 
                                        ORDER BY cc.CouponMoney DESC ", VipId);
            return QueryBySql<CouponCategory>(sql).FirstOrDefault();
        }

        public void Update(VipCouponMap entity)
        {
            throw new NotImplementedException();
        }
    }
}