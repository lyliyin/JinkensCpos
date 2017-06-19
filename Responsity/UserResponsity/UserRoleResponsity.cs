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
    public class UserRoleResponsity : BaseService, IUserRoleResponsity
    {
        public UserRoleResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(UserRole entity)
        {
            base.Add(entity);
        }

        public void Delete(UserRole entity)
        {
            base.Delete(entity);
        }

        public List<UserRole> FindList(Expression<Func<UserRole, bool>> predicate)
        {
            return base.FindByWhere<UserRole>(predicate).ToList();
        }

        public List<UserRole> FindList(Expression<Func<UserRole, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<UserRole>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public UserRole Get(Expression<Func<UserRole, bool>> predicate)
        {
            return base.Get<UserRole>(predicate);
        }

        public void Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}