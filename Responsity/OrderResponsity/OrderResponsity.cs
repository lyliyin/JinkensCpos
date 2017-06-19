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
    public class OrderResponsity : BaseService, IOrderResponsity
    {
        public OrderResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Orders entity)
        {
            base.Add(entity);
        }

        public void Delete(Orders entity)
        {
            base.Delete(entity);
        }

        public List<T> FindByVipId<T>(string VipId) where T : class
        {
            string sql = string.Format(@"SELECT o.OrderNo,o.UsePoint,o.UseAmount,o.TotalAmount,
                                        o.ActualAmount,u.UnitName,u2.UserName,ss.Name,ISNULL(cc.CouponMoney,0)
                                        AS CouponMoney,o.Discount
                                          FROM Orders AS o
                                        LEFT JOIN Unit AS u ON O.UnitId=U.Id
                                        LEFT JOIN [User] AS u2 ON U2.Id=O.UserId
                                        LEFT JOIN SysSources AS ss ON ss.Id=O.SourcesId
                                        LEFT JOIN Coupon AS c ON c.Id=o.CouponId
                                        LEFT JOIN CouponCategory AS cc ON cc.CouponCategoryId=c.CouponCategoryId
                                        WHERE o.VIpId='{0}'", VipId);
            return QueryBySql<T>(sql);
        }

        public List<Orders> FindList(Expression<Func<Orders, bool>> predicate)
        {
            return base.FindByWhere<Orders>(predicate).ToList();
        }

        public List<Orders> FindList(Expression<Func<Orders, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Orders>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Orders Get(Expression<Func<Orders, bool>> predicate)
        {
            return base.Get<Orders>(predicate);
        }

        public void Update(Orders entity)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll<T>(int PageIndex, int PageSize, string OrderNo, out int RecordCount) where T : class
        {
            string condition = " 1=1 ";
            if (String.IsNullOrEmpty(OrderNo))
            {
                RecordCount = FindAll<Orders>().Count();
            }
            else
            {
                condition = string.Format(" o.OrderNo='{0}'",OrderNo);
                RecordCount = FindAll<Orders>().Where(m => m.OrderNo == OrderNo).Count();
            }

            string sql = string.Format(@"SELECT * FROM (SELECT ROW_NUMBER () OVER (ORDER BY o.OrderDate DESC) AS RowId, o.OrderNo,o.UsePoint,o.UseAmount,o.TotalAmount,
                                        o.ActualAmount,u.UnitName,u2.UserName,ss.Name,
                                        ISNULL(cc.CouponMoney,0) AS CouponMoney,o.OrderDate,
                                        o.OrderStatus,
                                        o.Discount
                                          FROM Orders AS o
                                        LEFT JOIN Unit AS u ON O.UnitId=U.Id
                                        LEFT JOIN [User] AS u2 ON U2.Id=O.UserId
                                        LEFT JOIN SysSources AS ss ON ss.Id=O.SourcesId
                                        LEFT JOIN Coupon AS c ON c.Id=o.CouponId
                                        LEFT JOIN CouponCategory AS cc ON cc.CouponCategoryId=c.CouponCategoryId
                                        WHERE {0}
                                        ) AS t WHERE t.RowId>={1} AND t.RowId<{2}",condition,(PageIndex-1) * PageSize, (PageSize * (PageIndex)));
            return QueryBySql<T>(sql).ToList();
        }
    }
}
