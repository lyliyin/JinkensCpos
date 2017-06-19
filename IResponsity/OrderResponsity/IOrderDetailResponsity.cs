using DataModel;
using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IOrderDetailResponsity
    {
        void Add(OrdersDetail entity);

        OrdersDetail Get(Expression<Func<OrdersDetail, bool>> predicate);

        List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate);

        List<OrdersDetail> FindList(Expression<Func<OrdersDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(OrdersDetail entity);

        void Delete(OrdersDetail entity);
    }
}
