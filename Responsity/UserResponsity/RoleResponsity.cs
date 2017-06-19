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
    public class RoleResponsity : BaseService, IRoleResponsity
    {
        public RoleResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Role entity)
        {
            base.Add(entity);
        }

        public void Delete(Role entity)
        {
            base.Delete(entity);
        }

        public List<Role> FindList(Expression<Func<Role, bool>> predicate)
        {
            return base.FindByWhere<Role>(predicate).ToList();
        }

        public List<Role> FindList(Expression<Func<Role, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Role>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Role Get(Expression<Func<Role, bool>> predicate)
        {
            return base.Get<Role>(predicate);
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}