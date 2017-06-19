using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IItemImagesResponsity
    {
        void Add(ItemImages entity);

        ItemImages Get(Expression<Func<ItemImages, bool>> predicate);

        List<ItemImages> FindList(Expression<Func<ItemImages, bool>> predicate);

        List<ItemImages> FindList(Expression<Func<ItemImages, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(ItemImages entity);

        void Delete(ItemImages entity);
    }
}
