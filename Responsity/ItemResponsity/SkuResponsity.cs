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
    public class SkuResponsity : BaseService, ISkuResponsity
    {
        public SkuResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Sku entity)
        {
            base.Add(entity);
        }

        public void Delete(Sku entity)
        {
            base.Delete(entity);
        }

        public List<Sku> FindList(Expression<Func<Sku, bool>> predicate)
        {
            return base.FindByWhere<Sku>(predicate).ToList();
        }

        public List<Sku> FindList(Expression<Func<Sku, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Sku>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Sku Get(Expression<Func<Sku, bool>> predicate)
        {
            return base.Get<Sku>(predicate);
        }

        public void Update(Sku entity)
        {
            throw new NotImplementedException();
        }
    }
}



