using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ISupplierResponsity
    {
        void Add(Supplier entity);

        Supplier Get(Expression<Func<Supplier, bool>> predicate);

        List<Supplier> FindList(Expression<Func<Supplier, bool>> predicate);

        List<Supplier> FindList(Expression<Func<Supplier, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Supplier entity);

        void Delete(Supplier entity);
    }
}
