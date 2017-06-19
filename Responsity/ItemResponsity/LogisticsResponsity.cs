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
    public class LogisticsResponsity : BaseService, ILogisticsResponsity
    {
        public LogisticsResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Logistics entity)
        {
            base.Add(entity);
        }

        public void Delete(Logistics entity)
        {
            base.Delete(entity);
        }

        public List<Logistics> FindList(Expression<Func<Logistics, bool>> predicate)
        {
            return base.FindByWhere<Logistics>(predicate).ToList();
        }

        public List<Logistics> FindList(Expression<Func<Logistics, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Logistics>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Logistics Get(Expression<Func<Logistics, bool>> predicate)
        {
            return base.Get<Logistics>(predicate);
        }

        public void Update(Logistics entity)
        {
            throw new NotImplementedException();
        }
    }
}


