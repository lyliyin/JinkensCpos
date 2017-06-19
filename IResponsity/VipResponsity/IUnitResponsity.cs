using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IUnitResponsity
    {
        void Add(Unit entity);

        Unit Get(Expression<Func<Unit, bool>> predicate);

        List<Unit> FindList(Expression<Func<Unit, bool>> predicate);

        List<Unit> FindList(Expression<Func<Unit, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Unit entity);

        void Delete(Unit entity);
    }
}
