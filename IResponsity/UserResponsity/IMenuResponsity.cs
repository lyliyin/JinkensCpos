using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IMenuResponsity
    {
        void Add(Menu entity);

        Menu Get(Expression<Func<Menu, bool>> predicate);

        List<Menu> FindList(Expression<Func<Menu, bool>> predicate);

        List<Menu> FindList(Expression<Func<Menu, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Menu entity);

        void Delete(Menu entity);
    }
}
