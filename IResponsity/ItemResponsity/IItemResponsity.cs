using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IItemResponsity
    {
        void Add(Item entity);

        Item Get(Expression<Func<Item, bool>> predicate);

        List<Item> FindList(Expression<Func<Item, bool>> predicate);

        List<Item> FindList(Expression<Func<Item, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        List<T> FindList<T>(string BrandId, string CategoryId, string ItemCode, string ItemName, int PageIndex, int PageSize, string OrderName, string OrderBy, out int RecordCount) where T : class;

        void Update(Item entity);

        void Delete(Item entity);

        T GetItemBySql<T>(string sql) where T : class;
    }
}
