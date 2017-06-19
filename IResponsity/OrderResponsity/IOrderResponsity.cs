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
    public interface IOrderResponsity
    {
        void Add(Orders entity);

        Orders Get(Expression<Func<Orders, bool>> predicate);

        List<Orders> FindList(Expression<Func<Orders, bool>> predicate);

        List<Orders> FindList(Expression<Func<Orders, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Orders entity);

        void Delete(Orders entity);

        List<T> FindByVipId<T>(string VipId) where T : class;

        List<T> FindAll<T>(int PageIndex, int PageSize,string OrderNo, out int RecordCount) where T : class;
    }
}
