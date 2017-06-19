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
    public class SupplierResponsity : BaseService, ISupplierResponsity
    {
        public SupplierResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Supplier entity)
        {
            base.Add(entity);
        }

        public void Delete(Supplier entity)
        {
            base.Delete(entity);
        }

        public List<Supplier> FindList(Expression<Func<Supplier, bool>> predicate)
        {
            return base.FindByWhere<Supplier>(predicate).ToList();
        }

        public List<Supplier> FindList(Expression<Func<Supplier, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Supplier>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Supplier Get(Expression<Func<Supplier, bool>> predicate)
        {
            return base.Get<Supplier>(predicate);
        }

        public void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}



