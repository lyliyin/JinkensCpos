using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IPriceSkuResponsity
    {
        void Add(PriceSku entity);

        PriceSku Get(Expression<Func<PriceSku, bool>> predicate);

        List<PriceSku> FindList(Expression<Func<PriceSku, bool>> predicate);

        List<PriceSku> FindList(Expression<Func<PriceSku, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(PriceSku entity);

        void Delete(PriceSku entity);
    }
}
