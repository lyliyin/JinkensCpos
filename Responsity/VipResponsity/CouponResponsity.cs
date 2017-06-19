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
    public class CouponResponsity : BaseService, ICouponResponsity
    {
        public CouponResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Coupon entity)
        {
            base.Add(entity);
        }

        public void Delete(Coupon entity)
        {
            base.Delete(entity);
        }

        public List<Coupon> FindList(Expression<Func<Coupon, bool>> predicate)
        {
            return base.FindByWhere<Coupon>(predicate).ToList();
        }

        public List<Coupon> FindList(Expression<Func<Coupon, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Coupon>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Coupon Get(Expression<Func<Coupon, bool>> predicate)
        {
            return base.Get<Coupon>(predicate);
        }

        public void Update(Coupon entity)
        {
            throw new NotImplementedException();
        }
    }
}