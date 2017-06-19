using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IOrderReportResponsity
    {
        void Add(OrderReport entity);

        OrderReport Get(Expression<Func<OrderReport, bool>> predicate);

        List<OrderReport> FindList(Expression<Func<OrderReport, bool>> predicate);

        List<OrderReport> FindList(Expression<Func<OrderReport, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(OrderReport entity);

        void Delete(OrderReport entity);

        List<T> Excutes<T>(string sql) where T : class;

        List<T> GetReportByDate<T>() where T : class;
    }
}
