using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Responsity
{
    public class UserResponsity : BaseService, IUserResponsity
    {
        public UserResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(User entity)
        {
            base.Add(entity);
        }

        public void Delete(User entity)
        {
            base.Delete(entity);
        }

        public List<User> FindList(Expression<Func<User, bool>> predicate)
        {
            return base.FindByWhere<User>(predicate).ToList();
        }

        public List<User> FindList(Expression<Func<User, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<User>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public User Get(Expression<Func<User, bool>> predicate)
        {
            return base.Get<User>(predicate);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}