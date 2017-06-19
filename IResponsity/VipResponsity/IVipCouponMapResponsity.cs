using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IVipCouponMapResponsity
    {
        void Add(VipCouponMap entity);

        VipCouponMap Get(Expression<Func<VipCouponMap, bool>> predicate);

        List<VipCouponMap> FindList(Expression<Func<VipCouponMap, bool>> predicate);

        List<VipCouponMap> FindList(Expression<Func<VipCouponMap, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(VipCouponMap entity);

        void Delete(VipCouponMap entity);

        CouponCategory GetByVipId(string VipId);

        List<T> FindByVipId<T>(string VipId) where T : class;

        void Excutes(string sql);
    }
}
