using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IItemPriceResponsity
    {
        void Add(ItemPrice entity);

        ItemPrice Get(Expression<Func<ItemPrice, bool>> predicate);

        List<ItemPrice> FindList(Expression<Func<ItemPrice, bool>> predicate);

        List<ItemPrice> FindList(Expression<Func<ItemPrice, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(ItemPrice entity);

        void Delete(ItemPrice entity);

        void ExcuteSqls(string sql);
    }
}
