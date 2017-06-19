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
    public class UnitResponsity : BaseService, IUnitResponsity
    {
        public UnitResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Unit entity)
        {
            base.Add(entity);
        }

        public void Delete(Unit entity)
        {
            base.Delete(entity);
        }

        public List<Unit> FindList(Expression<Func<Unit, bool>> predicate)
        {
            return base.FindByWhere<Unit>(predicate).ToList();
        }

        public List<Unit> FindList(Expression<Func<Unit, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCoUnit)
        {
            return base.FindByPaged<Unit>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCoUnit).ToList();
        }

        public Unit Get(Expression<Func<Unit, bool>> predicate)
        {
            return base.Get<Unit>(predicate);
        }

        public void Update(Unit entity)
        {
            throw new NotImplementedException();
        }
    }
}