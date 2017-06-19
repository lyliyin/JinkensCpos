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
    public class PriceSkuResponsity : BaseService,IPriceSkuResponsity
    {
        public PriceSkuResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(PriceSku entity)
        {
            base.Add(entity);
        }

        public void Delete(PriceSku entity)
        {
            base.Delete(entity);
        }

        public List<PriceSku> FindList(Expression<Func<PriceSku, bool>> predicate)
        {
            return base.FindByWhere<PriceSku>(predicate).ToList();
        }

        public List<PriceSku> FindList(Expression<Func<PriceSku, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<PriceSku>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public PriceSku Get(Expression<Func<PriceSku, bool>> predicate)
        {
            return base.Get<PriceSku>(predicate);
        }

        public void Update(PriceSku entity)
        {
            throw new NotImplementedException();
        }
    }
}



