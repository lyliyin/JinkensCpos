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
    public class VipAddressResponsity : BaseService, IVipAddressResponsity
    {
        public VipAddressResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(VipAddress entity)
        {
            base.Add(entity);
        }

        public void Delete(VipAddress entity)
        {
            base.Delete(entity);
        }

        public List<VipAddress> FindList(Expression<Func<VipAddress, bool>> predicate)
        {
            return base.FindByWhere<VipAddress>(predicate).ToList();
        }

        public List<VipAddress> FindList(Expression<Func<VipAddress, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<VipAddress>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public VipAddress Get(Expression<Func<VipAddress, bool>> predicate)
        {
            return base.Get<VipAddress>(predicate);
        }

        public void Update(VipAddress entity)
        {
            throw new NotImplementedException();
        }
    }
}