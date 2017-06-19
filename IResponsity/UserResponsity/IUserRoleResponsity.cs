using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IUserRoleResponsity
    {
        void Add(UserRole entity);

        UserRole Get(Expression<Func<UserRole, bool>> predicate);

        List<UserRole> FindList(Expression<Func<UserRole, bool>> predicate);

        List<UserRole> FindList(Expression<Func<UserRole, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(UserRole entity);

        void Delete(UserRole entity);
    }
}
