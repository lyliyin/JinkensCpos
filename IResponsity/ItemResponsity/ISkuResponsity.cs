using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ISkuResponsity
    {
        void Add(Sku entity);

        Sku Get(Expression<Func<Sku, bool>> predicate);

        List<Sku> FindList(Expression<Func<Sku, bool>> predicate);

        List<Sku> FindList(Expression<Func<Sku, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Sku entity);

        void Delete(Sku entity);
    }
}
