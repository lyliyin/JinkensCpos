using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IRoleResponsity
    {
        void Add(Role entity);

        Role Get(Expression<Func<Role, bool>> predicate);

        List<Role> FindList(Expression<Func<Role, bool>> predicate);

        List<Role> FindList(Expression<Func<Role, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Role entity);

        void Delete(Role entity);
    }
}
