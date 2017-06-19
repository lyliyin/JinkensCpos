using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IUserResponsity
    {
        void Add(User entity);

        User Get(Expression<Func<User, bool>> predicate);

        List<User> FindList(Expression<Func<User, bool>> predicate);

        List<User> FindList(Expression<Func<User, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(User entity);

        void Delete(User entity);
    }
}
