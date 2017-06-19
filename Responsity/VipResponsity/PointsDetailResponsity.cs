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
    public class PointsDetailResponsity : BaseService, IPointsDetailResponsity
    {
        public PointsDetailResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(PointsDetail entity)
        {
            base.Add(entity);
        }

        public void Delete(PointsDetail entity)
        {
            base.Delete(entity);
        }

        public List<PointsDetail> FindList(Expression<Func<PointsDetail, bool>> predicate)
        {
            return base.FindByWhere<PointsDetail>(predicate).ToList();
        }

        public List<PointsDetail> FindList(Expression<Func<PointsDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<PointsDetail>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public List<T> FindListByVipId<T>(string VipId) where T:class
        {
            string sql = string.Format(@"SELECT pd.Points,CONVERT(VARCHAR(100),pd.PointsDate, 23) as PointsDate ,u.UnitName,ss.Name FROM PointsDetail AS pd
                                        LEFT JOIN Unit AS u ON u.Id=pd.UnitId
                                        INNER JOIN SysSources AS ss ON ss.Id=pd.PointsSourceId
                                        WHERE pd.VipId='{0}'", VipId);
            return QueryBySql<T>(sql);
        }

        public PointsDetail Get(Expression<Func<PointsDetail, bool>> predicate)
        {
            return base.Get<PointsDetail>(predicate);
        }

        public void Update(PointsDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}