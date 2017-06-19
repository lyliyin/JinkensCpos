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
    public class CouponCategoryResponsity : BaseService, ICouponCategoryResponsity
    {
        public CouponCategoryResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(CouponCategory entity)
        {
            base.Add(entity);
        }

        public void Delete(CouponCategory entity)
        {
            base.Delete(entity);
        }

        public List<CouponCategory> FindList(Expression<Func<CouponCategory, bool>> predicate)
        {
            return base.FindByWhere<CouponCategory>(predicate).ToList();
        }

        public List<CouponCategory> FindList(Expression<Func<CouponCategory, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<CouponCategory>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public CouponCategory Get(Expression<Func<CouponCategory, bool>> predicate)
        {
            return base.Get<CouponCategory>(predicate);
        }

        public void Update(CouponCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}