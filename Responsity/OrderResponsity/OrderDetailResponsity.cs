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
    public class OrderDetailResponsity : BaseService, IOrderDetailResponsity
    {
        public OrderDetailResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(OrdersDetail entity)
        {
            base.Add(entity);
        }

        public void Delete(OrdersDetail entity)
        {
            base.Delete(entity);
        }

        public List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate)
        {
            return base.FindByWhere<OrdersDetail>(predicate).ToList();
        }

        public List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<OrdersDetail>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public OrdersDetail Get(Expression<Func<OrdersDetail, bool>> predicate)
        {
            return base.Get<OrdersDetail>(predicate);
        }

        public void Update(OrdersDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
