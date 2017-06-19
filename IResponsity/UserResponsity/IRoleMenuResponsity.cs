using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IRoleMenuResponsity
    {
        void Add(RoleMenu entity);

        RoleMenu Get(Expression<Func<RoleMenu, bool>> predicate);

        List<RoleMenu> FindList(Expression<Func<RoleMenu, bool>> predicate);

        List<RoleMenu> FindList(Expression<Func<RoleMenu, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(RoleMenu entity);

        void Delete(RoleMenu entity);
    }
}
