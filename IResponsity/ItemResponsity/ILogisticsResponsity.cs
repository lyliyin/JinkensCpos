using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ILogisticsResponsity
    {
        void Add(Logistics entity);

        Logistics Get(Expression<Func<Logistics, bool>> predicate);

        List<Logistics> FindList(Expression<Func<Logistics, bool>> predicate);

        List<Logistics> FindList(Expression<Func<Logistics, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Logistics entity);

        void Delete(Logistics entity);
    }
}
