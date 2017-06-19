using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ICouponResponsity
    {
        void Add(Coupon entity);

        Coupon Get(Expression<Func<Coupon, bool>> predicate);

        List<Coupon> FindList(Expression<Func<Coupon, bool>> predicate);

        List<Coupon> FindList(Expression<Func<Coupon, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Coupon entity);

        void Delete(Coupon entity);
    }
}
