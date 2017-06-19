using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ICouponCategoryResponsity
    {
        void Add(CouponCategory entity);

        CouponCategory Get(Expression<Func<CouponCategory, bool>> predicate);

        List<CouponCategory> FindList(Expression<Func<CouponCategory, bool>> predicate);

        List<CouponCategory> FindList(Expression<Func<CouponCategory, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(CouponCategory entity);

        void Delete(CouponCategory entity);
    }
}