using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IPointsDetailResponsity
    {
        void Add(PointsDetail entity);

        PointsDetail Get(Expression<Func<PointsDetail, bool>> predicate);

        List<PointsDetail> FindList(Expression<Func<PointsDetail, bool>> predicate);

        List<PointsDetail> FindList(Expression<Func<PointsDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(PointsDetail entity);

        void Delete(PointsDetail entity);

        List<T> FindListByVipId<T>(string VipId) where T : class;
    }
}
