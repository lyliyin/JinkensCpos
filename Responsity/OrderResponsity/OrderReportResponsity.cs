using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Responsity
{
    public class OrderReportResponsity : BaseService, IOrderReportResponsity
    {
        public OrderReportResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(OrderReport entity)
        {
            base.Add(entity);
        }

        public void Delete(OrderReport entity)
        {
            base.Delete(entity);
        }

        public List<T> Excutes<T>(string sql) where T : class
        {
            return QueryBySql<T>(sql);
        }

        public List<T> GetReportByDate<T>() where T : class
        {
            string sql = string.Format(@" SELECT * INTO #UnitTemp FROM (
                        SELECT '销售门店' as UnitNames,u2.UnitName,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 1
                               )                  AS JanCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 2
                               )                  AS FebCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 3
                               )                  AS MarCount,
                                (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 4
                               )                  AS AprCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 5
                               )                  AS MayCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 6
                               )                  AS JunCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 7
                               )                  AS JulCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 8
                               )                  AS AguCount,
                                (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 9
                               )                  AS SepCount,
                                 (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 10
                               )                  AS OctCount,
                                 (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 11
                               )                  AS NovCount,
                                  (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  UnitId = or1.UnitId AND sd2.the_month = 12
                               )                  AS DecCount
                        FROM   OrderReport         AS or1
                               INNER JOIN Unit     AS u2  ON  u2.Id = or1.UnitId
                               INNER JOIN SysDate  AS sd  ON  sd.the_date = or1.OrderDate
                        GROUP BY
                               u2.UnitName,
                               or1.UnitId
                        ) AS t

                        SELECT * INTO #PayMethodTemp FROM (
                        SELECT '支付方式' as UnitNames,ss.Name,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 1
                               )                  AS JanCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE SourcesId  = or1.SourcesId AND sd2.the_month = 2
                               )                  AS FebCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE SourcesId  = or1.SourcesId AND sd2.the_month = 3
                               )                  AS MarCount,
                                (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 4
                               )                  AS AprCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE SourcesId  = or1.SourcesId AND sd2.the_month = 5
                               )                  AS MayCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE SourcesId  = or1.SourcesId AND sd2.the_month = 6
                               )                  AS JunCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 7
                               )                  AS JulCount,
                               (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 8
                               )                  AS AguCount,
                                (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 9
                               )                  AS SepCount,
                                 (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE SourcesId  = or1.SourcesId AND sd2.the_month = 10
                               )                  AS OctCount,
                                 (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 11
                               )                  AS NovCount,
                                  (
                                   SELECT ISNULL(SUM(ActualAmount),0.00)
                                   FROM   OrderReport 
                                   INNER JOIN SysDate AS sd2 ON  sd2.the_date = OrderDate
                                   WHERE  SourcesId  = or1.SourcesId AND sd2.the_month = 12
                               )                  AS DecCount
                        FROM   OrderReport         AS or1
                               INNER JOIN SysSources AS ss  on ss.Id=or1.SourcesId
                               INNER JOIN SysDate  AS sd  ON  sd.the_date = or1.OrderDate
                        GROUP BY
                               or1.SourcesId,
                               ss.Name
                        ) AS t

                        SELECT * FROM #UnitTemp
                        UNION ALL
                        SELECT '销售门店','总计：',SUM(JanCount),SUM(FebCount),SUM(MarCount),SUM(AprCount),SUM(MayCount),SUM(JunCount),
                        SUM(JulCount),SUM(AguCount),SUM(SepCount),SUM(OctCount),SUM(NovCount),SUM(DecCount) FROM #UnitTemp
                        UNION ALL
                        SELECT * FROM #PayMethodTemp
                        UNION ALL
                        SELECT '支付方式','总计：',SUM(JanCount),SUM(FebCount),SUM(MarCount),SUM(AprCount),SUM(MayCount),SUM(JunCount),
                        SUM(JulCount),SUM(AguCount),SUM(SepCount),SUM(OctCount),SUM(NovCount),SUM(DecCount) FROM #PayMethodTemp
                        DROP TABLE #UnitTemp
                        DROP TABLE #PayMethodTemp");
            return QueryBySql<T>(sql);
        }


        public List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<OrderReport> FindList(Expression<Func<OrderReport, bool>> predicate)
        {
            return base.FindByWhere<OrderReport>(predicate).ToList();
        }

        public List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            throw new NotImplementedException();
        }

        public List<OrderReport> FindList(Expression<Func<OrderReport, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<OrderReport>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }



        public OrderReport Get(Expression<Func<OrderReport, bool>> predicate)
        {
            return base.Get<OrderReport>(predicate);
        }

        public void Update(OrderReport entity)
        {
            throw new NotImplementedException();
        }


    }
}
